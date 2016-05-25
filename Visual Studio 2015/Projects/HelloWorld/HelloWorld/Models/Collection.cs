using Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace Models
{
    public class Collection
    {
  
        public static List<TEdge> edges = new List<TEdge>();

        public static GraphMatrix graph { get; set; } = new GraphMatrix();
        
        static Collection()
        {
            string[] q = System.IO.File.ReadAllLines(ConfigurationManager.AppSettings["filePath"]);
            foreach (string line in q)
            {
                var myArray = line.Split(' ');
                edges.Add(new TEdge(int.Parse(myArray[0])-1, int.Parse(myArray[1])-1, int.Parse(myArray[2])));   
            }
            edges.Sort();
            for ( int i = 0; i != edges.Count - 1;)
            {
                int j = i + 1;
                if (((edges[i]).row == (edges[j]).row) && (edges[i].col == edges[j].col))
                {
                    if (edges[j].val < edges[i].val)
                        edges.Remove(edges[i]);
                    else
                    {
                        edges.Remove(edges[j]);
                        i--;
                    }
                }
                else
                    i++;
            }
            int sizeV = 3353;
            graph.sizeV = sizeV;
            graph.sizeE = edges.Count;
            graph.pointerB = new int[graph.sizeV + 1];
            graph.column = new int[graph.sizeE];
            graph.value = new int[graph.sizeE];
            foreach(var item in edges)
            {
                int row = item.row;
                graph.pointerB[row]++;
            }
            int sum = 0;
            for (int i = 0; i < graph.sizeV; i++)
            {
                int tmp = graph.pointerB[i];
                graph.pointerB[i] = sum;
                sum += tmp;
            }
            graph.pointerB[graph.sizeV] = sum;
            int[] counter = new int[graph.sizeV];
            for (int i = 0; i < graph.sizeV; i++)
                counter[i] = 0;
            foreach (var item in edges)
            {

                int pos;
                int row = item.row;
                int col = item.col;
                int val = item.val;
                pos = graph.pointerB[row] + counter[row];
                graph.column[pos] = col;
                graph.value[pos] = val;
                counter[row]++;
            }
        }   

    }
}