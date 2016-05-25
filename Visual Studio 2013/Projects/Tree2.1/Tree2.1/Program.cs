using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main()
        {
            BinaryTree tree = new BinaryTree();
            StreamReader fileIn = new StreamReader("C:/Users/1/Documents/Visual Studio 2010/Projects/Tree1.1/input.txt");

            string line = fileIn.ReadToEnd();
            string[] data = line.Split(' ');
            foreach (string item in data)
            {
                tree.Add(int.Parse(item));
            }

            int n;
            Console.WriteLine("Введите номер уровня дерева: ");
            n = int.Parse(Console.ReadLine());

            Console.WriteLine(tree.ItemsOnAlevel(n));

            

            Console.ReadLine();
            fileIn.Close();
        }
    }

}