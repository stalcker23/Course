using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20.II
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        static double psi(double xPrev)
        {
            double x = 1 / Math.Pow(xPrev+1, 0.5);
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



        private void button1_Click(object sender, EventArgs e)
        {


            double a = 0.1;
            double b = 1;
            double x = (a + b) / 2;
            label1.Text = String.Format("Корень = {0}", Solution(x));
            


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}