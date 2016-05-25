#include <time.h>
#include <stdlib.h>
#include <stdio.h>
#include <math.h>
#include <conio.h>
#include "diffequation.h"

int main() 
{ 
	// ��������� ����������������� ��������� 
	double T = 5.0;
	int m = 5;
	double sigma = 0.3;
	double D = 0.01;
	double K = 100.0;
	double rk_s = 0.015;
	double Ic = 6.0;
	double rf = 0.0253;

	int M = 100;
	int n = 100;
	int J = 8;

	// ���������� ��� ���������� ������� ������� 
	clock_t start, finish;
	double  duration;

	// ����������� ������ ��� ���������� ����������� 
	FILE *fstockprice, *fcbprice; 

	// ��������������� ����������, ����������� ��� 
	// �������� �� zt ���������� � Vt 
	double delta_z; 

	// ���������� ��� ���������� ����������� 
	double *stockprice, *cbprice;

	start = clock();	
	// ���������� ���� �� 
	getprices(T, m, sigma, D, K, rk_s, Ic, rf, M, J, n, &stockprice, &cbprice);
	finish = clock(); 
	
	// ���������� ������� ������ ����������� ���� �� 
	duration = ((double)(finish-start))/
		((double)CLOCKS_PER_SEC); 

	printf("Time = %.5f\n", duration); 
	// �������� ����� ��� ���������� ����������� ���� �� 
	fstockprice = fopen("stockprice.csv", "w+"); 
	if (fstockprice == NULL) 
	{
		printf("File wasn't created\n");
		free(stockprice);
		free(cbprice);
		return -1;
	} 

	// �������� ����� ��� ���������� ���� �� �� ��������� 
	// ������ ��� ���� ��������� ��������� ����� 
	fcbprice = fopen("cbprice.csv", "w+");
	if (fcbprice == NULL) 
	{
		printf("File wasn't created\n");
		free(stockprice);
		free(cbprice);
		return -1;
	} 

	// ������ ����������� ���� �� 
	for (int i = 0; i < n; i++) 
		fprintf(fstockprice, "%lf\n", stockprice[i]); 

	// ������ ��������� ����� � ��������������� ���� �� 
	delta_z = (log(MAXPRICE) - log(MINPRICE)) / J;

	for (int i = 0; i < J + 1; i++) 
		fprintf(fcbprice, "%lf;%lf\n", exp(log(MINPRICE) + i * delta_z), cbprice[i]); 
	// �������� ������ 
	fclose(fstockprice);
	fclose(fcbprice); // ������������ ������, ���������� ��� ���������� 
	free(stockprice);
	free(cbprice);
	_getch();
	return 0; 
}
