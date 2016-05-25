using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Entities;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Client.DrawWay
{
    
    public partial class Form1 : Form
    {
        public static List<Trio> masTrio = new List<Trio>();
        public static List<int> vertex = new List<int>();
        public Form1()
        {
            InitializeComponent();
                     
            DoJob().Wait();

            
        }
        public static async Task DoJob()
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
                    FloydWarshall(note, up, dist);
                    Way(up, 100, 2000, 3353);
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
                vertex.Add(k + 1);
                Way(up, k, j, Size); // и рекурсивно восстанавливаем путь между k и j	
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

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        
        public static void returnAllCoordinates()
        {
           
            int i = 0;
            float x = 30;
            float y = 30;
            foreach (var item in vertex)
            {
                i++;
                if (i == 1)
                {
                    masTrio.Add(new Trio(x, y, item));
                }
                else if (i < 16)
                {
                    x += 40;
                    masTrio.Add(new Trio(x, y, item));
                }
                else if (i == 16)
                {
                    y += 60;
                    masTrio.Add(new Trio(x, y, item));
                }
                else if (i < 31)
                {
                    x -= 40;
                    masTrio.Add(new Trio(x, y, item));
                }
                else if (i == 31)
                {
                    i = 1;
                    y += 60;
                    masTrio.Add(new Trio(x, y, item));
                }
            }

        }


        private void panel1_Paint_2(object sender, PaintEventArgs e)
        {
            Pen blackPen = new Pen(Brushes.Black, 10);
            returnAllCoordinates();
            for (int i = 0; i < masTrio.Count - 1; i++)
            {
                PointF point = new PointF(Convert.ToInt32(masTrio[i].x + 5), Convert.ToInt32(masTrio[i].y - 20));
                e.Graphics.DrawLine(blackPen, masTrio[i].x, masTrio[i].y, masTrio[i].x + 1, masTrio[i].y);
                e.Graphics.DrawLine(Pens.Black, masTrio[i].x, masTrio[i].y, masTrio[i + 1].x, masTrio[i + 1].y);
                e.Graphics.DrawString(masTrio[i].vertex.ToString(), new Font("Aerial", 10), Brushes.Black, point);

            }
            PointF pointLast = new PointF(Convert.ToInt32(masTrio[masTrio.Count - 1].x + 5), Convert.ToInt32(masTrio[masTrio.Count - 1].y - 20));
            e.Graphics.DrawString(masTrio[masTrio.Count - 1].vertex.ToString(), new Font("Aerial", 10), Brushes.Black, pointLast);
             e.Graphics.DrawLine(blackPen, masTrio[masTrio.Count - 1].x, masTrio[masTrio.Count - 1].y, masTrio[masTrio.Count - 1].x + 1, masTrio[masTrio.Count - 1].y);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
