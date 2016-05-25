using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _19.II
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {   
            double x;
            double a =  double.Parse(textBox1.Text);
            double b = double.Parse(textBox2.Text);
            if (a!=0)
            {
                x = -b / a;
                label3.Text = String.Format("Корень = {0}", x);
            }
            else if (b==0)
                 label3.Text = String.Format("Корень - любое число");
            else
                label3.Text = String.Format("Корней нет");

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
