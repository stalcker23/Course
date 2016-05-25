using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraphFlowExample{
 //get max flow from s to t
    public class FordFulkerson
    {
        Dictionary<Tuple<int, int>, int> dic = new Dictionary<Tuple<int, int>, int>();  //edge s to t, and its cost
        int[,] edgeArray;
        bool[] usedFlg;
        int maxIdx = -1;

        public void AddEdge(int s, int t, int flow){
            var tuple = new Tuple<int, int>(s, t);

            if (dic.ContainsKey(tuple))
            {
                dic[tuple] = dic[tuple] + flow;
            }
            else
            {
                dic.Add(tuple, flow);
            }

            maxIdx = Math.Max(Math.Max(maxIdx, s), t);
        }

        public void getEdgeArray(){
            edgeArray = new int[maxIdx + 1, maxIdx + 1];
            foreach (var edge in dic)
            {
                edgeArray[edge.Key.Item1, edge.Key.Item2] = edge.Value;
            }
        }
        public int getMaxFlow(int s, int t, int f)
        {
            if (s == t) return f;
            usedFlg[s] = true;

            for (int nextVertex = 0; nextVertex < maxIdx + 1; nextVertex++)
            {
                int capacity = edgeArray[s, nextVertex];
                if (usedFlg[nextVertex] == false && capacity > 0)
                {
                    int usedFlowCapacity = getMaxFlow(nextVertex, t, Math.Min(capacity, f));
                    if (usedFlowCapacity > 0)
                    {
                        edgeArray[s, nextVertex] -= usedFlowCapacity;
                        edgeArray[nextVertex, s] += usedFlowCapacity;
                        return usedFlowCapacity;
                    }
                }
            }
            return 0;
        }

        public int GetMaxFlow(int s, int t)
        {
            if (maxIdx == -1) return 0; //no path information

            int flow = 0;
            getEdgeArray();

            while (true)
            {
                usedFlg = new bool[maxIdx + 1];

                int f = getMaxFlow(s, t, Int32.MaxValue);
                if (f == 0) return flow;
                flow += f;
            }
        }

 
        public static void Main()
        {
            FordFulkerson k = new FordFulkerson();
            Dictionary<Tuple<int, int>, int> dic = new Dictionary<Tuple<int, int>, int>(); 
            var tuple1 = new Tuple<int, int>(0, 1);
            var tuple2 = new Tuple<int, int>(1, 2);
            dic.Add(tuple1, 1);
            dic.Add(tuple2, 2); 
            
            int t = k.GetMaxFlow(0,1);
            foreach (var item in dic)
            {
                Console.WriteLine("{0}: {1}", item.Key, String.Join(" ", item.Value));
            }
            Console.WriteLine("{0}",t);   
        }
    }

}