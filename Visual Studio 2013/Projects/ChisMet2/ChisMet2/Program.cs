using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _17._09.chislmet
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamWriter outfile = new StreamWriter("output.txt"))
            {
                string file = File.ReadAllText("input.txt");
                int[] indata = file.Split(new char[] { ' ', '\n' }, StringSplitOptions.RemoveEmptyEntries).Select(n => int.Parse(n)).ToArray();

                int size = indata.Length / 2;
                int k = size;
                double[,] table = new double[2, size];

                for (int i = 0; i < size; i++)
                {
                    table[0, i] = indata[i];
                }

                for (int j = 0; j < size; j++)
                {
                    table[1, j] = indata[k];
                    k++;

                }

                double[,] result = new double[2, size * 2 - 1];
                int k1 = 0;
                for (int i = 0; i < size * 2 - 1; i++)
                {
                    if (i % 2 == 0)
                    {
                        result[0, i] = indata[k1];
                        k1++;
                    }
                }

                for (int i = 1; i < size * 2 - 1; i++)
                {
                    if (i % 2 != 0)
                    {
                        result[0, i] = (result[0, i - 1] + result[0, i + 1]) / 2;
                    }
                }

                int k2 = 0;
                for (int i = 0; i < size * 2 - 1; i++)
                {
                    if (i % 2 == 0)
                    {
                        result[1, i] = table[1, k2];
                        k2++;
                    }
                }

                for (int i = 1; i < size * 2 - 1; i++)
                {
                    if (i % 2 != 0)
                    {
                        result[1, i] = (result[1, i - 1] + result[1, i + 1]) / 2;
                    }
                }

                for (int i = 0; i < table.GetLength(0); i++)
                {
                    for (int j = 0; j < table.GetLength(1); j++)
                    {
                        if (table[i, j] < 0)
                        {
                            outfile.Write("{0} ", table[i, j]);
                        }
                        else outfile.Write("{0}  ", table[i, j]);
                    }
                    outfile.WriteLine();
                }

                for (int i = 0; i < result.GetLength(0); i++)
                {
                    for (int j = 0; j < result.GetLength(1); j++)
                    {
                        if (result[i, j] < 0)
                        {
                            outfile.Write("{0} ", result[i, j]);
                        }
                        else outfile.Write("{0}  ", result[i, j]);
                    }
                    outfile.WriteLine();
                }
            }

        }
    }
}