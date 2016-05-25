using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Example
{
    class Program
    {
        static void Main()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            using (StreamReader inFile = new StreamReader("input.txt"))
            {
                using (StreamWriter outFile = new StreamWriter("output.txt", false))
                {
                    string S = inFile.ReadLine();
                    string[] nN = S.Split(' ');
                    int n = int.Parse(nN[0]);
                    int N = int.Parse(nN[1]);
                    string line = inFile.ReadLine();
                    string[] mas = line.Split(' ');
                    double[] x = new double[n + 1];
                    for (int i = 0; i <= n; i++)
                    {
                        x[i] = double.Parse(mas[i]);
                    }

                    line = inFile.ReadLine();
                    mas = line.Split(' ');

                    double[] y = new double[n + 1];

                    for (int i = 0; i <= n; i++)
                    {
                        y[i] = double.Parse(mas[i]);
                    }

                    line = inFile.ReadLine();
                    mas = line.Split(' ');

                    double[] s = new double[mas.Length];

                    for (int i = 0; i < mas.Length; i++)
                    {
                        s[i] = double.Parse(mas[i]);
                    }

                    for (int i = 0; i < mas.Length; i++)
                    {
                        outFile.Write(Sum(s[i], x, y) + " ");
                    }
                }
            }
        }

        static double LNK(double X, int k, double[] x)
        {
            double result = 1;

            for (int i = 0; i < x.Length; i++)
            {
                if (i != k)
                    result *= ((X - x[i]) / (x[k] - x[i]));
            }
            return result;
        }

        static double Sum(double X, double[] x, double[] y)
        {
            double result = 0;
            for (int i = 0; i < x.Length; i++)
            {
                result += (y[i] * LNK(X, i, x));
            }

            return result;
        }
    }
}