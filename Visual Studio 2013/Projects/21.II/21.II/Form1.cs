using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _21.II
{
    public partial class Form1 : Form
    {
        public static double Function(double x)
        {
            return (x * x + 5 * x + 6) * Math.Cos(2 * x);
        }

        public static double LeftRectangle(double a, double b, int n)
        {
            double res = 0;
            double h = (b - a) / (double)n;

            for (int i = 0; i < n; i++)
                res += Function(a + i * h);

            res *= h;

            return res;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n = 1000;
            int n2 = 100;
            double ideal = 1.60254;
            double a = -2, b = 0;
            double res = LeftRectangle(a, b, n);
            double res2 = LeftRectangle(a, b, n2);
            label1.Text = String.Format("{0} при n=1000,  {1} при n=100", res,res2);
            double Abs = Math.Abs(ideal - res);
            double Abs2 = Math.Abs(ideal - res2);
            double Otnos=Abs/res*100;
            double Otnos2=Abs/res2*100;
            label2.Text = String.Format("АП при n= 1000 {0}   ОП {1},", Abs,Otnos);

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
