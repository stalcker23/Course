using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _6._4._20
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a;
            Console.Write("n= ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("k= ");
            int k = int.Parse(Console.ReadLine());
            a = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write("A[{0}]= ", i);
                a[i] = int.Parse(Console.ReadLine());
            }



            for (int i = 0; i < n; i++)
            {
                if (a[i] % 2 == 0)
                {
                    Console.Write("{0} ", k);
                    Console.Write("{0} ", a[i]);
                }
                else
                {
                    Console.Write("{0} ", a[i]);
                }
            }
        }
    }
}

  
   
        
    

