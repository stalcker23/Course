using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
namespace SerializeFigure
{
    [Serializable(), XmlInclude(typeof(Figure)), XmlInclude(typeof(Circle)), XmlInclude(typeof(Rectangle)), XmlInclude(typeof(Triangle))]
    public partial class Form1 : Form
    {
        public string k;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                textBox5.Text = openFileDialog1.FileName;
                k = textBox5.Text;
                
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       

        private void треугольникToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button4.Visible = false;
            button3.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
        }

        private void окружностьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button4.Visible = false;
            button3.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = false;
            textBox3.Visible = false;
        }

        private void прямоугольникToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button4.Visible = false;
            button3.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

       

        private void треугольникToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            button3.Visible = false;
            button4.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
        }

        private void окружностьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            button3.Visible = false;
            button4.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = false;
            textBox3.Visible = false;
        }

        private void прямоугольникToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            button3.Visible = false;
            button4.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button5.Visible = false;
            Vision.Serial(k);
        }

        private void button6_Click(object sender, EventArgs e)
        {
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (!button5.Visible)
            {
                Vision.ShowOn(k, e.Graphics, panel1);
            }
        }
    }
}
