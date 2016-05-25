using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kruskal
{
    class Graph
    {
        public Dictionary<string, List<int>> array = new Dictionary<string, List<int>>();
        public Dictionary<string, List<int>> array1 = new Dictionary<string, List<int>>();
        public List<Tuple<int, Tuple<int, int>>> arrayWeighted = new List<Tuple<int, Tuple<int, int>>>();
        public Dictionary<int,Tuple<Tuple<double, double>, List<Tuple<int, int>>>> array1Weighted = new Dictionary<int, Tuple<Tuple<double, double>, List<Tuple<int, int>>>>();

        public double d = 300;
        public double dx = 600 / 2;
        public double dy = 600 / 2;
        public double r = 250;
        public double r0 = 5;
        public List<int> cl = new List<int>();
        public List<int> p = new List<int>();
        public List<bool> u = new List<bool>();

        int cost = 0;
        int iterator = 0;
        int n;
        bool WeightedOrNot = false;
        public Graph(Graph previousGraph)
        {
            array = previousGraph.array; ;
        }

        public Graph(string key)
        {
            
            string[] mas = File.ReadAllLines(key);
            n = int.Parse(mas[0]);
            if (!mas[2].Contains(")"))
            {
                WeightedOrNot = true;
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
            else
            {
                string[] m;

                for (int i = 1; i < n + 1; i++)
                {
                    string[] mas2 = mas[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    List<Tuple<int, int>> matr = new List<Tuple<int, int>>();
                    for (int j = 1; j < mas2.Length; j++)
                    {
                        m = mas2[j].Split(new char[] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
                        Tuple<int, int> pair = Tuple.Create(int.Parse(m[0]), int.Parse(m[1]));
                        matr.Add(pair);
                    }
                    double x = r * Math.Cos(2 * Math.PI * i / n - Math.PI / 2) + dx;
                    double y = r * Math.Sin(2 * Math.PI * i / n - Math.PI / 2) + dy;
                    Tuple<double, double> coordinates = new Tuple<double, double>(x,y);
                    Tuple <Tuple< double, double>, List<Tuple<int, int>>> vertex = new Tuple<Tuple<double, double>, List<Tuple<int, int>>>(coordinates,matr);
                      array1Weighted.Add(int.Parse(mas2[0]), vertex);
                }
                foreach (var item in array1Weighted)
                {
                    
                    foreach (var i in item.Value.Item2)
                    {
                        Tuple<int, int> newPart = new Tuple<int, int>(item.Key, i.Item1);
                        Tuple<int, Tuple<int, int>> newItem = new Tuple<int, Tuple<int, int>>(i.Item2, newPart);
                        arrayWeighted.Add(newItem);
                    }
                }
            }
        }

        public List<Tuple<int,int>> Kruskal()
        {
            arrayWeighted.Sort();
            List<int> tree_id = new List<int>();
            List<Tuple<int, int>> res = new List<Tuple<int, int>>();
            for (int i = 0; i < arrayWeighted.Count + 1; i++)
                tree_id.Add(i);

            foreach (var kvp in arrayWeighted)
            {
                int a = kvp.Item2.Item1;
                int b = kvp.Item2.Item2;
                int l = kvp.Item1;
                if (tree_id[a] != tree_id[b])
                {
                    cost += l;
                    res.Add(Tuple.Create(a, b));
                    int old_id = tree_id[a], new_id = tree_id[b];
                    for (int j = 0; j < arrayWeighted.Count; ++j)
                        if (tree_id[j] == old_id)
                            tree_id[j] = new_id;
                }
            }
            return res;

        }
    }
}
