#include<iostream>
#include<cstdio>
#include<vector>
#include<list>
#include<algorithm>
#include<stack>
using namespace std;
int power(int a, int n)
{
	if(n==0)return 1;
	if(n==1) return a;
	return a*power(a,n-1);
}
int numberSwapper(int a)
	{
		int n=0;
		int i=1;
		stack<int> temp;
	while(a!=0)
	{
		
		temp.push(a%10);
		a/=10;
		i++;
	}
i--;
for(int tempi=0;tempi<i;tempi++)
{
n+=temp.top()*power(10,i-tempi);

}
return n;

	}
int main()
{
	
	freopen("input.txt","r",stdin);
	freopen("output.txt","w",stdout);
	list<int> a;
	
	int n;
	while(cin>>n)
		a.push_front(n);
list<int>::iterator it=a.begin();
it++;

cout << numberSwapper(1224)<<endl;
}