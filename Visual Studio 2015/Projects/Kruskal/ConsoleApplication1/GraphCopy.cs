using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pract16.II
{
    class GraphCopy : Graph
    {

        public List<Tuple<string, string>> Action()
        {
            Console.WriteLine("Введите количество удаляемых ребер");
            int count = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите пару смежных вершин (через пробел), между которыми требуется удалить ребро");
            var edges = new List<Tuple<string, string>>();
            for (int i = 0; i < count; i++)
            {
                string[] v = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var pair = Tuple.Create(v[0], v[1]);
                edges.Add(pair);
            }
            return edges;
        }

       public void CopyArray(Dictionary<string, List<int>> array1)
        {
            foreach (var kvp in array)
            {
                array1.Add(kvp.Key, kvp.Value);
            }

        }
        public Dictionary<string, List<int>> DeleteEdges()
        {

            CopyArray(array1);
            var edges = Action();
            foreach (var item in edges)
            {
                array1[item.Item1].Remove(Convert.ToInt32(item.Item2));
                array1[item.Item2].Remove(Convert.ToInt32(item.Item1));
            }

            foreach (var kvp in array)
            {
                Console.WriteLine("{0}: {1}",
                    kvp.Key, String.Join(" ", kvp.Value));
            }
            return array1;
        }
        public Dictionary<string, List<int>> DeleteEdges(List<Tuple<string, string>>  edges)
        {

            CopyArray(array1);
            foreach (var item in edges)
            {
                array1[item.Item1].Remove(Convert.ToInt32(item.Item2));
                array1[item.Item2].Remove(Convert.ToInt32(item.Item1)); 
            }

            foreach (var kvp in array1)
            {
                Console.WriteLine("{0}: {1}",
                    kvp.Key, String.Join(" ", kvp.Value));
            }
            return array1;
        }
         public void Parity()
        {
            var vertex_degrees = Degree();
            List<Tuple<string, string>> edges = new List<Tuple<string, string>>();

            foreach (var item in array)
            {
                foreach (var i in item.Value)
                    if ((vertex_degrees[i-1].Item2%2) != (vertex_degrees[Convert.ToInt32(item.Key)-1].Item2 % 2))
                    {
                        var edge = Tuple.Create(item.Key,i.ToString());
                        edges.Add(edge);
                    }
            }
            DeleteEdges(edges);
        } 
    }
}
