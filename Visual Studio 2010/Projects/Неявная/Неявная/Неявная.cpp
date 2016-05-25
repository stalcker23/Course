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


 outfile<<"������� �������� L = "<<L<<endl;
 outfile<<"����� ����� �� ���������� N = "<<N<<endl;
 outfile<<"����������� ���������������� ��������� �������� lamda = "<<lamda<<endl; 
 outfile<<"��������� ��������� �������� ro = "<<ro<<endl;
 outfile<<"������������ ��������� �������� � = "<<c<<endl;
 outfile<<"��������� ����������� T0 = "<<T0<<endl;
 outfile<<"����������� �� ������� x = 0, Tl = "<<Tl<<endl;
 outfile<<"����������� �� ������� x = L, Tr = "<<Tr<<endl;
 outfile<<"��������� ������� � ����� �� ���������� h = "<<h<<endl;
 outfile<<"��������� ������� � ����� �� ������� tau = "<<tau<<endl;
 outfile<<"������������� ���� � ������ ������� t = "<<t_end<<endl;

for (i=1; i<= N ;i++)
outfile<<" "<<h*(i-1)<<" "<<T[i]<<endl;
return 0;
}


