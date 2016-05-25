using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewtonSnau
{
    class Program
    {

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public static double fi1(double x1_0, double x2_0)
        {
            return 0.3-0.1* x1_0* x1_0- 0.2 * x2_0 * x2_0;

        }
        public static double fi2(double x1_0, double x2_0)
        {
            return 0.7- 0.2 * x1_0 * x1_0 +0.1*x1_0*x2_0;
        }
        
        static void Main(string[] args)
        {
            double q = 0.5;
            double x1_k = 0;
            double x2_k = 0;
            double eps = Math.Pow(10, -4);
            double x1_0 = 0.25;
            double x2_0 = 0.75;
            double x1_simple = x1_0;
            double x2_simple = x2_0;
            int step = 0;
            Console.WriteLine("f1 = 0.1*x1^2 + x1 + 0.2*x2^2 - 0.3");
            Console.WriteLine("f2 = 0.2*x1^2 + x2 - 0.1*x1*x2 - 0.7");
            while (q / (1 - q) * Math.Max(Math.Abs(x1_k - x1_simple), Math.Abs(x2_k - x2_simple)) > eps)
            {
                step++;
                x1_simple = x1_k;
                x2_simple = x2_k;
                x1_k = fi1(x1_0, x2_0);
                x2_k = fi2(x1_0, x2_0);
                x1_0 = x1_k;
                x2_0 = x2_k;
                Console.WriteLine(" ИТЕРАЦИЯ НОМЕР:{2} x1={0} x2={1}", x1_k, x2_k, step);
            }
            

        }
    }
}