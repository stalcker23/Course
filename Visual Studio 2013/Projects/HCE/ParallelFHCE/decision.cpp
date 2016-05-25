#include "fft.h"
#include "decision.h"
#include "hce_functions.h"
#include "omp.h"


void ComputeDecision(double *approx, int n, void(*SinFT)(double *, double *, int),
	int numThreads)
{
	omp_set_num_threads(numThreads);
	double h = L / n;
	double **f_four = new double*[n - 1];
	for (int i = 0; i < n - 1; i++)
		f_four[i] = new double[n - 1];
	double mult1 = sqrt(2.0 / L);

	// вычисление коэффициентов Фурье 
	// для векторов правых частей
#pragma omp parallel for
	for (int i = 0; i < n - 1; i++)
	{
		for (int j = 0; j < n - 1; j++)
			approx[i * (n - 1) + j] = f((i + 1) * h, (j + 1) * h) * mult1 * h;
		(*SinFT)(&approx[i * (n - 1)], f_four[i], n);
		for (int j = 0; j < n - 1; j++)
			f_four[i][j] = -f_four[i][j];
	}

	// транспонирование матрицы с коэффициентами
#pragma omp parallel for
	for (int i = 0; i < n - 1; i++)
	{
		for (int j = i + 1; j < n - 1; j++)
		{
			double tmp = f_four[i][j];
			f_four[i][j] = f_four[j][i];
			f_four[j][i] = tmp;
		}
	}

	double **dl = new double*[numThreads];
	double **d = new double*[numThreads];
	double **du = new double*[numThreads];
	for (int i = 0; i < numThreads; i++)
	{
		dl[i] = new double[n - 2];
		d[i] = new double[n - 1];
		du[i] = new double[n - 2];
	}

	double sudiag_val = 1.0 / (h * h);

#pragma omp parallel for
	for (int k = 0; k < n - 1; k++)
	{
		int tid = omp_get_thread_num();
		// инициализация трехдиагональной матрицы 
		for (int i = 0; i < n - 2; i++)
		{
			dl[tid][i] = sudiag_val;
			du[tid][i] = sudiag_val;
		}
		double tmp = sin(PI * (k + 1) / (2 * n));
		double l_k = 4 / (h * h) * tmp * tmp;
		double diag_val = -l_k - 2.0 / (h * h);
		for (int i = 0; i < n - 1; i++)
			d[tid][i] = diag_val;
		// вычисление LU разложения матрицы и решение системы
		int info;
		int N = n - 1;
		ddttrfb(&N, dl[tid], d[tid], du[tid], &info);
		char trans = 'N';
		int nrhs = 1;
		int ldb = N;
		ddttrsb(&trans, &N, &nrhs, dl[tid], d[tid], du[tid], f_four[k], &ldb, &info);
	}

	for (int i = 0; i < numThreads; i++)
	{
		delete[] dl[i];
		delete[] d[i];
		delete[] du[i];
	}

	delete[] dl;
	delete[] d;
	delete[] du;

	// транспонирование матрицы с коэффициентами
#pragma omp parallel for
	for (int i = 0; i < n - 1; i++)
	{
		for (int j = i + 1; j < n - 1; j++)
		{
			double tmp = f_four[i][j];
			f_four[i][j] = f_four[j][i];
			f_four[j][i] = tmp;
		}
	}
	// вычисление значений искомой функции
	// по коэффициентам Фурье
#pragma omp parallel for
	for (int i = 0; i < n - 1; i++)
	{
		for (int j = 0; j < n - 1; j++)
			f_four[i][j] *= mult1;
		(*SinFT)(f_four[i], &approx[i * (n - 1)], n);
	}
	for (int i = 0; i < n - 1; i++)
		delete[] f_four[i];
	delete[] f_four;
}

void FFT_MKL(double *inputSignal, double *outputSignal, int n)
{
	DFTI_DESCRIPTOR_HANDLE handle;
	MKL_LONG status;
	status = DftiCreateDescriptor(&handle, DFTI_DOUBLE, DFTI_REAL, 1, n);
	status = DftiSetValue(handle, DFTI_PLACEMENT, DFTI_NOT_INPLACE);
	status = DftiCommitDescriptor(handle);
	status = DftiComputeForward(handle, inputSignal, outputSignal);
	int k = n / 2;
	if (n % 2 != 0)
	{
		k++;
	}
	for (int i = n / 2 + 1; i < n; i++)
	{
		k--;
		outputSignal[2 * i] = outputSignal[2 * k];
		outputSignal[2 * i + 1] = (-1) * outputSignal[2 * k + 1];
	}
	status = DftiFreeDescriptor(&handle);
}
void SinFT_Fast(double *input, double *output, int n)
{
	double *inputSignal = new double[4 * n];
	memset(inputSignal, 0, sizeof(double) * 4 * n);
	double *outputSignal = new double[4 * n];
	for (int i = 1; i < n; i++)
		inputSignal[2 * i] = input[i - 1];
	SerialFFT1D(inputSignal, outputSignal, 2 * n);
	for (int i = 1; i < n; i++)
		output[i - 1] = outputSignal[2 * i + 1];
	delete[] inputSignal;
	delete[] outputSignal;
}

void SinFT_MKL(double *input, double *output, int n)
{
	double *inputSignal = new double[2 * n];
	memset(inputSignal, 0, sizeof(double) * 2 * n);
	double *outputSignal = new double[4 * n];
	for (int i = 1; i < n; i++) inputSignal[i] = input[i - 1];
	FFT_MKL(inputSignal, outputSignal, 2 * n);
	for (int i = 1; i < n; i++) output[i - 1] = outputSignal[2 * i + 1];
	delete[] inputSignal;
	delete[] outputSignal;
}
void FFT_FFTW(fftw_complex *inputSignal, fftw_complex * outputSignal, int n)
{
	fftw_plan p1 = fftw_plan_dft_1d(n, inputSignal, outputSignal, FFTW_FORWARD, FFTW_ESTIMATE);
	fftw_execute(p1);
	fftw_destroy_plan(p1);
}
void SinFT_FFTW(double *input, double *output, int n)
{
	fftw_complex* inputSignal = (fftw_complex*)fftw_malloc(sizeof(fftw_complex) * 2 * n);
	fftw_complex* outputSignal = (fftw_complex*)fftw_malloc(sizeof(fftw_complex) * 2 * n);
	memset(inputSignal, 0, sizeof(fftw_complex) * 2 * n);
	for (int i = 1; i < n; i++) inputSignal[i][0] = input[i - 1];
	FFT_FFTW(inputSignal, outputSignal, 2 * n);
	for (int i = 1; i < n; i++) output[i - 1] = outputSignal[i][1]; fftw_free(inputSignal);
	fftw_free(outputSignal);
}