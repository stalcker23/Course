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

// Принимает 2 квадратных матрицы в формате CRS 
// (3 массива, индексация с нуля) 
// Возвращает max|Cij|, где C = A - B 
// Для сравнения использует функцию из MKL 
// Возвращает признак успешности операции: 0 - ОК,
// 1 - не совпадают размеры (N) 
int SparseDiff(crsMatrix A, crsMatrix B, double &diff) 
{
	if (A.N != B.N) 
		return 1; 
	int n = A.N; 
	// Будем вычислять C = A - B, используя MKL 
	// Структуры данных в стиле MKL 
	double *c = 0; 
	// Значения 
	int *jc = 0; 
	// Номера столбцов (нумерация с единицы) 
	int *ic; 
	// Индексы первых элементов строк 
	// (нумерация с единицы) 
	// Настроим параметры для вызова функции MKL 
	// Переиндексируем матрицы A и B с единицы 
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
	// Используется функция, вычисляющая C = A + beta*op(B) 
	char trans = 'N'; 
	int request;
	int sort = 8;
	double beta = -1.0;
	int nzmax = -1; 
	// Служебная информация 
	int info; 
	// Выделим память для индекса в матрице C 
	ic = new int[n + 1]; 
	// Сосчитаем количество ненулевых элементов в матрице C 
	request = 1; 
	mkl_dcsradd(&trans, &request, &sort, &n, &n, A.Value, A.Col, A.RowIndex, &beta, B.Value, B.Col, B.RowIndex, c, jc, ic, &nzmax, &info); 
	int nzc = ic[n] - 1; 
	c = new double[nzc]; 
	jc = new int[nzc];
	// Сосчитаем C = A - B 
	request = 2; 
	mkl_dcsradd(&trans, &request, &sort, &n, &n, A.Value, A.Col, A.RowIndex, &beta, B.Value, B.Col, B.RowIndex, c, jc, ic, &nzmax, &info); 
	// Сосчитаем max|Cij| 
	diff = 0.0; 
	for (i = 0; i < nzc; i++) 
	{ 
		double var = fabs(c[i]); 
		if (var > diff) diff = var; 
	} 
	// Приведем к исходному виду матрицы A и B 
	for (i = 0; i < A.NZ; i++) 
		A.Col[i]--; 
	for (i = 0; i < B.NZ; i++) 
		B.Col[i]--; 
	for (j = 0; j <= n; j++) 
	{ 
		A.RowIndex[j]--; 
		B.RowIndex[j]--; 
	} 
	// Освободим память 
	delete [] c; 
	delete [] ic; 
	delete [] jc; 
	return 0; 
}

int SparseMKLMult(crsMatrix A, crsMatrix B, crsMatrix &C, double &time) 
{ 
	if (A.N != B.N) 
		return 1; 
	int n = A.N; // Настроим параметры для вызова функции MKL 
	// Переиндексируем матрицы A и B с единицы 
	int i, j; for (i = 0; i < A.NZ; i++) 
		A.Col[i]++; 
	for (i = 0; i < B.NZ; i++)
		B.Col[i]++; 
	for (j = 0; j <= n; j++) 
	{ 
		A.RowIndex[j]++; 
		B.RowIndex[j]++; 
	} 
	// Используется функция, вычисляющая C = op(A) * B 
	char trans = 'N';
	int request; 
	// Еще один нетривиальный момент: есть возможность настроить, нужно ли упорядочивать матрицы A, B и C. 
	// У нас предполагается, что все матрицы упорядочены, следовательно, выбираем вариант "No-No-Yes", который  соответствует любому значению, кроме целых чисел // от 1 до 7 включительно 
	int sort = 8; // Количество ненулевых элементов. // Используется только если request = 0 
	int nzmax = -1; // Служебная информация 
	int info; 
	clock_t start = clock(); 
	// Выделим память для индекса в матрице C 
	C.RowIndex = new int[n + 1]; 
	// Сосчитаем количество ненулевых элементов в матрице C 
	request = 1; 
	C.Value = 0; 
	C.Col = 0; 
	mkl_dcsrmultcsr(&trans, &request, &sort, &n, &n, &n, A.Value, A.Col, A.RowIndex, B.Value, B.Col, B.RowIndex, C.Value, C.Col, C.RowIndex, &nzmax, &info); 
	int nzc = C.RowIndex[n] - 1; 
	C.Value = new double[nzc]; 
	C.Col = new int[nzc]; 
	// Сосчитаем C = A * B 
	request = 2; 
	mkl_dcsrmultcsr(&trans, &request, &sort, &n, &n, &n, A.Value, A.Col, A.RowIndex, B.Value, B.Col, B.RowIndex, C.Value, C.Col, C.RowIndex, &nzmax, &info); 
	C.N = n; 
	C.NZ = nzc; 
	clock_t finish = clock(); 
	// Приведем к нормальному виду матрицы A, B и С 
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