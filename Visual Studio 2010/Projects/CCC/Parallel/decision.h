#include <string>
#include <cmath>

using namespace std;

#define PI (3.14159265358979323846)

void ComputeDecision(double *approx, int n, void (*SinFT) (double *, double *, int), int);
void SinFT_MKL(double *input, double *output, int n);
void FFT_MKL(double *inputSignal, double *outputSignal,int n);
void FFT_FFTW(double *inputSignal, double *outputSignal, int n);