using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace КР
{
    public class BinaryTree //класс, реализующий АТД «дерево бинарного поиска»
    {
        //вложенный класс, отвечающий за узлы и операции допустимы для дерева бинарного
        //поиска

        private class Node
        {
            int counter;
            public object inf; //информационное поле
            public Node left; //ссылка на левое поддерево
            public Node rigth; //ссылка на правое поддерево
            //конструктор вложенного класса, создает узел дерева
            public Node(object nodeInf)
            {
                
                inf = nodeInf;
                left = null;
                rigth = null;
            }
            public static void Part(ref Node t, int k)
            {
                int x = (t.left == null) ? 0 : t.left.counter;
                if (x > k)
                {
                    Part(ref t.left, k);
                    RotationRigth(ref t);
                }
                if (x < k)
                {
                    Part(ref t.rigth, k - x - 1);
                    RotationLeft(ref t);
                }
            }
            public static void Balancer(ref Node t)
            {
                if (t == null || t.counter == 1) return; //если дерево пустое или узел-лист, то
                //балансировка закончена
                Part(ref t, t.counter / 2); //иначе вызываем метод, который помещает к-тый узел в
                //корень дерева (к= t.counter / 2)
                //затем балансируем левое и правое поддерево
                Balancer(ref t.left);
                Balancer(ref t.rigth);
            } 


            public static void RotationRigth(ref Node t)
            {
                Node x = t.left;
                t.left = x.rigth; //1
                x.rigth = t; //2
                t = x;
            }
            public static void RotationLeft(ref Node t)
            {
                Node x = t.rigth;
                t.rigth = x.left;
                x.left = t;
                t = x;
            }
            public static void InsertToRoot(ref Node t, object item)
            {
                if (t == null)
                {
                    t = new Node(item);
                }
                else if (((IComparable)(t.inf)).CompareTo(item) > 0)
                {
                    InsertToRoot(ref t.left, item);
                    RotationRigth(ref t);
                }
                else
                {
                    InsertToRoot(ref t.rigth, item);
                    RotationLeft(ref t);
                }
            }

          

            public static void InsertRandom(ref Node r, object nodeInf, Random rnd)
            {
                
                if (r == null) //если узел пустой, то производим создаем узел-лист
                {
                    r = new Node(nodeInf);
                }
                else //иначе, если достигается вероятность 1/(N+1), то производим вставку в корень
                {
                    if (rnd.Next() < int.MaxValue / (r.counter + 1))
                    {
                        InsertToRoot(ref r, nodeInf);
                    }
                    else //иначе продолжаем рекурсивный поиск местоположения нового узла
                    {
                        r.counter++;
                        if (((IComparable)(r.inf)).CompareTo(nodeInf) > 0)
                        {
                            Add(ref r.left, nodeInf);
                        }
                        else
                        {
                            Add(ref r.rigth, nodeInf);
                        }
                    }
                }
            }

            //добавляет узел в дерево так, чтобы дерево оставалось деревом бинарного поиска
            public static void Add(ref Node r, object nodeInf)
            {
                if (r == null)
                {
                    r = new Node(nodeInf);
                }
                else
                {
                    if (((IComparable)(r.inf)).CompareTo(nodeInf) > 0)
                    {
                        Add(ref r.left, nodeInf);
                    }
                    else
                    {
                        Add(ref r.rigth, nodeInf);
                    }
                }
            }


            public static void Preorder(Node r) //прямой обход дерева
            {
                if (r != null)
                {
                    Console.Write("{0} ", r.inf);
                    Preorder(r.left);
                    Preorder(r.rigth);
                }
            }






        }
        
        //конец вложенного класса
        Node tree; //ссылка на корень дерева
        //свойство позволяет получить доступ к значению информационного поля корня дерева
        public object Inf
        {
            set { tree.inf = value; }
            get { return tree.inf; }
        }

        public BinaryTree() //открытый конструктор
        {
            tree = null;
        }

        private BinaryTree(Node r) //закрытый конструктор
        {
            tree = r;
        }
        public void Balancer()
        {
            Node.Balancer(ref tree);
        }
        public void Add(object nodeInf) //добавление узла в дерево
        {
            Node.Add(ref tree, nodeInf);
        }
        public void InsertToRoot(object item)
        {
            Node.InsertToRoot(ref tree, item);
        } 


        public void InsertRandom(object nodeInf)
        {
            Random rnd = new Random();
            Node.InsertRandom(ref tree, nodeInf, rnd);
        }

        public void Preorder()
        {
            Node.Preorder(tree);
        }



        static void Main()
        {
            Stopwatch stopWatch = new Stopwatch();
            Random rand = new Random();

            int[] mas;
            int n = rand.Next(90, 101);
            mas = new int[n];
            for (int i = 0; i < n; i++)
            {
                mas[i] = rand.Next(int.MaxValue);
            }
            BinaryTree tree = new BinaryTree();
            foreach (int item in mas)
            {
                tree.Add(item);
            }
            tree.Preorder(); //выполняем прямой обход дерева
            stopWatch.Start();
            tree.Balancer();
            stopWatch.Stop();
            Console.WriteLine();
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            Console.WriteLine("RunTime " + ts);

        }
    }
}