void InitializeMatrix(int N, int NZ, crsMatrix &mtx);
void FreeMatrix(crsMatrix &mtx);
int SparseDiff(crsMatrix A, crsMatrix B, double &diff);
int SparseMKLMult(crsMatrix A, crsMatrix B, crsMatrix &C, double &time);
