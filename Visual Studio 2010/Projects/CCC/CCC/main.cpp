#include <stdio.h> 
#include <stdlib.h>
#include <string.h>
//#include <time.h>
#include <windows.h>
#include "hce_functions.h"
#include "decision.h"
#include "fftw3.h"

// Function that converts numbers form LongInt type to double type
 double LiToDouble (LARGE_INTEGER x) {
	double result = ((double)x.HighPart) * 4.294967296E9 + (double)((x).LowPart);
	return result;
}
// Function that gets the timestamp in seconds
 double GetTime() {
	LARGE_INTEGER lpFrequency, lpPerfomanceCount;
	QueryPerformanceFrequency (&lpFrequency);
	QueryPerformanceCounter (&lpPerfomanceCount);
	return LiToDouble(lpPerfomanceCount) / LiToDouble(lpFrequency);
}

int main(int argc, char *argv[])
{
	if(argc != 3)
	{ 
		printf("Invalid input parameters\n");
		return 1;
	}
	int n = atoi(argv[1]);


void (*SinFT) (double *, double *, int); 
if(strcmp(argv[2], "FST") == 0) SinFT = SinFT_Fast; 
else
	if(strcmp(argv[2], "MKL") == 0) SinFT = SinFT_MKL;
else 
	if(strcmp(argv[2], "FFTW") == 0) SinFT = SinFT_FFTW; 
else 
{ 
	printf("Invalid input parameters\n"); return 1; 
	}
		double *approx = new double[(n - 1) * (n - 1)];

		double start, finish, time;
		start = GetTime();
		ComputeDecision(approx, n, SinFT);
		finish = GetTime();

		time = finish - start; 
		double err = CalculateError(n, approx);

		printf("%s;%d;%.13lf;%.15lf\n", argv[2], n, time, err);

		delete[] approx; 		
		return 0; 
}