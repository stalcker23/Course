#include <iostream>
#include  <cmath>
#include <stdio.h>
#include <fstream>
#include<iomanip>

using namespace std  ;
ifstream infile("input.txt");
ofstream outfile("output.txt");
int main()
{
	setlocale(LC_ALL, "Russian");



 int i, N ;
double T[500], alfa[500], beta[500];
double ai, bi, ci, fi;
double lamda, ro, c, h, tau;
double Tl, T0, Tr, L, t_end, time;
 infile>>N;
 infile>>t_end;
 infile>>L;
 infile>>lamda;
 infile>>ro;
 infile>>c;
 infile>>T0;
 infile>>Tl;
 infile>>Tr;

 h=L/(N-1);
 tau=t_end/100;
 for (i=1; i<=N;i++)
 T[i]=T0;

 time=0;
 while (time<t_end)
 {
 time=time+tau;
 alfa[1]=0;
 beta[1]=Tl;
 for (i=2; i<= N-1;i++)
 {

 ai=lamda/(h*h);
 bi=2*lamda/(h*h)+ro*c/tau;
 ci=lamda/(h*h);
 fi=-ro*c*T[i]/tau;

 alfa[i]=ai/(bi-ci*alfa[i-1]);
 beta[i]=(ci*beta[i-1]-fi)/(bi-ci*alfa[i-1]);
 }

 T[N]=Tr;

 for (i= N-1; i>0 ;i--)
 T[i]=alfa[i]*T[i+1]+beta[i];
 }


 outfile<<"Толщина пластины L = "<<L<<endl;
 outfile<<"Число узлов по координате N = "<<N<<endl;
 outfile<<"Коэффициент теплопроводности материала пластины lamda = "<<lamda<<endl; 
 outfile<<"Плотность материала пластины ro = "<<ro<<endl;
 outfile<<"Теплоемкость материала пластины с = "<<c<<endl;
 outfile<<"Начальная температура T0 = "<<T0<<endl;
 outfile<<"Температура на границе x = 0, Tl = "<<Tl<<endl;
 outfile<<"Температура на границе x = L, Tr = "<<Tr<<endl;
 outfile<<"Результат получен с шагом по координате h = "<<h<<endl;
 outfile<<"Результат получен с шагом по времени tau = "<<tau<<endl;
 outfile<<"Температурное поле в момент времени t = "<<t_end<<endl;

for (i=1; i<= N ;i++)
outfile<<" "<<h*(i-1)<<" "<<T[i]<<endl;
return 0;
}


