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
        public static double f1(double x1_k, double x2_k)
        {
            return 0.1 * x1_k * x1_k + x1_k + 0.2 * x2_k * x2_k - 0.3;

        }
        public static double f2(double x1_k, double x2_k)
        {
            return 0.2 * x1_k * x1_k + x2_k - 0.1 * x1_k * x2_k - 0.7 ;
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public static double df1_dx1(double x1_k, double x2_k)
        {
            return 0.2 * x1_k + 1;
        }
        public static double df1_dx2(double x1_k, double x2_k)
        {
            return 0.4 * x2_k;
        }
        public static double df2_dx1(double x1_k, double x2_k)
        {
            return 0.4 * x1_k - 0.1*x2_k;
        }
        public static double df2_dx2(double x1_k, double x2_k)
        {
            return 1-0.1*x1_k;
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public static double J_k(double x1_k, double x2_k)
        {
            return df1_dx1(x1_k, x2_k) * df2_dx2(x1_k, x2_k) - df1_dx2(x1_k, x2_k) * df2_dx2(x1_k, x2_k);
        }
        public static  double A1_k(double x1_k, double x2_k)
        {
            return f1(x1_k, x2_k) * df2_dx2(x1_k, x2_k) - f2(x1_k, x2_k) * df2_dx1(x1_k, x2_k);
        }
        public static double A2_k(double x1_k, double x2_k)
        {
            return f2(x1_k, x2_k) * df1_dx1(x1_k, x2_k) - f1(x1_k, x2_k) * df2_dx1(x1_k, x2_k);
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        static void Main(string[] args)
        {
            double x1_k = double.MaxValue;
            double x2_k = double.MaxValue;
            double eps = Math.Pow(10, -7);
            double x1_0 = 0.25;
            double x2_0 = 0.75;
            double x1_simple = x1_0;
            double x2_simple = x2_0;
            while (Math.Max(Math.Abs(x1_k - x1_simple), Math.Abs(x2_k - x2_simple)) > eps)
            {
                x1_simple = x1_k;
                x2_simple = x2_k;
                x1_k = x1_0 - A1_k(x1_0, x2_0)/ J_k(x1_0, x2_0);
                x2_k = x2_0 - A2_k(x1_0, x2_0)/ J_k(x1_0, x2_0);
            }
            Console.WriteLine(x1_k+" "+x2_k);
        }
    }
}
