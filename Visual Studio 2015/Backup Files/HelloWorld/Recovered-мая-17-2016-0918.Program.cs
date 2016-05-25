using HelloApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HelloApp.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press");
            Console.ReadLine();
            DoJob().Wait();
            Console.ReadLine();
        }
        static async Task DoJob()
        {

            using (var client = new HttpClient())
            {
                
                var response = await client.GetAsync("http://localhost:52566/api/Notes");
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var note = await response.Content.ReadAsAsync<AllVertices>();
                    

                    Console.WriteLine($"Note successfully read:");
                    foreach (var item in note.allVertices)
                    {
                        Console.Write(item.Key.ToString()+":");
                        foreach (var item1 in item.Value.ListOfRealted)
                        {
                            Console.Write(" "+item1.To+"("+ item1.Weight+") ");
                        }
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine($"Error:{response.StatusCode}.{response.ReasonPhrase}");
                }

            }
        }
        int Min(int A, int B)
        {
            int Result = (A < B) ? A : B;
            if ((A < 0) && (B >= 0)) Result = B;
            if ((B < 0) && (A >= 0)) Result = A;
            if ((A < 0) && (B < 0)) Result = -1;
            return Result;
        }

        void FloydWarshall(GraphMatrix gr, int[] up, int[] dist)
        {
           
            // переменные прохода по окрестности вершины графа
            int okr_s, okr_f, okr_i;
            int n = gr.sizeV;
            for (int i = 0; i < n * n; i++)
                dist[i] = -1;
            for (int i = 0; i < n; i++)
            {
                dist[i * n + i] = 0;
                up[i * n + i] = i;
            }

            for (int i = 0; i < n; i++)
            {
                okr_s = gr.pointerB[i];
                okr_f = gr.pointerB[i + 1];
                for (okr_i = okr_s; okr_i < okr_f; okr_i++)
                {
                    int j = gr.column[okr_i];
                    if (dist[i * n + j] > gr.value[okr_i])
                        dist[i * n + j] = gr.value[okr_i];
                    up[i * n + j] = i;     ///*****///
                }
            }
            int t1, t2;
            for (int k = 0; k < n; k++)
            {


                for (int i = 0; i < n; i++)
                    for (int j = 0; j < n; j++)
                        if ((dist[i * n + k] != -1) && (dist[k * n + j] != -1))
                        {
                            t1 = dist[i * n + j];
                            t2 = dist[i * n + k] + dist[k * n + j];
                            dist[i * n + j] = Min(t1, t2);
                            if (t2 == dist[i * n + j] && t1 != t2)
                            {
                                up[i * n + j] = up[k * n + j];
                            }
                        }
            }
        }
    }
}