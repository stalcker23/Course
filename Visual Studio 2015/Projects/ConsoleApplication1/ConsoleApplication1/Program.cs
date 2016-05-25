using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circle
{
    class Program
    {
        //static int[,] graph = new int[7, 7]
        //{
        //    { 0, 1, 0, 1, 0, 0, 0 },
        //    { 1, 0, 1, 0, 0, 0, 0 },
        //    { 0, 1, 0, 1, 1, 0, 0 },
        //    { 1, 0, 1, 0, 0, 0, 0 },
        //    { 0, 0, 1, 0, 0, 1, 1 },
        //    { 0, 0, 0, 0, 1, 0, 1 },
        //    { 0, 0, 0, 0, 1, 1, 0 },
        //};

        static int[,] graph = new int[5, 5]
        {
           {0,1,1,1,1},
           {1,0,1,1,0},
           {1,1,0,1,1},
           {1,1,1,0,1},
           {1,0,1,1,0},

        };
        static byte[] colour = new byte[graph.GetLength(0)];
        static void Circle(int[] p, int start, int end)
        {
            Console.Write(start + 1 + " ");
            for (int i = end; i != start; i = end)
            {
                Console.Write(i + 1 + " ");
                end = p[i];
            }
            Console.Write(start + 1 + " ");
            Console.WriteLine();
        }

        static void Foundamental(int v, int[] p)
        {
            colour[v] = 1;

            for (int u = 0; u < graph.GetLength(0); u++)
            {
                if (colour[u] == 1 && graph[v, u] != 0 && p[v] != u)
                {
                    Circle(p, u, v);
                }
                if (colour[u] == 0 && graph[v, u] != 0)
                {
                    p[u] = v;
                    Foundamental(u, p);
                }

            }
            colour[v] = 2;
        }

        static void Main(string[] args)
        {
            int[] p = new int[graph.GetLength(0)];
            Foundamental(0, p);
        }
    }
}