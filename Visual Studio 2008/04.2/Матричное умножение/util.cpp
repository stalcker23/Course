#include "sparse.h"
#include <stdio.h>
#include <stdlib.h>
#include <time.h>
#include <math.h>
#include "mkl.h"
#include <string.h>
#include <vector>

void InitializeMatrix(int N, int NZ, crsMatrix &mtx) 
{ 
	mtx.N = N; 
	mtx.NZ = NZ; 
	mtx.Value = new double[NZ]; 
	mtx.Col = new int[NZ]; 
	mtx.RowIndex = new int[N + 1]; 
}

void FreeMatrix(crsMatrix &mtx) 
{
	delete[] mtx.Value; 
	delete[] mtx.Col; 
	delete[] mtx.RowIndex; 
}

int WriteMatrix(crsMatrix mtx, char *fileName) 
{ 
	FILE *f = fopen(fileName, "w+"); 
	fprintf(f, "%i\n", mtx.NZ); 
	fprintf(f, "%i\n", mtx.N); 
	for (int i = 0; i < mtx.NZ; i++) 
		fprintf(f, "%lf;%i\n", mtx.Value[i], mtx.Col[i]); 
	for (int i = 0; i < mtx.N + 1; i++) 
		fprintf(f, "%i\n", mtx.RowIndex[i]); 
	fclose(f); 
	return 0; 
}

int ReadMatrix(crsMatrix &mtx, char *fileName) 
{ 
	int N, NZ; 
	if (fileName == NULL) 
		return -1; 
	FILE *f = fopen(fileName, "r"); 
	if (f == NULL) 
		return -1; 
		fscanf(f, "%d", &NZ); 
	fscanf(f, "%d", &N); 
	InitializeMatrix(N, NZ, mtx);

	for (int i = 0; i < NZ; i++) 
	fscanf(f, "%lf;%i", &(mtx.Value[i]), &(mtx.Col[i]));

	for (int i = 0; i < N + 1; i++) 
	fscanf(f, "%d", &(mtx.RowIndex[i])); 
	
	fclose(f); 
return 0; 
}
void Transpose(crsMatrix A, crsMatrix &AT)
{
	int S, tmp, RIndex, IIndex, j1, j2, i, j, Col;
	double V;
	memset(AT.RowIndex, 0, (A.N+1) * sizeof(int)); 
	for (i = 0; i < A.NZ; i++) 
		AT.RowIndex[A.Col[i] + 1]++;
	S = 0; 
	for (i = 1; i <= A.N; i++) 
	{ 
		tmp = AT.RowIndex[i]; 
		AT.RowIndex[i] = S; 
		S = S + tmp; 
	}
	for (i = 0; i < A.N; i++) 
	{ 
		j1 = A.RowIndex[i]; 
		j2 = A.RowIndex[i+1]; 
		Col = i; 
		// ������� � AT - ������ � � 
		for (j = j1; j < j2; j++) 
		{ 
			V = A.Value[j]; 
			// �������� 
			RIndex = A.Col[j]; 
			// ������ � AT 
			IIndex = AT.RowIndex[RIndex + 1]; 
			AT.Value[IIndex] = V; 
			AT.Col [IIndex] = Col; 
			AT.RowIndex[RIndex + 1]++; 
		} 
	}
}


// ��������� 2 ���������� ������� � ������� CRS 
// (3 �������, ���������� � ����) 
// ���������� max|Cij|, ��� C = A - B 
// ��� ��������� ���������� ������� �� MKL 
// ���������� ������� ���������� ��������: 0 - ��,
// 1 - �� ��������� ������� (N) 
int SparseDiff(crsMatrix A, crsMatrix B, double &diff) 
{
	if (A.N != B.N) 
		return 1; 
	int n = A.N; 
	// ����� ��������� C = A - B, ��������� MKL 
	// ��������� ������ � ����� MKL 
	double *c = 0; 
	// �������� 
	int *jc = 0; 
	// ������ �������� (��������� � �������) 
	int *ic; 
	// ������� ������ ��������� ����� 
	// (��������� � �������) 
	// �������� ��������� ��� ������ ������� MKL 
	// ��������������� ������� A � B � ������� 
	int i, j; 
	for (i = 0; i < A.NZ; i++) 
		A.Col[i]++; 
	for (i = 0; i < B.NZ; i++) 
		B.Col[i]++; 
	for (j = 0; j <= A.N; j++) 
	{ 
		A.RowIndex[j]++; 
		B.RowIndex[j]++; 
	} 
	// ������������ �������, ����������� C = A + beta*op(B) 
	char trans = 'N'; 
	int request;
	int sort = 8;
	double beta = -1.0;
	int nzmax = -1; 
	// ��������� ���������� 
	int info; 
	// ������� ������ ��� ������� � ������� C 
	ic = new int[n + 1]; 
	// ��������� ���������� ��������� ��������� � ������� C 
	request = 1; 
	mkl_dcsradd(&trans, &request, &sort, &n, &n, A.Value, A.Col, A.RowIndex, &beta, B.Value, B.Col, B.RowIndex, c, jc, ic, &nzmax, &info); 
	int nzc = ic[n] - 1; 
	c = new double[nzc]; 
	jc = new int[nzc];
	// ��������� C = A - B 
	request = 2; 
	mkl_dcsradd(&trans, &request, &sort, &n, &n, A.Value, A.Col, A.RowIndex, &beta, B.Value, B.Col, B.RowIndex, c, jc, ic, &nzmax, &info); 
	// ��������� max|Cij| 
	diff = 0.0; 
	for (i = 0; i < nzc; i++) 
	{ 
		double var = fabs(c[i]); 
		if (var > diff) diff = var; 
	} 
	// �������� � ��������� ���� ������� A � B 
	for (i = 0; i < A.NZ; i++) 
		A.Col[i]--; 
	for (i = 0; i < B.NZ; i++) 
		B.Col[i]--; 
	for (j = 0; j <= n; j++) 
	{ 
		A.RowIndex[j]--; 
		B.RowIndex[j]--; 
	} 
	// ��������� ������ 
	delete [] c; 
	delete [] ic; 
	delete [] jc; 
	return 0; 
}

int SparseMKLMult(crsMatrix A, crsMatrix B, crsMatrix &C, double &time) 
{ 
	if (A.N != B.N) 
		return 1; 
	int n = A.N; // �������� ��������� ��� ������ ������� MKL 
	// ��������������� ������� A � B � ������� 
	int i, j; for (i = 0; i < A.NZ; i++) 
		A.Col[i]++; 
	for (i = 0; i < B.NZ; i++)
		B.Col[i]++; 
	for (j = 0; j <= n; j++) 
	{ 
		A.RowIndex[j]++; 
		B.RowIndex[j]++; 
	} 
	// ������������ �������, ����������� C = op(A) * B 
	char trans = 'N';
	int request; 
	// ��� ���� ������������� ������: ���� ����������� ���������, ����� �� ������������� ������� A, B � C. 
	// � ��� ��������������, ��� ��� ������� �����������, �������������, �������� ������� "No-No-Yes", �������  ������������� ������ ��������, ����� ����� ����� // �� 1 �� 7 ������������ 
	int sort = 8; // ���������� ��������� ���������. // ������������ ������ ���� request = 0 
	int nzmax = -1; // ��������� ���������� 
	int info; 
	clock_t start = clock(); 
	// ������� ������ ��� ������� � ������� C 
	C.RowIndex = new int[n + 1]; 
	// ��������� ���������� ��������� ��������� � ������� C 
	request = 1; 
	C.Value = 0; 
	C.Col = 0; 
	mkl_dcsrmultcsr(&trans, &request, &sort, &n, &n, &n, A.Value, A.Col, A.RowIndex, B.Value, B.Col, B.RowIndex, C.Value, C.Col, C.RowIndex, &nzmax, &info); 
	int nzc = C.RowIndex[n] - 1; 
	C.Value = new double[nzc]; 
	C.Col = new int[nzc]; 
	// ��������� C = A * B 
	request = 2; 
	mkl_dcsrmultcsr(&trans, &request, &sort, &n, &n, &n, A.Value, A.Col, A.RowIndex, B.Value, B.Col, B.RowIndex, C.Value, C.Col, C.RowIndex, &nzmax, &info); 
	C.N = n; 
	C.NZ = nzc; 
	clock_t finish = clock(); 
	// �������� � ����������� ���� ������� A, B � � 
	for (i = 0; i < A.NZ; i++) 
		A.Col[i]--; 
	for (i = 0; i < B.NZ; i++) 
		B.Col[i]--; 
	for (i = 0; i < C.NZ; i++) 
		C.Col[i]--; 
	for (j = 0; j <= n; j++)
		{ 
			A.RowIndex[j]--; 
			B.RowIndex[j]--; 
			C.RowIndex[j]--; 
		} 
	time = double(finish - start) / double(CLOCKS_PER_SEC);
	return 0; 
}