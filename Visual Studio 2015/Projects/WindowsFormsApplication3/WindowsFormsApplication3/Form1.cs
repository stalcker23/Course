using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {
        public static List<Trio> masTrio = new List<Trio>();
        public static List<int> vertex = new List<int>();
        public Form1()
        {
            InitializeComponent();
        }
        

        public static void returnAllCoordinates()
        {
            for (int j = 0; j < 200; j++)
            {
                vertex.Add(j);
            }
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
        
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
            Pen blackPen = new Pen(Brushes.Black, 10);
            returnAllCoordinates();
            for (int i = 0; i < masTrio.Count - 1; i++)
            {
                PointF point = new PointF(Convert.ToInt32(masTrio[i].x + 5), Convert.ToInt32(masTrio[i].y - 20));
                e.Graphics.DrawLine(blackPen, masTrio[i].x, masTrio[i].y, masTrio[i].x+1, masTrio[i].y);
                e.Graphics.DrawLine(Pens.Black, masTrio[i].x, masTrio[i].y, masTrio[i + 1].x, masTrio[i + 1].y);
                e.Graphics.DrawString(masTrio[i].vertex.ToString(), new Font("Aerial", 10),Brushes.Black,point);

            }
            PointF pointLast = new PointF(Convert.ToInt32(masTrio[masTrio.Count - 1].x + 5), Convert.ToInt32(masTrio[masTrio.Count - 1].y - 20));
            e.Graphics.DrawString(masTrio[masTrio.Count-1].vertex.ToString(), new Font("Aerial", 10), Brushes.Black, pointLast);
            e.Graphics.DrawLine(blackPen, masTrio[masTrio.Count - 1].x, masTrio[masTrio.Count - 1].y, masTrio[masTrio.Count - 1].x + 1, masTrio[masTrio.Count - 1].y);

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
