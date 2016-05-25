#include "diffequation.h"
#include <math.h>
#include <stdlib.h>

int computecoeff_a(double sigma, double delta_t, double delta_z, double D, double rf, double *a_0, double *a_1, double *a_2) 
{ 
	double sqsigma = sigma * sigma; 
	double sqdeltaz = delta_z * delta_z;
	(*a_0) = (sqsigma / (4.0 * sqdeltaz) - (rf - D - sqsigma * 0.5) / (4.0 * delta_z)) * delta_t;
	(*a_1) = -1.0 - (sqsigma / (2.0 * sqdeltaz) + rf * 0.5) * delta_t;
	(*a_2) = (sqsigma / (4.0 * sqdeltaz) + (rf - D - sqsigma * 0.5) / (4.0 * delta_z)) * delta_t;
	return 0;
}

int computecoeff_b(double sigma, double delta_t, double delta_z, double D, double rf, double *b_0, double *b_1, double *b_2) 
{
	double sqsigma = sigma * sigma;
	double sqdeltaz = delta_z * delta_z;
	(*b_0) = (-sqsigma / (4.0 * sqdeltaz) + (rf - D - sqsigma * 0.5) / (4.0 * delta_z)) * delta_t;
	(*b_1) = -1.0 + (sqsigma / (2.0 * sqdeltaz) + rf * 0.5) * delta_t;
	(*b_2) = (sqsigma / (4.0 * sqdeltaz) + (rf - D - sqsigma * 0.5) / (4.0 * delta_z)) * (-delta_t);
	return 0;
}

int rightboundcond(double K, double Ic, double zmin, double delta_z, double rk, double *ck0j, int J, double *res) 
{ 
	int i;
	double coeff1, coeff2, fe, se, step;
	coeff1 = K * rk;
	coeff2 = K / Ic;
	for (i = 0; i < J + 1; i++) 
	{ step = zmin + i * delta_z; fe = coeff1 + ck0j[i]; se = coeff2 * exp(step);
	res[i] = (fe > se) ? fe : se; } 
	return 0; 
} 

int rightboundcondlast(double K, double Ic, double zmin, double delta_z, double rn, int J, double *res) 
{
	int i;
	double fe, se, coeff;
	fe = K * (1.0 + rn);
	coeff = K / Ic;
	for (i = 0; i < J + 1; i++) 
	{ se = coeff * exp(zmin + i * delta_z);
	res[i] = (fe > se) ? fe : se; } 
	return 0; 
}

int bottomboundcond(int kind, int m, int n, double step, double K, double rf, double *rfunc, double delta_t, double *cond) 
{
	int l;
	double coeff, term;
	coeff = K * exp((-1.0) * rf * (step - m * delta_t));
	term = exp((-1.0) * rf * (n - kind - 1) * step);
	*cond = 0.0;
	for (l = 0; l < n - kind; l++) *cond += (rfunc[kind + l + 1]*exp(-rf * l * step));
	(*cond) += term;
	(*cond) *= coeff;
	return 0;
}

int topboundcond(int m, double K, double D, double Ic, double delta_t, double step, double zmax, double *cond) 
{
	(*cond) = K * exp(zmax - D * (step - m * delta_t))/Ic;
	return 0;
}

int getoptimalstockprice(double K, double Ic, double zmin, double step, double *rfunc,double delta_z, double delta_t, int J, int kind, double *c, double *V, int *optindex) 
{
	int i, index;
	double gkj, rk, coeff, tmp, min;
	rk = rfunc[kind];
	coeff = K * rk;
	tmp = K / Ic;
	min = fabs(coeff + c[0] - tmp * exp(zmin));
	index = 0;
	for (i = 1; i < J; i++) 
	{ gkj = fabs(coeff+c[i]-tmp*exp(zmin+i*delta_z)); if (gkj < min) {min = gkj; index = i; } }
	*V = exp(zmin + index * delta_z);
	*optindex = index;
	return 0;
}

int matrvecmulti(double b_0, double b_1, double b_2, double *vec, int J, double *res)
{ 
	int i;
	for (i = 0; i < J - 1; i++) res[i] = b_0*vec[i] + b_1*vec[i+1] + b_2*vec[i+2];
	return 0; 
}

int sweepmethod(double a_0, double a_1, double a_2, double *cb_next, int J, double *x, double *alpha, double *beta) 
{
	int size, i;
	double denominator;
	size = J - 1; // прямой ход метода прогонки 
	alpha[1] = -a_2 / a_1;
	beta[1] = cb_next[0] / a_1;
	for (i = 1; i < size - 1; i++)
	{ denominator = a_0 * alpha[i] + a_1; alpha[i + 1] = -a_2 / denominator;
	beta[i + 1] = (cb_next[i] - a_0 * beta[i]) / denominator; } // обратный ход метода прогонки
	x[size - 1] = (-a_0 * beta[size - 1] + cb_next[size - 1]) / ( a_1 + a_0 * alpha[size - 1]);
	for (i = size - 2; i >= 0; i--) 
	{ x[i] = alpha[i + 1] * x[i + 1] + beta[i + 1]; } 
	
	return OPERATION_OK; 
}

double* r(double step, double delta_t, double rk_s, int n, int m) 
{
	int i, j;
	double *r = (double *)malloc(sizeof(double) * (n + 1));
	for (i = 0; i <= n; i++) r[i] = 0.0; 
	for (i = 0; i <= n; i++) 
		for (j = 1; j <= m; j++) 
			if (fabs(i * step - j) < EPS) r[i] = rk_s;
	return r; 
}

int crancknikolson(double T, int m, double sigma, 
				   double D, double K, double rk_s, double Ic, double rf, 
				   int M, int J, int n, double zmin, double zmax, 
				   double **cb_price, double *V) 
{
	int kind, i, optindex;
	double a_0, a_1, a_2, b_0, b_1, b_2;
	double delta_t, delta_z, step, rn, rk, *cb_next;
	double topborder, bottomborder, *x_next, *rfunc, *alpha, *beta;
	cb_next = (double *)malloc(sizeof(double) * (J + 1));
	x_next = (double *)malloc(sizeof(double) * (J + 1));
	delta_z = (zmax - zmin) / J;// шаг по J 
	step = T / ((double) n); // шаг по времени на всем T 
	delta_t = step / ((double) M); // шаг по времени в 
								// малом интервале

	// вычисление коэффициентов 
	computecoeff_a(sigma, delta_t, delta_z, D, rf, &a_0, &a_1, &a_2); 
	computecoeff_b(sigma, delta_t, delta_z, D, rf, &b_0, &b_1, &b_2);

	// вычисление значений r 
	rfunc = r(step, delta_t, rk_s, n, m);

	// вычисление на последней стадии 
	rn = rfunc[n]; // получение rn 
	rightboundcondlast(K, Ic, zmin, delta_z, rn, J, x_next); // правое ГУ (23) размерность (J + 1) 
	alpha = (double *)malloc(sizeof(double) * (J - 1));
	beta = (double *)malloc(sizeof(double) * (J - 1)); 

	// проход по всем стадиям 
	for (kind = n - 1; kind >= 0; kind--) 
	{ 
		rk = rfunc[kind]; // получение значения rk

		// проход по разбиению малого интервала 
		for (i = M; i > 0; i--) 
		{ 
			// вычисление произведения 
			// B * x_next = cb_next (J - 1) 
			matrvecmulti(b_0, b_1, b_2, x_next, J, cb_next);

			// вычисление верхнего ГУ 
			topboundcond(i, K, D, Ic, delta_t, step, zmax, &topborder); 

			// вычисление нижнего ГУ 
			bottomboundcond(kind, i, n, step, K, rf, rfunc, delta_t, &bottomborder);

			// вычитание нижнего ГУ из первой компоненты 
			// cb_next 
			cb_next[0] -= (a_0 * bottomborder); 
			
			// вычитание верхнего ГУ из последней 
			// компоненты cb_next 
			cb_next[J - 2] -= (a_2 * topborder); 

			// запуск метода прогонки для 
			// A * x_next = cb_next 
			sweepmethod(a_0, a_1, a_2, cb_next, J, x_next + 1, alpha, beta); 
		} 
		
		// вычисление оптимальной цены 
		getoptimalstockprice(K, Ic, zmin, step, rfunc, delta_z, delta_t, J, kind, x_next, &(V[kind]), &optindex); // вычисление правого ГУ на малом интервале 
		rightboundcond(K, Ic, zmin, delta_z, rfunc[kind], x_next, J, x_next);
	} 
	*cb_price = x_next;
	free(cb_next);
	free(rfunc);
	free(alpha);
	free(beta);
	return OPERATION_OK;
}

int getprices(double T, int m, double sigma, double D, double K, double rk_s, double Ic, double rf, int M, int J, int n, double **stockprice, double **cbprice)
{
	double zmin, zmax; 
	zmin = log(MINPRICE); 
	zmax = log(MAXPRICE); 
	*stockprice = (double *)malloc(sizeof(double) * n); 
	crancknikolson(T, m, sigma, D, K, rk_s, Ic, rf, M, J, n, zmin, zmax, cbprice, *stockprice); 
	return 0; 
}