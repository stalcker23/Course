#ifndef SPARSE_H
#define SPARSE_H

struct crsMatrix 
{ 
	int N; // ������ ������� (N x N) 
	int NZ; // ���-�� ��������� ��������� 
	// ������ �������� (������ NZ) 
	double* Value; // ������ ������� �������� (������ NZ) 
	int* Col; // ������ �������� ����� (������ N + 1) 
	int* RowIndex; 
};
int Multiplicate(crsMatrix A, crsMatrix B, crsMatrix &C, double &time);

#endif