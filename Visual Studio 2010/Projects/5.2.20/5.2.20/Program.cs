using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Практикум_5_3_20
{
    class Program
    {
        static int F(int a, int b)
        {   
            if (b == 0)
                return a;
            else
                return F(b, a % b);
        }
        static void Main()

        {  
            int n=int.Parse(Console.ReadLine());
            int[] a = new int[n];

            for (int i=0; i<n; i++)
            a[i]=int.Parse(Console.ReadLine());
            int ans = a[0];
            for (int i = 0; i < n; i++)
            {
                ans = F(ans, a[i]);
            }
           
            Console.WriteLine("{0}", ans);
        }
    }
}