using HelloApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.IO;
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
                    var note = await response.Content.ReadAsAsync<GraphMatrix>();
                    int[] up = new int[note.sizeV * note.sizeV];
                    int[] dist = new int[note.sizeV * note.sizeV];
                    Console.WriteLine($"Note reading:");
                    FloydWarshall(note, up, dist);

                    Console.WriteLine($"Way");
                    Way(up, 1, 2, 3353);
                    Way(up, 2, 6, 3353);
                    Way(up, 2, 9, 3353);
                    Console.WriteLine($"Note successfully read:");
                }
                else
                {
                    Console.WriteLine($"Error:{response.StatusCode}.{response.ReasonPhrase}");
                }

            }
        }
        public static int Min(int A, int B)
        {
            int Result = (A < B) ? A : B;
            if ((A < 0) && (B >= 0)) Result = B;
            if ((B < 0) && (A >= 0)) Result = A;
            if ((A < 0) && (B < 0)) Result = -1;
            return Result;
        }

        public static void FloydWarshall(GraphMatrix gr, int[] up, int[] dist)
        {
            int j;
            // переменные прохода по окрестности вершины графа
            int okr_s, okr_f, okr_i;

            int n = gr.sizeV;

            for (int i = 0; i < n * n; i++)
            {
                dist[i] = int.MaxValue;
            }

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
                    j = gr.column[okr_i];
                    if (dist[i * n + j] > gr.value[okr_i])
                        dist[i * n + j] = gr.value[okr_i];
                    up[i * n + j] = i;
                }
            }

            for (int k = 0; k < n; k++)
                for (int i = 0; i < n; i++)
                    for (j = 0; j < n; j++)
                        if (dist[i * n + j] - dist[k * n + j] > dist[i * n + k])
                        {
                            dist[i * n + j] = dist[i * n + k] + dist[k * n + j];
                            up[i * n + j] = up[k * n + j];
                        }
        }
        public static void Way(int[] up, int i, int j, int Size)
        {

            int k = up[i * Size + j];
            if (k != i) // путь существует
            {
                // и состоит более чем из двух вершин и проходит через вершину k, поэтому
                Way(up, i, k, Size); // рекурсивно восстанавливаем путь между вершинами i и k
                Console.WriteLine(" "+k);
                Way(up, k, j, Size); // и рекурсивно восстанавливаем путь между k и j	
            }
        }
    }
}