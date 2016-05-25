#include <iomanip> 
#include <iostream>
#include <cmath>
#include <complex>
#include <time.h>
#include <conio.h>
#include <windows.h>
using namespace std; 
#define PI (3.14159265358979323846)

double LiToDouble (LARGE_INTEGER x)
{
	double result =
		((double)x.HighPart) * 4.294967296E9 + (double)((x).LowPart);
	return result;
}
// Function that gets the timestamp in seconds
double GetTime()
{
	LARGE_INTEGER lpFrequency, lpPerfomanceCount;
	QueryPerformanceFrequency (&lpFrequency);
	QueryPerformanceCounter (&lpPerfomanceCount);
	return LiToDouble(lpPerfomanceCount)/LiToDouble(lpFrequency);
}

//Function for simple initialization of input signal elements
void DummyDataInitialization(complex<double>* mas, int size) 
{ 
	for(int i = 0; i < size; i++) 
		mas[i] = 0; 
	mas[size - size / 4] = 1; 
}

// Function for random initialization of objects' elements 
void RandomDataInitialization(complex<double>* mas, int size) 
{ 
	srand(unsigned(clock())); 
	for(int i = 0; i < size; i++)
		mas[i] = complex<double>(rand() / 1000.0, rand() / 1000.0);
}

//Function for memory allocation and data initialization
void ProcessInitialization(complex<double>* &inputSignal,
						   complex<double>* &outputSignal, 
						   int &size) 
{ 
	// Setting the size of signals 
	do 
	{
		cout << "Enter the input signal length: "; 
		cin >> size; 
		if(size < 4) 
			cout << "Input signal length should be >= 4" << endl;
		else
		{ 
			int tmpSize = size; 
			while (tmpSize != 1) 
			{
				if (tmpSize % 2 != 0) 
				{ 
					cout << "Input signal length should be powers of two" << endl; 
					size = -1; 
					break; 
				} 
				tmpSize /= 2;
			}
		} 
	} 
	while(size < 4); 
	cout << "Input signal length = " << size << endl;

	inputSignal = new complex<double>[size]; 
	outputSignal = new complex<double>[size]; 

	DummyDataInitialization(inputSignal, size);
	//RandomDataInitialization(inputSignal, size);
}

//Function for computational process temination
void ProcessTermination(complex<double>* &inputSignal, 
						complex<double>* &outputSignal) 
{ 
	delete [] inputSignal; 
	inputSignal = NULL; 
	delete [] outputSignal; 
	outputSignal = NULL; 
}

//void BitReversing(complex<double> *inputSignal, 
//				  complex<double> *outputSignal,
//				  int size) 
//{ 
//	int j = 0, i = 0; 
//	while (i < size) 
//	{ 
//		if (j > i) 
//		{ 
//			outputSignal[i] = inputSignal[j];
//			outputSignal[j] = inputSignal[i]; 
//		} 
//		else 
//			if (j == i) 
//				outputSignal[i] = inputSignal[i]; 
//		int m = size >> 1; 
//		while ((m >= 1) && (j >= m)) 
//		{ 
//			j -= m ; 
//			m = m >> 1; 
//		} 
//		j += m; 
//		i ++; 
//	} 
//}

void BitReversing(complex<double> *inputSignal, complex<double> *outputSignal, int size) 
{
	int bitsCount = 0;
	
	//bitsCount = log2(size)
	for (int tmp_size = size; tmp_size > 1; tmp_size /= 2, bitsCount++);

	//ind - index in input array
	//revInd - correspondent to ind index in output array

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
		outputSignal[revInd] = inputSignal[ind];		
	}	
}


__inline void Butterfly(complex<double> *signal,
						complex<double> &u, int offset, int butterflySize) 
{ 
	complex<double> tem = signal[offset + butterflySize] * u; 
	signal[offset + butterflySize] = signal[offset] - tem; 
	signal[offset] += tem; 
}

void SerialFFTCalculation(complex<double> *signal, int size) 
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
void SerialFFT(complex<double> *inputSignal, complex<double> *outputSignal, int size) 
{ 
	BitReversing(inputSignal, outputSignal, size); 
	SerialFFTCalculation(outputSignal, size); 
}

void PrintSignal(complex<double> *signal, int size) 
{ 
	cout << "Result signal" << endl; 
	for (int i = 0; i < size; i++) 
		cout << signal[i] << endl; 
}

int main()
{
	complex<double> * inputSignal = NULL;
	complex<double> * outputSignal = NULL;

	int size = 0;

	//const int repeatCount = 16;
	double start, finish, duration;
	//double minDuration = DBL_MAX;

	cout << "Fast Fourier Transform" << endl;				// Serial version

	//Memory allocation and data initialization
	ProcessInitialization(inputSignal, outputSignal, size);

	//for (int i = 0; i < repeatCount; i++)
	//{
		//start = GetTime();
		// FFT computation
		SerialFFT(inputSignal, outputSignal, size);
		//finish = GetTime(); 
		//duration = finish - start;

		//if (duration < minDuration)
		//	minDuration = duration;

	//}
	//cout << setprecision(6);
	//cout << "Execution time is "  << minDuration << " s. " << endl;

	//Result signal output
	PrintSignal(outputSignal, size);

	//Computational process terination
	ProcessTermination(inputSignal, outputSignal);
	_getch();
	return 0;
}