#include "fft.h"

void BitReversing(double *inputSignal, double *outputSignal, int size) 
{
	int bitsCount = 0;
	
	//bitsCount = log2(size)
	for (int tmp_size = size; tmp_size > 1; tmp_size /= 2, bitsCount++);

	//ind - index in input array
	//revInd - in output array corresponds to ind index 

	for (int ind = 0; ind < size; ind++)
	{
		int mask = 1 << (bitsCount - 1);
		int revInd = 0;
		for (int i = 0; i < bitsCount; i++) //bit-reversing
		{
			bool val = ind & mask;
			revInd |= val << i;
			mask = mask >> 1;
		}
		outputSignal[2 * revInd] = inputSignal[2 * ind];
		outputSignal[2 * revInd + 1] = inputSignal[2 * ind + 1];
	}	
}

__inline void Butterfly(double *signal, complex<double> &u, 
						int offset, int butterflySize) 
{ 
	double temI, temR;
	temR = signal[2 * (offset + butterflySize)] * u.real() - signal[2 * (offset + butterflySize) + 1] * u.imag();
	temI = signal[2 * (offset + butterflySize)] * u.imag() + signal[2 * (offset + butterflySize) + 1] * u.real();
	
	
	signal[2 * (offset + butterflySize)] = signal[2 * offset] - temR;
	signal[2 * (offset + butterflySize) + 1] = signal[2 * offset + 1] - temI;

	signal[2 * offset] += temR;
	signal[2 * offset + 1] += temI;
}

void SerialFFTCalculation(double *signal, int size) 
{ 
	int m = 0; 
	for (int tmp_size = size; tmp_size > 1; tmp_size /= 2, m++); 
		for (int p = 0; p < m; p++) 
		{ 
			int butterflyOffset = 1 << (p + 1); 
			int butterflySize = butterflyOffset >> 1; 
			double coeff = PI / butterflySize; 
			for (int i = 0; i < size / butterflyOffset; i++) 
				for (int j = 0; j < butterflySize; j++)
					Butterfly(signal, complex<double>(cos(-j * coeff), sin(-j * coeff)), j + i * butterflyOffset, butterflySize); 
		} 
}

// FFT computation 
void SerialFFT1D(double *inputSignal, double *outputSignal, int size) 
{ 
	BitReversing(inputSignal, outputSignal, size); 
	SerialFFTCalculation(outputSignal, size); 
}