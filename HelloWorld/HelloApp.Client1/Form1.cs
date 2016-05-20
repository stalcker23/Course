using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using HelloApp.Entities;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace HelloApp.Client1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            panel1.Text = "Press";
            
            DoJob(panel1).Wait();
            
        }
        public static async Task DoJob(Panel panel)
        {

            using (var client = new HttpClient())
            {

                var response = await client.GetAsync("http://localhost:52566/api/Notes", HttpCompletionOption.ResponseHeadersRead) 
.ConfigureAwait(false);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var note = await response.Content.ReadAsAsync<GraphMatrix>();
                    int[] up = new int[note.sizeV * note.sizeV];
                    int[] dist = new int[note.sizeV * note.sizeV];
                    
                    panel.Text = $"Note reading:";
                    FloydWarshall(note, up, dist);
                    using (StreamWriter outputFile = new StreamWriter(@"graphout.txt"))
                    {
                        for (int i = 0; i < note.sizeV; i++)
                        {
                            for (int j = 0; j < note.sizeV; j++)
                            {
                                outputFile.Write(dist[i * note.sizeV + j]);

                            }
                            outputFile.Write("\n");
                        }
                    }
                    panel.Text = $"Way";
                    Way(up, 1, 2, 3353,panel);
                    Way(up, 2, 6, 3353, panel);
                    Way(up, 2, 9, 3353, panel);
                    panel.Text = $"Note successfully read:";
                }
                else
                {
                    panel.Text = $"Error:{response.StatusCode}.{response.ReasonPhrase}";
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
        public static void Way(int[] up, int i, int j, int Size, Panel panel)
        {
            
            int k = up[i * Size + j];
            if (k != i) // путь существует
            {
                // и состоит более чем из двух вершин и проходит через вершину k, поэтому
                Way(up, i, k, Size, panel); // рекурсивно восстанавливаем путь между вершинами i и k
                panel.Text = " " + k;
                Way(up, k, j, Size, panel); // и рекурсивно восстанавливаем путь между k и j	
            }
        }

        public  void Form1_Load(object sender, EventArgs e)
        {

        }

        public void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
