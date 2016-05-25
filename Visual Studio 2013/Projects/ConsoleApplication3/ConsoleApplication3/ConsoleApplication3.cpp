using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ConsoleApplication16
{
	public class MaxFlowFordFulkerson
	{
		Dictionary<string, int> dic = new Dictionary<string, int>();
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
			for (int v = 0; v < cap.GetLength(0); v++)
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

		static void Print(int[, ] mas)
		{

			for (int i = 0; i < mas.GetLength(0); i++)
			{
				for (int j = 0; j < mas.GetLength(1); j++)
				{
					Console.Write("{0} ", mas[i, j]);
				}
				Console.WriteLine();
			}
		}

		public static void Main(string[] args)
		{
			string file = File.ReadAllText("C:/Users/Мария/Documents/input.txt");
			int[] info = file.Split(new char[] { ' ', '\n' }, StringSplitOptions.RemoveEmptyEntries).Select(n = > int.Parse(n)).ToArray();
			string file1 = File.ReadAllText("C:/Users/Мария/Documents/input.txt");
			string[] info1 = file1.Split(new char[] { ' ', '\n' }, StringSplitOptions.RemoveEmptyEntries);

			int q = info[0];
			int[, ] MyArray = new int[q, q];
			Dictionary<string, int> dic = new Dictionary<string, int>();

			for (int i = 1; i <= q * 2; i++)
			{
				//работа с координатами и рисунок сети
			}

			int qLink = info[q * 2 + 1]; //16


			for (int i = q * 2 + 2; i <= q * 2 + qLink * 3 - 1; i++) //48. 48+16=64
			{
				string vsp = info1[i] + info1[i + 1];
				dic.Add(vsp, info[i + 2]);
			}

			foreach(KeyValuePair<string, int> kvp in dic)
			{
				string key = kvp.Key;
				string[] mas = key.Split(' ');
				int stock = int.Parse(mas[0]);
				int istock = int.Parse(mas[1]);
				MyArray[stock, istock] = kvp.Value;
			}

			for (int i = 0; i < q; i++)
			{
				for (int j = 0; j < q; j++)
				{
					Console.Write("{0} ", MyArray[i, j]);
				}
				Console.WriteLine();
			}

			int strange = MaxFlow(MyArray, 0, MyArray.GetLength(0) - 1);
			Console.WriteLine("{0}", strange);
		}
	}
}