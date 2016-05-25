

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace ConsoleApplication1
{
    public class BinaryTree
    {
        private class Node
        {
            public object inf; 
            public Node left; 
            public Node rigth; 

            public Node(object nodeInf)
            {
                inf = nodeInf;
                left = null;
                rigth = null;
            }

            public static void RotationRigth(ref Node t)
            {
                Node x = t.left;
                t.left = x.rigth; 
                x.rigth = t; 
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

            

            public static void Search(Node r, object key, out Node item)
            {
                if (r == null)
                {
                    item = null;
                }
                else
                {
                    if (((IComparable)(r.inf)).CompareTo(key) == 0)
                    {
                        item = r;
                    }
                    else
                    {
                        if (((IComparable)(r.inf)).CompareTo(key) > 0)
                        {
                            Search(r.left, key, out item);
                        }
                        else
                        {
                            Search(r.rigth, key, out item);
                        }
                    }
                }
            }

           

 

           
            public static void GetItemsOnALevel(Node t, int deep, ref int n, ref int counter)
            {
                if (t != null)
                {
                    if (deep == n)
                    {
                        Console.Write(t.inf+" "); 
                        counter++;
                    }
                    n++;
                    GetItemsOnALevel(t.left, deep, ref n, ref counter);
                    GetItemsOnALevel(t.rigth,  deep, ref n, ref counter);
                   
                    n--;
                }
            }

        }

        Node tree;

        public object Inf
        {
            set { tree.inf = value; }
            get { return tree.inf; }
        }

        public BinaryTree()
        {
            tree = null;
        }

        private BinaryTree(Node r)
        {
            tree = r;
        }

        public void Add(object nodeInf)
        {
            Node.Add(ref tree, nodeInf);
        }

        public void Preorder()
        {
            Node.Preorder(tree);
        }

        public BinaryTree Search(object key)
        {
            Node r;
            Node.Search(tree, key, out r);
            BinaryTree t = new BinaryTree(r);
            return t;
        }


        public void InsertToRoot(object item)
        {
            Node.InsertToRoot(ref tree, item);
        }

 
        public int ItemsOnAlevel(int deep)
        {
            int number = 0;
            int n = 0;
            Node.GetItemsOnALevel(tree, deep, ref n, ref number);
            Console.Write("Элементов на уровне "); 
            return number;
        }

    }
}