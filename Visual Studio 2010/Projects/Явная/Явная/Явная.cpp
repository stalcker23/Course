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
double T[500], TT[500];
double a, lamda, ro, c, h, tau;
double Tl, T0, Tr, L, t_end, time ;
 infile>>N;
 infile>>t_end;
 infile>>L;
 infile>>lamda;
 infile>>ro;
 infile>>c;
 infile>>T0;
 infile>>Tl;
 infile>>Tr;


 a=lamda/(ro*c);

h=L/(N-1); 

 tau=0.25*(h*h)/a;
for (i=2; i<= N-1;i++)
 T[i]=T0;

 T[1]=Tl;
 T[N]=Tr;


 time=0;
 while (time<t_end)
 {

 time=time+tau;

 for (i=1; i<= N;i++)
 TT[i]=T[i];

 for (i=2; i<= N-1;i++)
 T[i]=TT[i]+a*tau/(h*h)*(TT[i+1]-2.0*TT[i]+TT[i-1]);
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


