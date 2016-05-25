using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Edmonds_Karp
{
    class Graph
    {


        public Dictionary<int, List<Tuple<int, int>>> array1Weighted = new Dictionary<int, List<Tuple<int, int>>>();

        public List<int> way = new List<int>();


        public List<int> p = new List<int>();//лист предков
        public List<int> d = new List<int>();//лист distance
        public List<bool> u = new List<bool>();//лист used

        int n;

        public Graph()
        //Граф представляется списком смежности в виде:
        //5 - количество вершин
        //1 2(3) - номер вершины смежная вершина(вес)
        //....
        //....
        //....
        //....
        {

            string[] mas = File.ReadAllLines(@"Graph.txt");
            n = int.Parse(mas[0]);

            string[] m;

            for (int i = 1; i < n + 1; i++)
            {
                string[] mas2 = mas[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                List<Tuple<int, int>> matr = new List<Tuple<int, int>>();
                for (int j = 1; j < mas2.Length; j++)
                {
                    m = mas2[j].Split(new char[] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
                    Tuple<int, int> pair = Tuple.Create(int.Parse(m[0]), int.Parse(m[1]));
                    matr.Add(pair);
                }
                array1Weighted.Add(int.Parse(mas2[0]), matr);
            }

        }




        public int Flow(int[,] cap, int s, int t)
        //реализует Алгоритм Эдмондса-Карпа с путем ввиде кратчайшего пути из бфс
        //матрица смежности,вершина исток,вершина сток
        {

            for (int flow = 0; ;)//до тех пор, пока поток не равен нулю
            {
                List<int> way = new List<int>();
                way = bfs(cap, s, t);
                int df = FindPath(way, cap, new bool[cap.GetLength(0)], s, t, Int32.MaxValue);
                Console.WriteLine("Минимум из ребер в пути равен {0}", df);
                if (df == 0)
                    return flow;
                Console.WriteLine("Поток равен {0}", flow += df);
                Console.WriteLine();
            }

        }

        public int FindPath(List<int> way, int[,] cap, bool[] vis, int u, int t, int f)
        //(кратчайший путь по бфс,матрица смежности, патрица посещений,действующая вершина в пути от стока к истоку, сток, если сток и сток равны - бесконечный поток
        //метод, который подсчитывает поток 
        {

            if (u == t)
                return f;
            vis[u] = true;

            foreach (var item in way)
                if (!vis[item])
                {

                    Console.WriteLine("[{0},{1}]", u + 1, item + 1);//вывод на экран дуги из кратчайшего пути

                    int df = FindPath(way, cap, vis, item, t, Math.Min(f, cap[u, item]));
                    //величина потока в между данной вершиной u и последующей вершиной из кратчайшего пути

                    if (df > 0)
                    {

                        cap[u, item] -= df;//увеличивающая дуга
                        cap[item, u] += df;//уменьшающая дуга

                        //вывод на экран r и i и принадлежности дуг к I и R(полезно для проверки на листке)
                        if ((cap[u, item] != 0) && (u < item)) Console.WriteLine("[{0},{1}]ЄI i[{0},{1}]={2}", u + 1, item + 1, cap[u, item]); else if (cap[u, item] != 0) Console.WriteLine("[{0},{1}]ЄR r[{0},{1}]={2}", item + 1, u + 1, cap[item, u]);

                        if ((cap[item, u] != 0) && (item > u)) Console.WriteLine("[{0},{1}]ЄR r[{0},{1}]={2}", u + 1, item + 1, cap[item, u]); else if (cap[item, u] != 0) Console.WriteLine("[{0},{1}]ЄI i[{0},{1}]={2}", item + 1, u + 1, cap[u, item]);
                        Console.WriteLine();
                        return df;
                    }

                }

            return 0;
        }
        public List<int> bfs(int[,] cap, int s, int t)//поиск в ширину кратчайшего пути 
        {

            Queue<int> q = new Queue<int>(); ;
            q.Enqueue(s);
            for (int i = 0; i < cap.GetLength(0); i++) { u.Add(false); }
            for (int i = 0; i < cap.GetLength(0); i++) { p.Add(-1); }
            for (int i = 0; i < cap.GetLength(0); i++) { d.Add(0); }
            u[s] = true;


            while (q.Count != 0)
            {
                int v = q.Peek();
                q.Dequeue();
                if (v != -1)
                    for (int i = 0; i < cap.GetLength(0); i++)
                    {
                        if (cap[v, i] != 0)
                        {
                            int to = i;
                            if (!u[to])
                            {
                                u[to] = true;

                                d[to] = d[v] + 1;
                                q.Enqueue(to);
                                p[to] = v;
                            }
                        }
                    }
            }

            List<int> path = new List<int>();
            if (!u[t])
                Console.WriteLine("No path!");
            else
            {

                for (int j = t; j != -1; j = p[j])
                    path.Add(j);
                path.Reverse();

                u.Clear();
                return path;
            }
            u.Clear();
            return path;
        }
        public void MaxFlow(int first, int second)//преобразуем список смежности с весами в матрицу смежности и запускаем Flow
        {
            int[,] MyArray = new int[n, n];
            int[] R = new int[n];
            int[] I = new int[n];
            foreach (var item in array1Weighted)
            {
                foreach (var i in item.Value)
                {
                    MyArray[item.Key - 1, i.Item1 - 1] = i.Item2;
                }
            }

            Console.WriteLine();
            int strange = Flow(MyArray, first - 1, second - 1);

        }
        public static void Main()
        {


            Graph g = new Graph();
            g.MaxFlow(1, 8);//поиск потока откуда и куда

        }

    }

}

