using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Практикум_5._3._20
{
    class Program
    {

        static double func(double x)
        {
            return Math.Sin(x);
        }
        static double func1(double x)
        {
            return Math.Cos(x);
        }
        static double func2(double x)
        {
            return 0;
        }

        static void Main()
        {    double PI=3.14;
            Console.Write("x=");
            double a = double.Parse(Console.ReadLine());
            double y = 0;
           double  x = a;
            if (Math.Abs(a) < PI/2)
                 y=func(x);
            else 
                if (Math.Abs(a) > PI)
                    y=func1(x);
                else
                    y=func2(x);
            
                Console.WriteLine("y({0:f1})={1:f2}", x, y);
            }
        }
    }
