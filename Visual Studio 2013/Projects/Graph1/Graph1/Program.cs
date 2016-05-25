using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Graph1
{
    class Graph
    {
        Dictionary<string, List<int>> array = new Dictionary<string, List<int>>();

        public Graph()
        {
            string[] mas = File.ReadAllLines(@"C:\Users\Артем\Documents\Visual Studio 2013/input.txt");
            int n = int.Parse(mas[0]);

            for (int i = 1; i < n + 1; i++)
            {
                string[] mas2 = mas[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                List<int> matr = new List<int>();
                for (int j = 1; j < mas2.Length; j++)
                {
                    matr.Add(int.Parse(mas2[j]));
                }
                array.Add(mas2[0], matr);
            }
        }

        public void AddVertex(string key, List<int> value)
        {
            key += int.Parse(Console.ReadLine());
            string[] v=Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);;

            for (int j = 0; j < v.Length; j++)
            {
                value.Add(int.Parse(v[j]));
            }
            array.Add(key, value);
           
        }
        public void Print()
        {
            foreach (var item in array)
            {
                Console.Write("{0}: ", item.Key);
                foreach (var i in item.Value)
                {
                    Console.Write("{0} ", i);
                }
                Console.WriteLine("  Степень вершины {0}",item.Value.Count);
            }
        }
        public static void Main()
        {
            Dictionary<string, List<int>> array = new Dictionary<string, List<int>>();
            Graph g = new Graph();
            string key="";
            var value = new List<int>();
            //g.AddVertex(key,value);
            g.Print();

           
           
        
        }

    }
}
