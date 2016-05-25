#include <stdio.h>
#include <conio.h>
#include <stdlib.h>
#include <time.h>
#include "windows.h"
#include <string>
#include "routine.cpp"
#include "FloydWarshall.h"
#include <omp.h>
#pragma comment(linker, "/STACK:500000")
using namespace std;

double LiToDouble (LARGE_INTEGER x) {
	double result = ((double)x.HighPart) * 4.294967296E9 + (double)((x).LowPart);
	return result;
}

double GetTime() {
	LARGE_INTEGER lpFrequency, lpPerfomanceCount;
	QueryPerformanceFrequency (&lpFrequency);
	QueryPerformanceCounter (&lpPerfomanceCount);
	return LiToDouble(lpPerfomanceCount)/LiToDouble(lpFrequency);
}
void Way(int *up, int i, int j, int Size)
{
	
	    int k = up[i * Size + j];	
		if (k != i) // путь существует
		{
			// и состоит более чем из двух вершин и проходит через вершину k, поэтому
			Way(up, i, k, Size); // рекурсивно восстанавливаем путь между вершинами i и k
			printf("%d ", k); // выводим вершину k
			Way(up, k, j, Size); // и рекурсивно восстанавливаем путь между k и j	
		}
}

int main()
{
	GraphMatrix *gr;			
	int *dist;
	int *up;
	double Start, Finish, Duration;
	bool printOutput = true;

	ParseGraph("rome99.txt", &gr);
	
	dist = new int[gr->sizeV * gr->sizeV];
	up = new int[gr->sizeV * gr->sizeV];

	Start = GetTime();
	FloydWarshall(gr, up, dist);
	Finish = GetTime();
	Way(up, 1, 2, 3353);
	Duration = Finish - Start;
	printf("Floyd-Warshall time: %f\n", Duration);

	if (printOutput)
	{
		FILE *distFile = fopen("distFile.txt", "w");
		FILE *pFile = fopen("pFile.txt", "w");
		for (int i = 0; i < gr->sizeV; i++)
		{
			for (int j = 0; j < gr->sizeV; j++)
			{
				fprintf(distFile, "%d ", dist[i * gr->sizeV + j]);
				fprintf(pFile, "%d", up[i * gr->sizeV + j]);
			}
			fprintf(distFile, "\n");
			fprintf(pFile, "\n");
		}

		printf("File %s.txt written.\nFile %s.txt written.\n", "distFile", "pFile");

		fclose(distFile);
		fclose(pFile);
	}
	
	delete[] gr->column;
	delete[] gr->pointerB;
	delete[] gr->value;
	delete gr;
	delete [] dist;
	delete [] up;
	_getch();
	return 0;
}