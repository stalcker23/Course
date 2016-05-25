using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleIterate
{
    public partial class Form1 : Form
    {
        public static double a = 0.1;
        public static double b = 1;
        public static double x = (a + b) / 2;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        static double psi(double xPrev)
        {
            double x = 1 / Math.Pow(xPrev + 1, 0.5);
            return x;

        }


        static double Solution(double x)
        {
            double xPrev = 0;
            do
            {
                xPrev = x;
                x = psi(xPrev);
            }
            while (Math.Abs(x - xPrev) > 0.000001);
            return x;
        }




        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            double k;
            label1.Text = String.Format("Корень = {0}", Solution(x));
            label2.Text = String.Format("Проверка= {0}", k = Math.Log(Solution(x)) + Math.Pow(x + 1, 3));
        }

        private void label2_Click(object sender, EventArgs e)
        {
             
            
        }
    }
}
