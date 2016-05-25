#include "sparse.h"
#include "util.h"
#include <stdlib.h>
#include <time.h>
#include <vector>
#include <cmath>
using namespace std;
const double ZERO_IN_CRS = 0.000001; 
int Multiplicate(crsMatrix A, crsMatrix B, crsMatrix &C, double &time) 
{ 
	if (A.N != B.N) 
		return 1; 
	int N = A.N; 
	vector<int> columns; 
	vector<double> values; 
	vector<int> row_index; 


clock_t start = clock();
int NZ = 0; row_index.push_back(0);
for (int i = 0; i < N; i++)
{ for (int j = 0; j < N; j++)
{ // Умножаем строку i матрицы A и столбец j матрицы B
	double sum = 0; int ks = A.RowIndex[i];
	int ls = B.RowIndex[j]; int kf = A.RowIndex[i + 1] - 1;
	int lf = B.RowIndex[j + 1] - 1; 
	while ((ks <= kf) && (ls <= lf)) { if (A.Col[ks] < B.Col[ls]) ks++; 
	else if (A.Col[ks] > B.Col[ls]) ls++; else { sum += A.Value[ks] * B.Value[ls]; ks++; ls++; } }

if (fabs(sum) > ZERO_IN_CRS)
{ columns.push_back(j); values.push_back(sum); NZ++; } } row_index.push_back(NZ);
}
InitializeMatrix(N, columns.size(), C); 
	
	
	
	
	for (unsigned int j = 0; j < columns.size(); j++) 
	{ 
		C.Col[j] = columns[j]; 
		C.Value[j] = values[j]; 
	} 
	for(int i = 0; i <= N; i++) 
		C.RowIndex[i] = row_index[i]; 
	clock_t finish = clock(); 
	time = (double)(finish - start) / CLOCKS_PER_SEC; return 0; 
}

