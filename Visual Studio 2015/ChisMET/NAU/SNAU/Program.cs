using System;

namespace AllMethods
{
    class Program
    {
        const double EPS = 1e-9;

        static double F(double x)
        {
            return Math.Sin(x) - 2 * Math.Cos(x);
        }

        static double Psi(double x)
        {
            return Math.Acos(Math.Sin(x) / 2);
        }

        static double dF(double x)
        {
            return Math.Cos(x) + 2 * Math.Sin(x);
        }

        #region Метод деления отрезка пополам

        static double DevideByTwoMethod(double a, double b, out int counter)
        {
            counter = 0;
            double c = 0.0;
            while (Math.Abs(a - b) >= EPS)
            {
                c = a + (b - a) / 2;
                if (F(a) * F(c) < 0)
                    b = c;
                else
                    a = c;
                counter++;
            }
            return c;
        }
        #endregion

        #region Метод приближений
        static double SimpleIterationMethod(double x, out int counter)
        {
            counter = 0;
            double xPrev = 0.0;
            do
            {
                xPrev = x;
                x = Psi(xPrev);
                counter++;
            }
            while (Math.Abs(x - xPrev) >= EPS);
            return x;
        }

        #endregion

        #region Метод Ньютона
        static double NewtonMethod(double x, out int counter)
        {
            double xPrev = 0.0;
            counter = 0;
            do
            {
                xPrev = x;
                x = xPrev - F(xPrev) / dF(xPrev);
                counter++;
            }
            while (Math.Abs(x - xPrev) >= EPS);
            return x;
        }
        #endregion

        #region Модифицированный метод Ньютона
        static double ModifyNewtonMethod(double x, out int counter)
        {
            counter = 0;
            double xPrev = 0.0;
            double d = dF(x);
            do
            {
                xPrev = x;
                x = xPrev - F(xPrev) / d;
                counter++;
            }
            while (Math.Abs(x - xPrev) >= EPS);
            return x;
        }
        #endregion

        #region Метод секущих
        static double SecantMethod(double a, double b, out int counter)
        {
            counter = 0;
            double temp = 0.0;
            do
            {
                temp = b;
                b = b - (F(b) * (b - a)) / (F(b) - F(a));
                a = temp;
                counter++;
            }
            while (Math.Abs(b - a) >= EPS);

            return b;
        }
        #endregion

        static void Main(string[] args)
        {
            //double a = -2.034443935795;
            //double b = 1.107148717794;
            int counter;
            double a = 0.0;
            double b = Math.PI / 2;
            Console.WriteLine("Метод деления отрезка пополам: {0}; {1} итераций", DevideByTwoMethod(a, b, out counter), counter);

            //проверка ф-ии пси
            //Console.WriteLine(-Math.Cos(0) / (2 * Math.Sqrt(1 - Math.Pow(Math.Sin(0) / 2, 2.0))));
            Console.WriteLine("Метод итераций: {0}; {1} итераций", SimpleIterationMethod((a + b) / 2, out counter), counter);
            Console.WriteLine("Метод Ньютона: {0}; {1} итераций", NewtonMethod(b, out counter), counter);
            Console.WriteLine("Модифицированный метод Ньютона: {0}; {1} итераций", ModifyNewtonMethod(b, out counter), counter);
            Console.WriteLine("Метод секущих: {0}; {1} итераций", SecantMethod(a, b, out counter), counter);

        }
    }
}