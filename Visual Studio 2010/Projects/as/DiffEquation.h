#ifndef DIFFEQUATION_H
	#define  DIFFEQUATION_H
	#define MINPRICE 0.01
	#define MAXPRICE 10000.0
	#define EPS 0.000001
	#define OPERATION_OK 0

	int computecoeff_a(double sigma, double delta_t, double delta_z, double D, double rf, double *a_0, double *a_1, double *a_2);
	int computecoeff_b(double sigma, double delta_t, double delta_z, double D, double rf, double *b_0, double *b_1, double *b_2);
	int rightboundcond(double K, double Ic, double zmin, double delta_z, double rk, double *ck0j, int J, double *res);
	int rightboundcondlast(double K, double Ic, double zmin, double delta_z, double rn, int J, double *res);
	int bottomboundcond(int kind, int m, int n, double step, double K, double rf, double *rfunc, double delta_t, double *cond);
	int topboundcond(int m, double K, double D, double Ic, double delta_t, double step, double zmax, double *cond);
	int getoptimalstockprice(double K, double Ic, double zmin, double step, double *rfunc,double delta_z, double delta_t, int J, int kind, double *c, double *V, int *optindex);
	int matrvecmulti(double b_0, double b_1, double b_2, double *vec, int J, double *res);
	int sweepmethod(double a_0, double a_1, double a_2, double *cb_next, int J, double *x, double *alpha, double *beta);
	double* r(double step, double delta_t, double rk_s, int n, int m);
	int crancknikolson(double T, double m, double sigma, double D, double K, double rk_s, double Ic, double rf, int M, int J, int n, double zmin, double zmax, double **cb_price, double *V);
	int getprices(double T, int m, double sigma, double D, double K, double rk_s, double Ic, double rf, int M, int J, int n, double **stockprice, double **cbprice);

#endif