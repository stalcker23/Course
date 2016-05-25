using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO; 

using System.Diagnostics;
namespace Pract16.II
{

    public class MaxFlowFordFulkerson
    {

        public static int MaxFlow(int[,] cap, int s, int t)
        {
            for (int flow = 0; ; )
            {
                int df = FindPath(cap, new bool[cap.Length], s, t, Int32.MaxValue);
                if (df == 0)

                    return flow;

                flow += df;
            }

        }

        public static int FindPath(int[,] cap, bool[] vis, int u, int t, int f)
        {
            if (u == t)
                return f;
            vis[u] = true;
            for (int v = 0; v < cap.GetLength(0); v++)
                if (!vis[v] && cap[u, v] > 0)
                {
                    int df = FindPath(cap, vis, v, t, Math.Min(f, cap[u, v]));
                    if (df > 0)
                    {
                        cap[u, v] -= df;
                        cap[v, u] += df;
                        return df;
                    }
                }
            return 0;
        }
        static void Print(int[,] mas)
        {
            
            for (int i = 0; i < mas.GetLength(0); i++)
            {
                for (int j = 0; j < mas.GetLength(1); j++)
                {
                    Console.Write("{0} ", mas[i, j]);
                }
                Console.WriteLine();
            }
        }


        public static void Main()
        {

            using (StreamReader file = new StreamReader("C:/Users/1/Documents/input.txt"))
            {
                string line = file.ReadLine();
                string[] mas = line.Split(' ');
                int n = int.Parse(mas[0]);
                int[,] MyArray = new int[n, n];
                for (int i = 0; i < n; i++)
                {
                    line = file.ReadLine();
                    mas = line.Split(' ');
                    for (int j = 0; j < n; j++)
                    {
                        MyArray[i, j] = int.Parse(mas[j]);
                    }
                }

                int strange = MaxFlow(MyArray, 0, MyArray.GetLength(0)-1);
                Console.WriteLine("{0}", strange);
            }
        }
    }
}
