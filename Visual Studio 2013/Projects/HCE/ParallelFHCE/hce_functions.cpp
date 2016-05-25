#include "hce_functions.h"

// Uxx + Uyy = -f(x,y)
// Функция вычисления правой части ДУ в ЧП 
double f(double x, double y)
{
	return 2.0 * L * (y + x) - 2 * (x * x + y * y);
}
// Функция, задающая точное решение дифференциального 
// уравнения
double u_(double x, double y)
{
	return x * y * (L - x) * (L - y);
}
double CalculateError(int n, double * approx)
{
	double h = L / n;
	double max_err = 0;
	for (int i = 0; i < n - 1; i++)
		for (int j = 0; j < n - 1; j++)
		{
			double cur_err = fabs(approx[i * (n - 1) + j] - u_((i + 1) * h, (j + 1) * h));
			if (cur_err > max_err)
				max_err = cur_err;
		}
	return max_err;
}