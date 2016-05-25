#include "sparse.h"
#include "util.h"
#include <stdlib.h>
#include <time.h>
#include <vector>
#include <cmath>
using namespace std;
const double ZERO_IN_CRS = 0.000001; 
int Multiplicate(crsMatrix A, crsMatrix B, crsMatrix &C, double &time) { if (A.N != B.N) return 1; int N = A.N; int i, j, k; vector<int> columns; vector<double> values; vector<int> row_index; clock_t start = clock(); int NZ = 0; int *temp = new int[N];
row_index.push_back(0);
for (i = 0; i < N; i++) {
	memset(temp, -1, N * sizeof(int));
int ind1 = A.RowIndex[i], ind2 = A.RowIndex[i + 1]; for (j = ind1; j < ind2; j++) { int col = A.Col[j]; temp[col] = j;
}
for (j = 0; j < N; j++) {
	double sum = 0; int ind3 = B.RowIndex[j], ind4 = B.RowIndex[j + 1];
for (k = ind3; k < ind4; k++) { int bcol = B.Col[k]; int aind = temp[bcol];
if (aind != -1) sum += A.Value[aind] * B.Value[k]; } if (fabs(sum) > ZERO_IN_CRS) { columns.push_back(j); values.push_back(sum); NZ++; } } row_index.push_back(NZ); } InitializeMatrix(N, NZ, C); for (j = 0; j < NZ; j++) { C.Col[j] = columns[j]; C.Value[j] = values[j]; } for(i = 0; i <= N; i++) C.RowIndex[i] = row_index[i]; delete [] temp; clock_t finish = clock(); time = (double)(finish - start) / CLOCKS_PER_SEC; return 0; }