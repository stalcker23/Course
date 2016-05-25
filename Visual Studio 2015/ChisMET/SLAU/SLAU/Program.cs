using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progonka
{
    class Program
    {
        public double eps = 1e-7;
        public double st = Math.Pow(10, -6);
        public static int n = 5;
        public double[] x = new double[n];
        public double[] p = new double[n];
        public double[] f = new double[n];
        public double[,] matrix = new double[n, n];
        public int step=0;
        public bool converge(double[] xk, double[] xkp)
        {
            double norm = 0;
            for (int i = 0; i < n; i++)
            {
                norm += (xk[i] - xkp[i]) * (xk[i] - xkp[i]);
            }
            if (Math.Sqrt(norm) >= eps)
                return false;
            return true;
        }
        public bool Seidel()
        {
            Console.WriteLine();
            Console.WriteLine("<------------------------------Seidel------------------------------>");

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = 0;
                }
            }

            for (int i = 0; i < n; i++)
            {
                matrix[i, i] = 1 + i * 2;
                if (i == 0)
                {
                    matrix[i, i + 1] = matrix[i, i] * st;
                    continue;
                }
                if (i == n - 1)
                {
                    matrix[i, i - 1] = matrix[i, i] * st;
                    continue;
                }
                matrix[i, i + 1] = matrix[i, i] * st;
                matrix[i, i - 1] = matrix[i, i] * st;

            }
            double[] x = new double[n];

            double[] f = new double[n];
            for (int i = 0; i < n; i++)
            {
                f[i] = 2;
            }


            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write("\t" + matrix[i, j]);
                }
                Console.Write("\t" + "f" + "[" + i + "] = " + f[i]);
                Console.WriteLine();
            }

            do
            {
                step++;
                for (int i = 0; i < n; i++)
                    p[i] = x[i];

                for (int i = 0; i < n; i++)
                {
                    
                    double var = 0;
                    for (int j = 0; j < i; j++)
                        var += (matrix[i, j] * x[j]);
                    for (int j = i + 1; j < n; j++)
                        var += (matrix[i, j] * p[j]);
                    x[i] = (f[i] - var) / matrix[i, i];
                }
            }
            while (!converge(x, p));
            Console.WriteLine("Количество итераций {0}",step);
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("x" + "[" + i + "]" + "=" + "\t" + x[i] + " ");
            }
            Console.WriteLine("\n" + "<------------------------------ProverkaSeidel------------------------------>");
            for (int i = 0; i < n; i++)
            {
                f[i] = 0;
            }
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    f[i] = f[i] + x[j] * matrix[i, j];
                }
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("f" + "[" + i + "]" + "=" + "\t" + f[i] + " ");
            }
            return true;
        }
        public bool Gauss()
        {
            Console.WriteLine();
            Console.WriteLine("<------------------------------Gauss------------------------------>");

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = 0;
                }
            }

            for (int i = 0; i < n; i++)
            {
                matrix[i, i] = 1 + i * 2;
                if (i == 0)
                {
                    matrix[i, i + 1] = matrix[i, i] * st;
                    continue;
                }
                if (i == n - 1)
                {
                    matrix[i, i - 1] = matrix[i, i] * st;
                    continue;
                }
                matrix[i, i + 1] = matrix[i, i] * st;
                matrix[i, i - 1] = matrix[i, i] * st;

            }

            double[,] copymatrix = new double[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    copymatrix[i, j] = matrix[i, j];
                }
            }
            double[] x = new double[n];

            double[] f = new double[n];
            for (int i = 0; i < n; i++)
            {
                f[i] = 2;
            }
            double[] copyF = new double[n];
            for (int i = 0; i < n; i++)
            {
                copyF[i] = f[i];
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write("\t" + matrix[i, j]);
                }
                Console.Write("\t" + "f" + "[" + i + "] = " + f[i]);
                Console.WriteLine();
            }
            int k = 0;
            while (k < n)
            {
                double max = Math.Abs(matrix[k, k]);
                int index = k;
                for (int i = k + 1; i < n; i++)
                {
                    if (Math.Abs(matrix[i, k]) > max)
                    {
                        max = Math.Abs(matrix[i, k]);
                        index = i;
                    }
                }

                if (max < eps)
                    return false;
                for (int j = 0; j < n; j++)
                {
                    double temple = matrix[k, j];
                    matrix[k, j] = matrix[index, j];
                    matrix[index, j] = temple;
                }
                double temp = f[k];
                f[k] = f[index];
                f[index] = temp;

                for (int i = k; i < n; i++)
                {
                    double temple = matrix[i, k];
                    if (Math.Abs(temple) < eps) continue;
                    for (int j = 0; j < n; j++)
                    {
                        matrix[i, j] = matrix[i, j] / temple;
                    }
                    f[i] = f[i] / temple;
                    if (i == k) continue;
                    for (int j = 0; j < n; j++)
                    {
                        matrix[i, j] = matrix[i, j] - matrix[k, j];
                    }
                    f[i] = f[i] - f[k];
                }
                k++;
            }

            for (k = n - 1; k >= 0; k--)
            {
                x[k] = f[k];
                for (int i = 0; i < k; i++)
                {
                    f[i] = f[i] - matrix[i, k] * x[k];
                }
            }
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("x" + "[" + i + "]" + "=" + "\t" + x[i] + " ");
            }
            Console.WriteLine("\n" + "<------------------------------ProverkaGauss------------------------------>");
            for (int i = 0; i < n; i++)
            {
                copyF[i] = 0;
            }
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    copyF[i] = copyF[i] + x[j] * copymatrix[i, j];
                }
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("f" + "[" + i + "]" + "=" + "\t" + copyF[i] + " ");
            }
            return true;

        }

        public bool Progonka()
        {

            Console.WriteLine("<------------------------------Progonka------------------------------>");

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = 0;
                }
            }

            for (int i = 0; i < n; i++)
            {
                matrix[i, i] = 1 + i * 2;
                if (i == 0)
                {
                    matrix[i, i + 1] = matrix[i, i] * st;
                    continue;
                }
                if (i == n - 1)
                {
                    matrix[i, i - 1] = matrix[i, i] * st;
                    continue;
                }
                matrix[i, i + 1] = matrix[i, i] * st;
                matrix[i, i - 1] = matrix[i, i] * st;

            }

            double[] x = new double[n];
            double m;
            double[] f = new double[n];
            for (int i = 0; i < n; i++)
            {
                f[i] = 2;
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write("\t" + matrix[i, j]);
                }
                Console.Write("\t" + "f" + "[" + i + "] = " + f[i]);
                Console.WriteLine();
            }

            for (int i = 1; i < n - 1; i++)
            {
                m = matrix[i, i + 1] / matrix[i, i];
                matrix[i, i] = matrix[i, i] - m * matrix[i - 1, i + 1];
                f[i] = f[i] - m * f[i - 1];
            }

            x[n - 1] = f[n - 1] / matrix[n - 1, n - 1];

            for (int i = n - 2; i >= 0; i--)
                x[i] = (f[i] - matrix[i + 1, i] * x[i + 1]) / matrix[i, i];

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("x" + "[" + i + "]" + "=" + "\t" + x[i] + " ");
            }

            Console.WriteLine("\n" + "<------------------------------ProverkaProgonka------------------------------>");
            for (int i = 0; i < n; i++)
            {
                f[i] = 0;
            }
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    f[i] = f[i] + x[j] * matrix[i, j];
                }
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("f" + "[" + i + "]" + "=" + "\t" + f[i] + " ");
            }
            return true;

        }
        public void Multi()
        {

            //Console.WriteLine("Progonka ");
            //Progonka();
            //Gauss();
            Seidel();



        }
        static void Main(string[] args)
        {
            Program res = new Program();

            res.Multi();
        }
    }
}
