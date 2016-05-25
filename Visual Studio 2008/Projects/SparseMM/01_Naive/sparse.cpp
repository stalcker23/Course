#include "sparse.h"
#include "util.h"
#include <stdlib.h>
#include <time.h>
#include <vector>
#include <cmath>
using namespace std;
const double ZERO_IN_CRS = 0.000001;

void Transpose(crsMatrix A, crsMatrix &AT)
{
	int S, tmp, RIndex, IIndex;
	int j1, j2, i, j, Col;
	double V;
	int N = A.N;
	memset(AT.RowIndex, 0, (N+1) * sizeof(int)); 
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
		Col = i; // Столбец в AT - строка в А 
		for (j = j1; j < j2; j++) 
		{ 
			V = A.Value[j]; // Значение 
			RIndex = A.Col[j]; // Строка в AT 
			IIndex = AT.RowIndex[RIndex + 1]; 
			AT.Value[IIndex] = V; 
			AT.Col[IIndex] = Col; 
			AT.RowIndex[RIndex + 1]++; 
		} 
	}
}

int Multiplicate(crsMatrix A, crsMatrix B, crsMatrix &C, double &time) 
{ 
	if (A.N != B.N) 
		return 1; 
	int N = A.N; 
	vector<int> columns; 
	vector<double> values; 
	vector<int> row_index; 
	clock_t start = clock(); 
	int rowNZ; 
	row_index.push_back(0); 
	for (int i = 0; i < N; i++) 
	{ 
		rowNZ = 0; 
		for (int j = 0; j < N; j++) 
		{
			double sum = 0; 
			
			for (int k = A.RowIndex[i]; k < A.RowIndex[i + 1]; k++)
			{
				for (int l = B.RowIndex[j]; l < B.RowIndex[j + 1]; l++)
				{
					if (A.Col[k] == B.Col[l])
					{
						sum +=A.Value[k] * B.Value[l];
						break;
					}
				}
			}

			if (fabs(sum) > ZERO_IN_CRS) 
			{ 
				columns.push_back(j); 
				values.push_back(sum); rowNZ++; 
			} 
		} 
		row_index.push_back(rowNZ + row_index[i]); 
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
	time = (double)(finish - start) / CLOCKS_PER_SEC; 
	return 0; 
}