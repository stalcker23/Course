using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static double func(double x)
        {
            return x * x;
        }
        static double func1(double x)
        {
            return 0;
        }
        static double func2(double x)
        {
            return 1/x;
        }

        static void Main()
        {
            Console.Write("x=");
            double a = double.Parse(Console.ReadLine());
            double y = 0;
           double  x = a;
            if (a < 0)
                 y=func(x);
            else 
                if (a > 0)
                    y=func2(x);
                else
                    y=func1(x);
            
                Console.WriteLine("y({0:f1})={1:f2}", x, y);
            }
        }
    }
