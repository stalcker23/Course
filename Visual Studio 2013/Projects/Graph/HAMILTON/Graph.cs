using System;
using System.IO;

namespace Pract16.II
{
    public class Graph
    {
        private class Node //вложенный класс для скрытия данных и алгоритмов
        {
            private int[,] array; //матрица смежности

            public int this[int i, int j] //индексатор для обращения к матрице смежности
            {
                get
                {
                    return array[i, j];
                }
                set
                {
                    array[i, j] = value;
                }
            }

            public int Size //свойство для получения размерности матрицы смежности
            {
                get
                {
                    return array.GetLength(0);
                }
            }

            private bool[] nov; //вспомогательный массив: если i-ый элемент массива равен
            //true, то i-ая вершина еще не просмотрена; если i-ый
            //элемент равен false, то i-ая вершина просмотрена

            public void NovSet() //метод помечает все вершины графа как непросмотреные
            {
                for (int i = 0; i < Size; i++)
                {
                    nov[i] = true;
                }
            }

            //конструктор вложенного класса, инициализирует матрицу смежности и
            // вспомогательный массив
            public Node(int[,] a)
            {
                array = a;
                nov = new bool[a.GetLength(0)];
            }


 

            public void AddTop(int N)
            {
                int[,] c = new int[Size+1, Size+1];

            }

           
        } //конец вложенного клаcса

        private Node graph; //закрытое поле, реализующее АТД «граф»

        public Graph(string name) //конструктор внешнего класса
        {
            using (StreamReader file = new StreamReader(name))
            {
                int n = int.Parse(file.ReadLine());
                int[,] a = new int[n, n];
                for (int i = 0; i < n; i++)
                {
                    string line = file.ReadLine();
                    string[] mas = line.Split(' ');
                    for (int j = 0; j < n; j++)
                    {
                        a[i, j] = int.Parse(mas[j]);
                    }
                }
                graph = new Node(a);
            }
        }

        //метод выводит матрицу смежности на консольное окно
        public void Show()
        {
            
            for (int i = 0; i < graph.Size; i++)
            {
                int count = 0;
                for (int j = 0; j < graph.Size; j++)
                {
                   
                    if (graph[i, j] != 0)
                        count++;
                    
                }
                Console.Write("Количество смежных вершин для вершины {1} {0}", count,i);
                Console.WriteLine();
            }
        }






    }
}
