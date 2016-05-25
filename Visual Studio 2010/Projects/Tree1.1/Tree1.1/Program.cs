using System;
using System.IO;
namespace rim15z1
{
    class Program
    {
        static void Main()
        {
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
            tree.Preorder(); //используя прямой обход выводим на экран узлы дерева
            int s = 0;
            tree.Sum(ref s);
            Console.WriteLine("\nСумма нечетных значений узлов равна {0} ", s);
        }
    }
}

