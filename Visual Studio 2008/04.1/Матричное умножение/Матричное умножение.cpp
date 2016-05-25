#include <stdio.h>
#include <stdlib.h>
#include <conio.h>
#include "sparse.h"
#include "util.h"
#include <cmath>
#include <vector>
#include "mkl.h"
const double EPSILON = 0.000001; // argv[1] - порядок матрицы // argv[2] - количество ненулей в строках матрицы A
#define MAX_VAL 1000
using namespace std;

// Флаг - был ли инициализирован генератор случайных чисел 
bool isSrandCalled = false; 
double next() 
{
	return ((double)rand() / (double)RAND_MAX); 
}
// Генерирует квадратную матрицу в формате CRS 
// (3 массива, индексация с нуля) 
// В каждой строке cntInRow ненулевых элементов 
void GenerateRegularCRS(int seed, int N, int cntInRow, crsMatrix& mtx) 
{ 
	int i, j, k, f, tmp, notNull;
	int c=0; 
	if (!isSrandCalled) 
	{ 
		srand(seed); 
		isSrandCalled = true; 
	} 
	notNull = cntInRow * N; 
	InitializeMatrix(N, notNull, mtx); 
	for(i = 0; i < N; i++) 
	{ 
		// Формируем номера столбцов в строке i 
		for(j = 0; j < cntInRow; j++) 
		{
			do 
			{ 
				mtx.Col[i * cntInRow + j] = rand() % N; 
				f = 0; 
				for (k = 0; k < j; k++) 
					if (mtx.Col[i * cntInRow + j] == mtx.Col[i * cntInRow + k]) 
						f = 1; 
			} 
			while (f == 1); 
		} // Сортируем номера столцов в строке i 
		for (j = 0; j < cntInRow - 1; j++) 
			for (k = 0; k < cntInRow - 1; k++) 
				if (mtx.Col[i * cntInRow + k] > mtx.Col[i * cntInRow + k + 1]) 
				{ 
					tmp = mtx.Col[i * cntInRow + k]; 
					mtx.Col[i * cntInRow + k] = mtx.Col[i * cntInRow + k + 1]; 
					mtx.Col[i * cntInRow + k + 1] = tmp; 
				} 
	} // Заполняем массив значений 
	for (i = 0; i < cntInRow * N; i++)
		mtx.Value[i] = next() * MAX_VAL; 
	// Заполняем массив индексов строк c = 0; 
	for (i = 0; i <= N; i++) 
	{ 
		mtx.RowIndex[i]=c; 
		c += cntInRow;
	} 
} 
// Генерирует квадратную матрицу в формате CRS 
// (3 массива, индексация с нуля) 
// Число ненулевых элементов в строках растет 
// от 1 до cntInRow. Закон роста - кубическая парабола 
void GenerateSpecialCRS(int seed, int N, int cntInRow, crsMatrix& mtx) 
{ 
	if (!isSrandCalled) 
	{ 
		srand(seed); 
		isSrandCalled = true; 
	} 
	double end = pow((double)cntInRow, 1.0 / 3.0); 
	double step =( end / N); 
	vector <int> *columns = new vector<int>[N]; 
	int NZ = 0; 
	for (int i = 0; i < N; i++) 
	{ 
		int rowNZ = int(pow((double(i + 1) * step), 3) + 1); 
		NZ += rowNZ; 
		int num1 = (rowNZ - 1) / 2; 
		int num2 = rowNZ - 1 - num1; if (rowNZ != 0) 
		{ 
			if (i < num1) 
			{ 
				num2 += num1 - i; 
				num1 = i; 
				for(int j = 0; j < i; j++) 
					columns[i].push_back(j); 
				columns[i].push_back(i); 
				for(int j = 0; j < num2; j++) 
					columns[i].push_back(i + 1 + j); 
			} 
			else 
			{ 
				if (N - i - 1 < num2) 
				{ 
					num1 += num2 - (N - 1 - i);
					num2 = N - i - 1; 
				} 
				for (int j = 0; j < num1; j++) 
					columns[i].push_back(i - num1 + j); 
				columns[i].push_back(i); 
				for (int j = 0; j < num2; j++) 
					columns[i].push_back(i + j + 1); 
			} 
		} 
	} 
	InitializeMatrix(N, NZ, mtx); 
	int count = 0; 
	vector<int>::size_type sum = 0; 
	for (int i = 0; i < N; i++) 
	{ 
		mtx.RowIndex[i] = sum; 
		sum += columns[i].size(); 
		for (vector<int>::size_type j = 0; j < columns[i].size(); j++) 
		{ 
			mtx.Col[count] = columns[i][j]; 
			mtx.Value[count] = next(); 
			count++; 
		} 
	} 
	mtx.RowIndex[N] = sum; 
	delete [] columns; 
}

int main() 
{ 
	
	int N = 10000; 
	int NZ = 50; 
	
	crsMatrix A, B, BT, C; 
	GenerateRegularCRS(1, N, NZ, A); 
	GenerateSpecialCRS(2, N, NZ, B); 
	InitializeMatrix(N, B.NZ, BT);
	Transpose(B, BT); 
	double timeM, timeM1; 
	Multiplicate(A, BT, C, timeM); 
	crsMatrix CM; 
	double diff; 
	SparseMKLMult(A, B, CM, timeM1); 
	SparseDiff(C, CM, diff);
	if (diff < EPSILON)
		printf("OK\n"); 
	else 
		printf("not OK\n"); 
	printf("%d %d %d %d\n", A.N, A.NZ, B.NZ, C.NZ); 
	printf("%.3f %.3f\n",  timeM, timeM1); 
	FreeMatrix(A); 
	FreeMatrix(B); 
	FreeMatrix(BT); 
	FreeMatrix(C); 
	_getch();
	return 0; 
}