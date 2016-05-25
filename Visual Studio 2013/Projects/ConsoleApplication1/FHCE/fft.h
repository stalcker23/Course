#include <cmath>
#include <complex>

using namespace std;

#define PI (3.14159265358979323846)

void BitReversing(double *inputSignal, double *outputSignal, int size) ;
void Butterfly(double *signal, complex<double> &u, int offset, int butterflySize);
void SerialFFTCalculation(double *signal, int size);
void SerialFFT1D(double *inputSignal, double *outputSignal, int size);