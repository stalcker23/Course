using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication2

{
    
    class Program
    {
        static void extent(int a)
        {
            
            

                int q = a % 10;
                a = a / 10;
                if (a != 0)
                {
                    extent(a);
                }
                Console.Write("{0} ", q);
                
             
            
        }
        static void Main()
        {
            
            int a = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
          
               while(a<=n)
               {
                    extent(a);
                    Console.WriteLine();
                    a++;
               }
        }
    }
}
