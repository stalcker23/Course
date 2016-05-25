#include <time.h>
#include <stdlib.h>
#include <stdio.h>
#include <math.h>
#include <conio.h>
#include "diffequation.h"

int main() 
{ 
	// параметры дифференциального уравнения 
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

	// переменные для сохранения замеров времени 
	clock_t start, finish;
	double  duration;

	// дескрипторы файлов для сохранения результатов 
	FILE *fstockprice, *fcbprice; 

	// вспомогательная переменная, необходимая для 
	// перехода от zt переменной к Vt 
	double delta_z; 

	// переменные для сохранения результатов 
	double *stockprice, *cbprice;

	start = clock();	
	// вычисление цены КО 
	getprices(T, m, sigma, D, K, rk_s, Ic, rf, M, J, n, &stockprice, &cbprice);
	finish = clock(); 
	
	// вычисление времени поиска оптимальной цены КО 
	duration = ((double)(finish-start))/
		((double)CLOCKS_PER_SEC); 

	printf("Time = %.5f\n", duration); 
	// создание файла для сохранения оптимальной цены КО 
	fstockprice = fopen("stockprice.csv", "w+"); 
	if (fstockprice == NULL) 
	{
		printf("File wasn't created\n");
		free(stockprice);
		free(cbprice);
		return -1;
	} 

	// создание файла для сохранения цены КО на начальной 
	// стадии при всех значениях стоимости акции 
	fcbprice = fopen("cbprice.csv", "w+");
	if (fcbprice == NULL) 
	{
		printf("File wasn't created\n");
		free(stockprice);
		free(cbprice);
		return -1;
	} 

	// запись оптимальной цены КО 
	for (int i = 0; i < n; i++) 
		fprintf(fstockprice, "%lf\n", stockprice[i]); 

	// запись стоимости акции и соответствующей цены КО 
	delta_z = (log(MAXPRICE) - log(MINPRICE)) / J;

	for (int i = 0; i < J + 1; i++) 
		fprintf(fcbprice, "%lf;%lf\n", exp(log(MINPRICE) + i * delta_z), cbprice[i]); 
	// закрытие файлов 
	fclose(fstockprice);
	fclose(fcbprice); // освобождение памяти, выделенной под результаты 
	free(stockprice);
	free(cbprice);
	_getch();
	return 0; 
}
