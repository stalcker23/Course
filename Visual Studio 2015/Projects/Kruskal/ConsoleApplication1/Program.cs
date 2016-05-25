using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using QuickGraph;
using System.Diagnostics;
namespace Pract16.II
{
    class Program
    {

        public static void Main()
        {


            Dictionary<string, List<int>> array = new Dictionary<string, List<int>>();
            //var value = new List<int>();
            Graph g = new Graph();

            string key;
            string needed;
            array = g.Print();

            //g.Degree();
            g.Acycle();
            //g.AddVertex(key, value);
            //g.Print();

            //g.Way(out key,out needed);
            //g.Print();
            //g.Kruskal();
            //g.Perifery(out key);
            //g.MaxFlow(1,8);
             //g.Parity();

        }
    }
}