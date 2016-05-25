using System;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.IO;


namespace Kruskal
{
    public partial class Form1 : Form
    {
        public string k;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dictionary<string, List<int>> array = new Dictionary<string, List<int>>();
            List<Tuple<int, int>> res = new List<Tuple<int, int>>();
            Graph alg = new Graph(k);
            Graphics g = CMap.CreateGraphics();
            Graph graph = new Graph(k);
            res = graph.Kruskal();

            foreach (var item in res)
            {
                Thread.Sleep(1000);
                Pen pen = new Pen(Color.Yellow, 10);
                g.DrawLine(pen, (float)graph.array1Weighted[item.Item1].Item1.Item1, (float)graph.array1Weighted[item.Item1].Item1.Item2, (float)graph.array1Weighted[item.Item2].Item1.Item1, (float)graph.array1Weighted[item.Item2].Item1.Item2);

            }
        }
        private void CMap_Paint(object sender, PaintEventArgs e)
        {
            Graph alg = new Graph(k);
            Graphics g = CMap.CreateGraphics();
            Graph graph = new Graph(k);
            var res = alg.Kruskal();
            int vertices = graph.array1Weighted.Count;
            int edges;

            foreach (var item in graph.array1Weighted)
            {
                label(item.Key, item.Value.Item1.Item1, item.Value.Item1.Item2);
                foreach (var i in item.Value.Item2)
                {
                    Pen pen = new Pen(Color.Yellow, 3);

                    e.Graphics.DrawLine(pen, (float)item.Value.Item1.Item1, (float)item.Value.Item1.Item2, (float)graph.array1Weighted[i.Item1].Item1.Item1, (float)graph.array1Weighted[i.Item1].Item1.Item2);
                    weight(i.Item2, item.Value.Item1.Item1, item.Value.Item1.Item2, graph.array1Weighted[i.Item1].Item1.Item1, graph.array1Weighted[i.Item1].Item1.Item2);
                }
            }
            

        }
        private void tick(object sender, PaintEventArgs e)
        {
            Graph alg = new Graph(k);
            Graphics g = CMap.CreateGraphics();
            Graph graph = new Graph(k);
            var res = alg.Kruskal();
            foreach (var item in res)
            {
                
                Pen pen = new Pen(Color.Red, 6);
                e.Graphics.DrawLine(pen, (float)graph.array1Weighted[item.Item1].Item1.Item1, (float)graph.array1Weighted[item.Item1].Item1.Item2, (float)graph.array1Weighted[item.Item2].Item1.Item1, (float)graph.array1Weighted[item.Item2].Item1.Item2);

            }
            
        }
        private void label(int vertex,double x,double y)
        {
            Color myColor = Color.FromArgb(0, Color.White);
            
            Label label = new Label();
            label.BackColor = myColor;
            
            label.Text = vertex.ToString();
            label.Width = 40;
            label.Height = 23;
            label.Font = new Font("Times New Roman", 19, FontStyle.Italic);
            label.Location = new Point(Convert.ToInt32(x - 10), Convert.ToInt32(y - 10));

            CMap.Controls.Add(label);

        }
        private void weight(int vertex, double x1, double y1, double x2, double y2)
        {
            Color myColor = Color.FromArgb(0, Color.White);

            Label label1 = new Label();
            label1.BackColor = myColor;
            label1.Location = new Point(Convert.ToInt32(Math.Abs(x1-10+x2-10)/2), Convert.ToInt32(Math.Abs(y1-10 + y2-10)/2));
            label1.Text = vertex.ToString();
            label1.AutoSize = false;
            label1.Width=17;
            label1.Height = 17;

            label1.Font = new Font("Aerial", 10, FontStyle.Italic);

            CMap.Controls.Add(label1);

        }
        private void button2_Click(object sender, EventArgs e)
        {
            CMap.Visible = true;
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void инструкцияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Количество вершин не более 20");
        }

        private void авторToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Акимов A.A., КНиИТ, гр.341, 2015г.");
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void  button3_Click(object sender, EventArgs e)
        {
            

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                
                textBox1.Text = openFileDialog1.FileName;
                k = textBox1.Text;
            }
            
        }

        private void примерВходногоФайлаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("8\n1 2(32) 3(95) 4(75) 5(57)\n2 3(5) 5(23) 8(16)\n3 4(18) 6(6)\n4 5(24) 6(9)\n5 7(20) 8(94)\n6 5(11) 7(7)\n7 8(81)\n8");
        }

        private void menuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
