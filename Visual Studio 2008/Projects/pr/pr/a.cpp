#include <stdio.h>

int pow1000 (int a,int n)
{
	int p=1,i;
	for (i=0;i<n;i++) p=(p*a)%1000;
	return (p);
}


int facts[]={1,1,2,6,24};

int main()
{
	freopen("input.txt", "r", stdin);
	freopen("output.txt", "w", stdout);
	int i,n,k,ans=0;

	scanf ("%d %d",&n,&k);

	if (k==0) ans=n+1;
	else 
	{
		if (n>4) n=4;

		for (i=0;i<=n;i++){
			ans=(ans+pow1000 (facts[i],k))%1000;
			printf("%d\n", ans);
		}
	}

	printf("%d\n", ans);
	
	if (ans%10)
		printf ("%d\n",ans%10);
	else 
		if (ans%100) 
			printf ("%d\n",(ans/10)%10);
		else 
			printf ("%d\n",(ans/100)%10);

	return (0);
}
