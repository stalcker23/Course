using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace BinaryTree.I._7
{

    class Program
    {
        static void Main()
        {
            int count = 0;
            BinaryTree tree = new BinaryTree(); //инициализируем дерево
            //на основе данных файла создаем дерево
            using (StreamReader fileIn = new StreamReader("C:/Users/1/Documents/Visual Studio 2010/Projects/Tree1.1/input.txt"))
            {
                string line = fileIn.ReadToEnd();
                string[] data = line.Split(' ');
                foreach (string item in data)
                {
                    tree.Add(int.Parse(item));
                }
            }
            count = tree.Preorder(count);
            Console.WriteLine("{0}", count);
        }
    }
}
