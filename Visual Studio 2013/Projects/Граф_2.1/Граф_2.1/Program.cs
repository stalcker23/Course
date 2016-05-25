using System;
using System.IO;
using System.Collections;
using System.Text;
namespace Example
{
    class Program
    {
        static void Main()
        {
            Graph g = new Graph("C:/Users/1/Documents/Visual Studio 2013/input.txt");
            Console.WriteLine("Graph:");
            g.Show();

            Console.WriteLine();
            Console.WriteLine("Floyd:");
            g.Floyd();
        }
    }
    public class Stack
    {
        private class Node //вложенный класс, реализующий элемент стека
        {
            private object inf;
            private Node next;
            public Node(object nodeInfo)
            {
                inf = nodeInfo;
                next = null;
            }
            public Node Next
            {
                get { return next; }
                set { next = value; }
            }
            public object Inf
            {
                get { return inf; }
                set { inf = value; }
            }
        } //конец класса Node
        private Node head; //ссылка на вершину стека
        public Stack() //конструктор класса, создает пустой стек
        {
            head = null;
        }
        public void Push(object nodeInfo) // добавляет элемент в вершину стека
        {
            Node r = new Node(nodeInfo);
            r.Next = head;
            head = r;
        }
        public object Pop() //извлекает элемент из вершины стека, если он не пуст
        {
            if (head == null)
            {
                throw new Exception("Стек пуст");
            }
            else
            {
                Node r = head;
                head = r.Next;
                return r.Inf;
            }
        }
        public bool IsEmpty //определяет пуст или нет стек
        {
            get
            {
                if (head == null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
    public class Queue
    {
        private class Node //вложенный класс, реализующий базовый элемент очереди
        {
            private object inf;
            private Node next;
            public Node(object nodeInfo)
            {
                inf = nodeInfo;
                next = null;
            }
            public Node Next
            {
                get { return next; }
                set { next = value; }
            }
            public object Inf
            {
                get { return inf; }
                set { inf = value; }
            }
        } //конец класса Node
        private Node head;
        private Node tail;
        public Queue()
        {
            head = null;
            tail = null;
        }
        public void Add(object nodeInfo)
        {
            Node r = new Node(nodeInfo);
            if (head == null)
            {
                head = r;
                tail = r;
            }
            else
            {
                tail.Next = r;
                tail = r;
            }
        }
        public object Take()
        {
            if (head == null)
            {
                throw new Exception("Очередь пуста.");
            }
            else
            {
                Node r = head;
                head = head.Next; if (head == null)
                {
                    tail = null;
                }
                return r.Inf;
            }
        }
        public bool IsEmpty
        {
            get
            {
                if (head == null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
    public class Graph
    {
        private class Node //вложенный класс для скрытия данных и алгоритмов
        {
            private int[,] array; //матрица смежности
            private static string[] s;

            public string this[int i]
            {
                get
                {
                    return s[i];
                }
            }
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
            public Node(int[,] a, string[] p)
            {
                s = p;
                array = a;
                nov = new bool[a.GetLength(0)];
            }


            //реализация алгоритма Флойда
            public long[,] Floyd(out int[,] p)
            {
                int i, j, k;
                //создаем массивы р и а
                long[,] a = new long[Size, Size];
                p = new int[Size, Size];
                for (i = 0; i < Size; i++)
                {
                    for (j = 0; j < Size; j++)
                    {
                        if (i == j)
                        {
                            a[i, j] = 0;
                        }
                        else
                        {
                            if (array[i, j] == 0)
                            {
                                a[i, j] = int.MaxValue;
                            }
                            else
                            {
                                a[i, j] = array[i, j];
                            }
                        }
                        p[i, j] = -1;
                    }
                }
                //осуществляем поиск кратчайших путей
                for (k = 0; k < Size; k++)
                {
                    for (i = 0; i < Size; i++)
                    {
                        for (j = 0; j < Size; j++)
                        {
                            long distance = a[i, k] + a[k, j];
                            if (a[i, j] > distance)
                            {
                                a[i, j] = distance;
                                p[i, j] = k;
                            }
                        }
                    }
                }
                return a;//в качестве результата возвращаем массив кратчайших путей между
            } //всеми парами вершин
            //восстановление пути от вершины a до вершины в для алгоритма Флойда
            public bool WayFloyd(int a, int b, int[,] p, ref Queue items)
            {
                int k = p[a, b];
                //если k<> -1, то путь состоит более чем из двух вершин а и b, и проходит через
                //вершину k, поэтому
                if (k != -1)
                {
                    // рекурсивно восстанавливаем путь между вершинами а и k
                    WayFloyd(a, k, p, ref items);
                    items.Add(k); //помещаем вершину к в очередь
                    // рекурсивно восстанавливаем путь между вершинами k и b
                    WayFloyd(k, b, p, ref items);
                    return false;
                }
                else return true;
            }
            public string name(int v)
            {
                return s[v]; 
            }
        }
        private Node graph; //закрытое поле, реализующее АТД «граф»
        public Graph(string name) //конструктор внешнего класса
        {
            using (StreamReader file = new StreamReader(name, Encoding.GetEncoding(1251)))
            {
                int n = int.Parse(file.ReadLine());
                string[] p = new string[n];
                string line = file.ReadLine();
                p = line.Split(' ');
                int[,] a = new int[n, n];
                for (int i = 0; i < n; i++)
                {
                    line = file.ReadLine();
                    string[] mas = line.Split(' ');
                    for (int j = 0; j < n; j++)
                    {
                        a[i, j] = int.Parse(mas[j]);
                    }
                }
                graph = new Node(a, p);
            }
        }

        //метод выводит матрицу смежности на консольное окно
        public void Show()
        {
            for (int i = 0; i < graph.Size; i++)
            {
                for (int j = 0; j < graph.Size; j++)
                {
                    Console.Write("{0,4}", graph[i, j]);
                }
                Console.WriteLine();
            }
        }

        public void Floyd()
        {
            int[,] p;
            long[,] a = graph.Floyd(out p); //запускаем алгоритм Флойда
            int i, j;
            //анализируем полученные данные и выводим их на экран
            for (i = 0; i < graph.Size; i++)
            {
                for (j = 0; j < graph.Size; j++)
                {
                    if (i != j)
                    {
                        if (a[i, j] == int.MaxValue)
                        {
                            Console.WriteLine("Пути из вершины {0} в вершину {1} не существует", graph.name(i), graph.name(j));
                        }
                        else
                        {
                            Console.Write("Кратчайший путь от вершины {0} до вершины {1} равен {2}, ", graph.name(i), graph.name(j), a[i, j]);
                            Console.Write(" путь ");
                            Queue items = new Queue();
                            items.Add(i);
                            graph.WayFloyd(i, j, p, ref items);
                            items.Add(j);
                            while (!items.IsEmpty)
                            {
                                Console.Write("{0} ", items.Take());
                            }
                            Console.WriteLine();
                        }
                    }
                }
            }
        }
    }
}

