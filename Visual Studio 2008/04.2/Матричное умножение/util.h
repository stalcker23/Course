void InitializeMatrix(int N, int NZ, crsMatrix &mtx);
void FreeMatrix(crsMatrix &mtx);
int WriteMatrix(crsMatrix mtx, char *fileName);
int ReadMatrix(crsMatrix &mtx, char *fileName);
int SparseDiff(crsMatrix A, crsMatrix B, double &diff);
int SparseMKLMult(crsMatrix A, crsMatrix B, crsMatrix &C, double &time);
void Transpose(crsMatrix A, crsMatrix &AT);