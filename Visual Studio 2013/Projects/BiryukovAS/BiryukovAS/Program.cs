/*
 * Created by SharpDevelop.
 * User: Алексей
 * Date: 21.03.2015
 * Time: 12:41
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace DFSGraph
{
    class Program
    {
        /*
        static int[,] graph = new int [,]
        {
			{0, 1, 0, 0, 1, 0, 0, 0, 0, 0},
            {1, 0, 1, 1, 1, 1, 1, 0, 1, 0},
            {0, 1, 0, 1, 0, 0, 1, 0, 0, 1},
            {0, 1, 1, 0, 1, 0, 1, 1, 1, 0},
            {1, 1, 0, 1, 0, 0, 1, 1, 1, 0},
            {0, 1, 0, 0, 0, 0, 1, 1, 1, 0},
            {0, 1, 1, 1, 1, 1, 0, 0, 0, 0},
            {0, 0, 0, 1, 1, 1, 0, 0, 1, 0},
            {0, 1, 0, 1, 1, 1, 0, 1, 0, 0},
            {0, 0, 1, 0, 0, 0, 0, 0, 0, 0}



        };*/
        //static bool[] visited = new bool[graph.GetLength(0)];
        static Stack<int> stack = new Stack<int>();

        static char LetterPrint(int start)
        {
            char c = 'A';
            c += (char)start;
            return c;
        }

        static int ReturnToTheTop(int[,] graph, int peek, bool[] visited) // метод для нерекурсивной реализации
        {
            for (int j = 0; j < graph.GetLength(0); j++)
                if (graph[peek, j] != 0 && !visited[j])
                {
                    return j;
                }
            return -1;
        }

        static int temp;
        static void DFS(int[,] graph, int start, bool[] visited)
        {
            visited[start] = true;
            stack.Push(start);
            //Console.Write(LetterPrint(start) + " ");
            while (stack.Count != 0)
            {
                temp = -1;
                //temp = ReturnToTheTop(stack.Peek());
                for (int j = 0; j < graph.GetLength(0); j++)
                    if (graph[stack.Peek(), j] != 0 && !visited[j])
                    {
                        temp = j;
                        break;
                    }
                if (temp == -1)
                    stack.Pop();
                else
                {
                    //Console.Write(LetterPrint(temp) + " ");
                    visited[temp] = true;
                    stack.Push(temp);
                }
            }
        }



        static void RecDFS(int[,] graph, int start, bool[] visited)
        {
            //Console.Write(LetterPrint(start) + " ");
            visited[start] = true;
            for (int j = 0; j < graph.GetLength(0); j++)
            {
                if (graph[start, j] != 0 && !visited[j])
                {
                    RecDFS(graph, j, visited);
                }
            }
        }


        static int Input()
        {
            Console.Write("Обход начинаем с вершины ");
            char A = char.Parse(Console.ReadLine());
            int start = 0;
            if (A == 'A')
                start = 0;
            else
                start = ((int)(A - 'A'));
            return start;
        }

        static void Main(string[] args)
        {
            int start = Input();
            Random rand = new Random();
            int[,] graph = new int[10000, 10000];
            bool[] visited = new bool[graph.GetLength(0)];
            if (start > graph.GetLength(0))
                throw new Exception("Такой вершины в графе нет!");

                    for (int i = 0; i < graph.GetLength(0); i++)
                        for (int j = 0; j < graph.GetLength(1); j++)
                            graph[i, j] = rand.Next(0, 2);

                    for (int i = 0; i < graph.GetLength(0); i++)
                        for (int j = 0; j < graph.GetLength(1); j++)
                            if (graph[i, j] != graph[j, i])
                                graph[j, i] = graph[i, j];

                    for (int i = 0; i < graph.GetLength(0); i++)
                        for (int j = 0; j < graph.GetLength(1); j++)
                            if (i == j)
                                graph[i, j] = 0;

                    Stopwatch st = new Stopwatch();
                    st.Start();
                    //DFS(graph, start, visited);
                    RecDFS(graph, start, visited);
                    st.Stop();
                    Console.WriteLine(st.ElapsedMilliseconds + " milsec");
                    Console.ReadKey();
        }
    }
}