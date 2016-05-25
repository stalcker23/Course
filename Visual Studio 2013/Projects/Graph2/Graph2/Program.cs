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
        
        public Graph(string name)
        {

            string file = @"C:/Users/Артем/Documents/Visual Studio 2013/output.txt";

            {
                string[] mas = File.ReadAllLines(name);
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
        }
        public void EqualGrafs()
        {
            string[] mas = File.ReadAllLines(@"C:/Users/Артем/Documents/Visual Studio 2013/output.txt");
            for (int i = 0; i < 2; i++)
            {
                string[] mas2 = mas[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            }
            Console.WriteLine("Графы одинаковы? {0}",String.Equals(mas[0], mas[1]));
        }
       
        
        public void Print()
        {
            List<int> degrees = new List<int>();
            List<int> vertices = new List<int>();
            string file = @"C:/Users/Артем/Documents/Visual Studio 2013/output.txt";
            
            foreach (var item in array)
            {
                Console.Write("{0}: ", item.Key);
                foreach (var i in item.Value)
                {
                    vertices.Add(i);
                    Console.Write("{0} ", i);
                }
                
                Console.WriteLine("  Степень вершины {0}", item.Value.Count);

                degrees.Add(item.Value.Count);
            }
            degrees.Sort();
            vertices.Sort();
            File.AppendAllText(file, String.Join("", degrees)+" "+String.Join("", vertices) + "\n", Encoding.UTF8);
        }
        public static void Main()
        {

            Dictionary<string, List<int>> array = new Dictionary<string, List<int>>();
            Graph g = new Graph("C:/Users/Артем/Documents/Visual Studio 2013/input1.txt");
            Graph f = new Graph("C:/Users/Артем/Documents/Visual Studio 2013/input2.txt");
            string key = "";
            var value = new List<int>();
            //g.AddVertex(key,value);
            g.Print();
            Console.WriteLine();
            f.Print();
            f.EqualGrafs();





        }

    }
}
