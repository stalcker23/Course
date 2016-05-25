#include<iostream>
#include<cstdio>
#include<vector>
#include<list>
#include<algorithm>
using namespace std;

int numberCounter(int a)
{
	
	vector<int> temp;
	vector<int>::iterator it;
	
	int i=1;
	if(a==0)return 1;
	while(a!=0)
	{
		
		temp.push_back(a%10);
		a/=10;
		
		i++;
}
	i--;
	
	it=temp.begin();
	
	for(vector<int>::iterator it2=temp.begin();it2<temp.end();it2++)
	{
for(vector<int>::iterator it3=it2+1;it3<temp.end();it3++)
{
	if(*it2==*it3)
		i--;
}

	}
	return i;
}
	

int main()
{
	freopen("input.txt","r",stdin);
	freopen("output.txt","w",stdout);
	vector<int> Vector;
	vector<int>::iterator it;
	list<int> List;
	int i,n;
	
    while(cin>>i)
	{
		Vector.push_back(i);
	}
	if((int)Vector.size()==1){cout<<"Error: You need to enter 2 or more elements";return 0;} 
	it=Vector.end()-2;
n=Vector[1];
i=*it;
Vector[1]=numberCounter(n);
*it=numberCounter(*it);
for(int i=0;i<Vector.size();i++)
cout << Vector[i]<< " ";

}










