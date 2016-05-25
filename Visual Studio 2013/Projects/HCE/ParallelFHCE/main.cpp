#include <stdio.h> 
#include <stdlib.h>
#include <string.h>
#include <time.h>
#include "hce_functions.h"
#include "decision.h"

int main(int argc, char *argv[])
{
	if (argc != 4)
	{
		printf("Invalid input parameters\n");
		return 1;
	}
	int n = atoi(argv[1]);

	void(*SinFT) (double *, double *, int);

	if (strcmp(argv[2], "MKL") == 0)
		SinFT = SinFT_MKL;
	else
		if (strcmp(argv[2], "FST") == 0)
			SinFT = SinFT_Fast;
		else
			if (strcmp(argv[2], "FFTW") == 0)
				SinFT = SinFT_FFTW;
			else
			{
				printf("Invalid input parameters\n");
				return 1;
			}
	int num_threads = atoi(argv[3]);

	double *approx = new double[(n - 1) * (n - 1)];

	clock_t start = clock();
	ComputeDecision(approx, n, SinFT, num_threads);
	clock_t finish = clock();

	double time = (double)(finish - start) / CLOCKS_PER_SEC;
	double err = CalculateError(n, approx);

	printf("%s;%d;%.3lf;%.15lf\n", argv[2], n, time, err);

	delete[] approx;

	return 0;
}