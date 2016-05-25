#include "sparse.h"
#include "mkl.h"
#include <stdio.h>
#include <stdlib.h>
#include <time.h>
#include <math.h>
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