using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Spline
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
                    ///////////////////////////// СЧИТЫВАНИЕ ДАННЫХ
                    string S = inFile.ReadLine();
                    string[] nN = S.Split(' ');
                    int n = int.Parse(nN[0]);
                    int N = int.Parse(nN[1]);
                    double A = double.Parse(nN[2]);
                    double B = double.Parse(nN[3]);
                    string line = inFile.ReadLine();
                    string[] mas = line.Split(' ');
                    double[] y = new double[n + 1];

                    for (int i = 0; i <= n; i++)
                    {
                        y[i] = double.Parse(mas[i]);
                    }

                    line = inFile.ReadLine();
                    mas = line.Split(' ');

                    double[] s = new double[N + 1];

                    for (int i = 0; i < N + 1; i++)
                    {
                        s[i] = double.Parse(mas[i]);
                    }

                    ////////////////////////////////////////////////////

                    double[] Ci = new double[n + 1];
                    double[] Alph = new double[n + 1];
                    double[] Beta = new double[n + 1];
                    double h = (B - A) / n;

                    for (int i = 1; i < n; i++)
                    {
                        double Di = 6 / h / h * (y[i - 1] - 2 * y[i] + y[i + 1]);

                        Alph[i] = -1 / (Alph[i - 1] + 4);
                        Beta[i] = (Di - Beta[i - 1]) / (Alph[i - 1] + 4);
                    }
                    for (int i = n - 1; i > 0; i--)
                    {
                        Ci[i] = Alph[i] * Ci[i + 1] + Beta[i];
                    }

                    for (int j = 0; j < N + 1; j++)
                    {

                        if (s[j] == A)
                        {
                            outFile.Write("{0:0.000000} ", y[0]);
                            continue;
                        }
                        if (s[j] == B)
                        {
                            outFile.Write("{0:0.000000} ", y[n]);
                            continue;
                        }
                        int i = (int)Math.Ceiling((double)n * (s[j] - A) / (B - A));
                        double Xi = A + h * i;
                        double Ai = y[i];
                        double Di = (Ci[i] - Ci[i - 1]) / h;
                        double Bi = (y[i] - y[i - 1]) / h + h / 2 * Ci[i] - (h * h) / 6 * Di;
                        outFile.Write("{0:0.000000} ", Ai + Bi * (s[j] - Xi) + Ci[i] / 2 * (s[j] - Xi) * (s[j] - Xi) + Di / 6 * (s[j] - Xi) * (s[j] - Xi) * (s[j] - Xi));
                    }
                }
            }
        }
    }
}