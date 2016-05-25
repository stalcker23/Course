using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
namespace Pract16.II
{

	public class MaxFlowFordFulkerson
	{

		public static int MaxFlow(int[, ] cap, int s, int t)
		{
			for (int flow = 0;;)
			{
				int df = FindPath(cap, new bool[cap.Length], s, t, Int32.MaxValue);
				if (df == 0)
					return flow;
				flow += df;
			}

		}

		public static int FindPath(int[, ] cap, bool[] vis, int u, int t, int f)
		{
			if (u == t)
				return f;
			vis[u] = true;
			for (int v = 0; v < vis.Length; v++)
				if (!vis[v] && cap[u, v] > 0)
				{
					int df = FindPath(cap, vis, v, t, Math.Min(f, cap[u, v]));
					if (df > 0)
					{
						cap[u, v] -= df;
						cap[v, u] += df;
						return df;
					}
				}
			return 0;
		}
		public static void Main() {


			int[, ] capacity = { { 0, 3, 2 }, { 0, 0, 2 }, { 0, 0, 0 } };
			int strange = MaxFlow(capacity, 0, 2);
			Console.WriteLine("{0}", strange);
		}
	}
}