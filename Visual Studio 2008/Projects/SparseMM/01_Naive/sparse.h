#ifndef SPARSE_H
#define SPARSE_H

struct crsMatrix 
{ 
	int N; // Размер матрицы (N x N) 
	int NZ; // Кол-во ненулевых элементов 
	// Массив значений (размер NZ) 
	double* Value; // Массив номеров столбцов (размер NZ) 
	int* Col; // Массив индексов строк (размер N + 1) 
	int* RowIndex; 
};
void Transpose(crsMatrix A, crsMatrix &AT);
int Multiplicate(crsMatrix A, crsMatrix B, crsMatrix &C, double &time);

#endif