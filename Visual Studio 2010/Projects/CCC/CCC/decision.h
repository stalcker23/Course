#include <string>
#include <cmath>

using namespace std;

#define PI (3.14159265358979323846)

void ComputeDecision(double *approx, int n, void (*SinFT) (double *, double *, int));
void FFT_MKL(double *inputSignal, double *outputSignal,int n);
void SinFT_MKL(double *input, double *output, int n);
void SinFT_Fast(double *input, double *output, int n);
void SinFT_FFTW(double *input, double *output, int n);
void FFT_FFTW(double *inputSignal, double *outputSignal, int n);
