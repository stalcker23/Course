using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;


namespace Race
{

    public partial class Form1 : Form
    {


        public string path = @"Record.txt";
        private bool pauseEnabled = false;
        public Form1()
        {
            InitializeComponent();
            car1.Visible = false;
            car2.Visible = false;
            pictureBox3.Visible = false;

            oil1.Visible = false;
            oil2.Visible = false;
            oil3.Visible = false;
            progressBar1.Value = 100;
            progressBar1.Visible = false;
            oil1.Location = new Point(400, 0);
            oil2.Location = new Point(400, 0);
            oil3.Location = new Point(400, 0);
            bomba1.Visible = false;
            bomba2.Visible = false;
            bomba3.Visible = false;
            bomba1.Location = new Point(400, 0);
            bomba2.Location = new Point(400, 0);
            bomba3.Location = new Point(400, 0);
            star.Location = new Point(400, 0);
            star.Visible = false;

        }
        bool drag = false;
        int mousex, mousey;
        int score, t = 0, d = 0, can1 = 17, can2 = 36, can3 = 55, bom1 = 7, bom2 = 25, bom3 = 68, sta = 2;
        Random nr = new Random();
        private void pictureBox3_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void recordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
               int k = 0;
            List<Tuple<int,string>> result = new List<Tuple< int, string>>();

            string[] records = File.ReadAllLines(@"Record.txt");
            for (int i = 0; i < records.GetLength(0); i++)
            {
                
                string[] record = records[i].Split(new Char[] { ' ' });
                result.Add(Tuple.Create(Convert.ToInt32(record[0]),record[1]));
            }
            result.Sort();
            result.Reverse();
            string[] copyresult = new string[10];
            for (int i = 1; i<11; i++)
            {
                
                copyresult[i-1] = i + ". " + String.Join("",result[i-1].Item1)+" " + String.Join("", result[i-1].Item2);
            }
            MessageBox.Show("Рекорды\n"+ String.Join("\r\n",copyresult));
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            mousex = Cursor.Position.X - pictureBox3.Left;
            mousey = Cursor.Position.Y - pictureBox3.Top;
        }

        private void pictureBox3_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag == true)
                pictureBox3.Location = new Point(Cursor.Position.X - mousex, Cursor.Position.Y - mousey);
            if (pictureBox3.Location.X < 0 || pictureBox3.Location.X > 254 || pictureBox3.Location.Y < 5 || pictureBox3.Location.Y > 500)
            {
                timer1.Enabled = false;
                timer2.Enabled = false;
                timer3.Enabled = false;
                //timer4.Enabled = false;
                timer5.Enabled = false;
                pictureBox3.Location = new Point(120, 440);
                car1.Location = new Point(12, 27);
                car2.Location = new Point(102, 27);
                car1.Visible = false;
                car2.Visible = false;
                pictureBox3.Visible = false;
                label1.Visible = false;
                line1.Visible = true;
                line2.Visible = true;
                line3.Visible = true;
                line4.Visible = true;
                line5.Visible = true;
                line6.Visible = true;
                line7.Visible = true;
                line8.Visible = true;
                oil1.Visible = false;
                oil2.Visible = false;
                oil3.Visible = false;
                bomba1.Visible = false;
                bomba2.Visible = false;
                bomba3.Visible = false;
                progressBar1.Visible = false;
                star.Visible = false;
                MessageBox.Show("Ваш результат " + score.ToString());
                string record = score+" "+ textBox1.Text;
                File.AppendAllText(path, record, Encoding.UTF8);
                File.AppendAllText(path, "\r\n", Encoding.UTF8);

            }
            if (pictureBox3.Bounds.Contains(car1.Location) || car1.Bounds.Contains(pictureBox3.Location))
            {
                timer1.Enabled = false;
                timer2.Enabled = false;
                timer3.Enabled = false;
                //timer4.Enabled = false;
                timer5.Enabled = false;
                pictureBox3.Location = new Point(120, 440);
                car1.Location = new Point(12, 27);
                car2.Location = new Point(102, 27);
                car1.Visible = false;
                car2.Visible = false;
                pictureBox3.Visible = false;
                label1.Visible = false;
                line1.Visible = true;
                line2.Visible = true;
                line3.Visible = true;
                line4.Visible = true;
                line5.Visible = true;
                line6.Visible = true;
                line7.Visible = true;
                line8.Visible = true;
                oil1.Visible = false;
                oil2.Visible = false;
                oil3.Visible = false;
                bomba1.Visible = false;
                bomba2.Visible = false;
                bomba3.Visible = false;
                progressBar1.Visible = false;
                star.Visible = false;
                MessageBox.Show("Ваш результат " + score.ToString());
                string record = score + " " + textBox1.Text;
                File.AppendAllText(path, record, Encoding.UTF8);
                File.AppendAllText(path, "\r\n", Encoding.UTF8);
            }
            if (pictureBox3.Bounds.Contains(car2.Location) || car2.Bounds.Contains(pictureBox3.Location))
            {
                timer1.Enabled = false;
                timer2.Enabled = false;
                timer3.Enabled = false;
                //timer4.Enabled = false;
                timer5.Enabled = false;
                pictureBox3.Location = new Point(120, 440);
                car1.Location = new Point(12, 27);
                car2.Location = new Point(102, 27);
                car1.Visible = false;
                car2.Visible = false;
                pictureBox3.Visible = false;
                label1.Visible = false;
                line1.Visible = true;
                line2.Visible = true;
                line3.Visible = true;
                line4.Visible = true;
                line5.Visible = true;
                line6.Visible = true;
                line7.Visible = true;
                line8.Visible = true;
                oil1.Visible = false;
                oil2.Visible = false;
                oil3.Visible = false;
                bomba1.Visible = false;
                bomba2.Visible = false;
                bomba3.Visible = false;
                progressBar1.Visible = false;
                star.Visible = false;
                MessageBox.Show("Ваш результат " + score.ToString());
                string record = score + " " + textBox1.Text;
                File.AppendAllText(path, record, Encoding.UTF8);
                File.AppendAllText(path, "\r\n", Encoding.UTF8);
            }
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            timer1.Enabled = true;
            timer2.Enabled = true;
            timer3.Enabled = true;
            //timer4.Enabled = true;
            timer5.Enabled = true;
            car1.Visible = true;
            car2.Visible = true;
            pictureBox3.Visible = true;
            label1.Visible = true;
            car1.Location = new Point(0, 27);
            car2.Location = new Point(202, 287);
            pictureBox3.Location = new Point(120, 440);
            oil1.Visible = false;
            oil2.Visible = false;
            oil3.Visible = false;
            score = 0;
            d = 0;
            t = 0;
            bomba1.Location = new Point(400, 0);
            bomba2.Location = new Point(400, 0);
            bomba3.Location = new Point(400, 0);
            progressBar1.Visible = true;
            progressBar1.Value = 100;
            drag = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            car1.Location = new Point(car1.Location.X, car1.Location.Y + 5);
            int n = nr.Next(1, 4);
            if (car1.Location.Y > 480 && n == 1)
            {
                car1.Location = new Point(12, 0);
            }
            if (car1.Location.Y > 480 && n == 2)
            {
                car1.Location = new Point(102, 0);
            }
            if (car1.Location.Y > 480 && n == 3)
            {
                car1.Location = new Point(200, 0);
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Random mr = new Random();
            car2.Location = new Point(car2.Location.X, car2.Location.Y + 5);
            int m = mr.Next(1, 4);
            if (car2.Location.Y > 480 && m == 1)
            {
                car2.Location = new Point(12, 0);
            }
            if (car2.Location.Y > 480 && m == 2)
            {
                car2.Location = new Point(102, 0);
            }
            if (car2.Location.Y > 480 && m == 3)
            {
                car2.Location = new Point(200, 0);
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {

            score = score + 1;
            label1.Text = "Результат " + score.ToString();
            if (pictureBox3.Bounds.Contains(car1.Location) || car1.Bounds.Contains(pictureBox3.Location))
            {
                timer1.Enabled = false;
                timer2.Enabled = false;
                timer3.Enabled = false;
                //timer4.Enabled = false;
                timer5.Enabled = false;
                pictureBox3.Location = new Point(120, 440);
                car1.Location = new Point(12, 27);
                car2.Location = new Point(102, 27);
                car1.Visible = false;
                car2.Visible = false;
                pictureBox3.Visible = false;
                label1.Visible = false;
                line1.Visible = true;
                line2.Visible = true;
                line3.Visible = true;
                line4.Visible = true;
                line5.Visible = true;
                line6.Visible = true;
                line7.Visible = true;
                line8.Visible = true;
                oil1.Visible = false;
                oil2.Visible = false;
                oil3.Visible = false;
                bomba1.Visible = false;
                bomba2.Visible = false;
                bomba3.Visible = false;
                progressBar1.Visible = false;
                star.Visible = false;
                MessageBox.Show("Ваш результат " + score.ToString());
                string record = score + " " + textBox1.Text;
                File.AppendAllText(path, record, Encoding.UTF8);
                File.AppendAllText(path, "\r\n", Encoding.UTF8);

            }
            if (pictureBox3.Bounds.Contains(car2.Location) || car2.Bounds.Contains(pictureBox3.Location))
            {
                timer1.Enabled = false;
                timer2.Enabled = false;
                timer3.Enabled = false;
                //timer4.Enabled = false;
                timer5.Enabled = false;
                pictureBox3.Location = new Point(120, 440);
                car1.Location = new Point(12, 27);
                car2.Location = new Point(102, 27);
                car1.Visible = false;
                car2.Visible = false;
                pictureBox3.Visible = false;
                label1.Visible = false;
                line1.Visible = true;
                line2.Visible = true;
                line3.Visible = true;
                line4.Visible = true;
                line5.Visible = true;
                line6.Visible = true;
                line7.Visible = true;
                line8.Visible = true;
                oil1.Visible = false;
                oil2.Visible = false;
                oil3.Visible = false;
                bomba1.Visible = false;
                bomba2.Visible = false;
                bomba3.Visible = false;
                progressBar1.Visible = false;
                star.Visible = false;
                MessageBox.Show("Ваш результат " + score.ToString());
                string record = score + " " + textBox1.Text;
                File.AppendAllText(path, record, Encoding.UTF8);
                File.AppendAllText(path, "\r\n", Encoding.UTF8);
            }

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                pictureBox3.Location = new Point(pictureBox3.Location.X, pictureBox3.Location.Y - 15);
            if (e.KeyCode == Keys.Down)
                pictureBox3.Location = new Point(pictureBox3.Location.X, pictureBox3.Location.Y + 15);
            if (e.KeyCode == Keys.Left)
                pictureBox3.Location = new Point(pictureBox3.Location.X - 15, pictureBox3.Location.Y);
            if (e.KeyCode == Keys.Right)
                
            pictureBox3.Location = new Point(pictureBox3.Location.X + 15, pictureBox3.Location.Y);
            if (pictureBox3.Bounds.Contains(car1.Location) || car1.Bounds.Contains(pictureBox3.Location))
            {
                timer1.Enabled = false;
                timer2.Enabled = false;
                timer3.Enabled = false;
                //timer4.Enabled = false;
                timer5.Enabled = false;
                pictureBox3.Location = new Point(120, 440);
                car1.Location = new Point(12, 27);
                car2.Location = new Point(102, 27);
                car1.Visible = false;
                car2.Visible = false;
                pictureBox3.Visible = false;
                label1.Visible = false;
                line1.Visible = true;
                line2.Visible = true;
                line3.Visible = true;
                line4.Visible = true;
                line5.Visible = true;
                line6.Visible = true;
                line7.Visible = true;
                line8.Visible = true;
                oil1.Visible = false;
                oil2.Visible = false;
                oil3.Visible = false;
                progressBar1.Visible = false;
                bomba1.Visible = false;
                bomba2.Visible = false;
                bomba3.Visible = false;
                star.Visible = false;
                MessageBox.Show("Ваш результат " + score.ToString());
                string record = score + " " + textBox1.Text;
                File.AppendAllText(path, record, Encoding.UTF8);
                File.AppendAllText(path, "\r\n", Encoding.UTF8);
            }
            if (pictureBox3.Bounds.Contains(car2.Location) || car2.Bounds.Contains(pictureBox3.Location))
            {
                timer1.Enabled = false;
                timer2.Enabled = false;
                timer3.Enabled = false;
                //timer4.Enabled = false;
                timer5.Enabled = false;
                pictureBox3.Location = new Point(120, 440);
                car1.Location = new Point(12, 27);
                car2.Location = new Point(102, 27);
                car1.Visible = false;
                car2.Visible = false;
                pictureBox3.Visible = false;
                label1.Visible = false;
                line1.Visible = true;
                line2.Visible = true;
                line3.Visible = true;
                line4.Visible = true;
                line5.Visible = true;
                line6.Visible = true;
                line7.Visible = true;
                line8.Visible = true;
                oil1.Visible = false;
                oil2.Visible = false;
                oil3.Visible = false;
                progressBar1.Visible = false;
                bomba1.Visible = false;
                bomba2.Visible = false;
                bomba3.Visible = false;
                star.Visible = false;
                MessageBox.Show("Ваш результат " + score.ToString());
                string record = score + " " + textBox1.Text;
                File.AppendAllText(path, record, Encoding.UTF8);
                File.AppendAllText(path, "\r\n", Encoding.UTF8);
            }
        }



        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            d++;
            if (d % 2 == 0)
            {
                line1.Visible = true;
                line3.Visible = true;
                line5.Visible = false;
                line2.Visible = false;
                line4.Visible = false;
                line6.Visible = true;
                line7.Visible = false;
                line8.Visible = true;
            }
            if (d % 2 != 0)
            {
                line1.Visible = false;
                line3.Visible = false;
                line5.Visible = true;
                line2.Visible = true;
                line4.Visible = true;
                line6.Visible = false;
                line7.Visible = true;
                line8.Visible = false;
            }

        }

        private void timer5_Tick(object sender, EventArgs e)
        {
            progressBar1.Value = progressBar1.Value - 1;
            if (progressBar1.Value <= 0)
            {
                timer1.Enabled = false;
                timer2.Enabled = false;
                timer3.Enabled = false;
                //timer4.Enabled = false;
                timer5.Enabled = false;
                pictureBox3.Location = new Point(120, 440);
                car1.Location = new Point(12, 27);
                car2.Location = new Point(102, 27);
                car1.Visible = false;
                car2.Visible = false;
                pictureBox3.Visible = false;
                label1.Visible = false;
                line1.Visible = true;
                line2.Visible = true;
                line3.Visible = true;
                line4.Visible = true;
                line5.Visible = true;
                line6.Visible = true;
                line7.Visible = true;
                line8.Visible = true;
                oil1.Visible = false;
                oil2.Visible = false;
                oil3.Visible = false;
                bomba1.Visible = false;
                bomba2.Visible = false;
                bomba3.Visible = false;
                progressBar1.Visible = false;
                star.Visible = false;
                MessageBox.Show("Ваш результат " + score.ToString());
                string record = score + " " + textBox1.Text;
                File.AppendAllText(path, record, Encoding.UTF8);
                File.AppendAllText(path, "\r\n", Encoding.UTF8);
            }
            Random benz = new Random();
            int canistra = benz.Next(1, 70);
            if (canistra == can1)
            {
                oil1.Visible = true;
                oil1.Location = new Point(27, 246);
            }
            if (canistra == can2)
            {
                oil2.Visible = true;
                oil2.Location = new Point(120, 246);
            }
            if (canistra == can3)
            {
                oil3.Visible = true;
                oil3.Location = new Point(231, 246);
            }
            if (canistra == bom1)
            {
                bomba1.Visible = true;
                bomba1.Location = new Point(27, 185);
            }
            if (canistra == bom2)
            {
                bomba2.Visible = true;
                bomba2.Location = new Point(120, 185);
            }
            if (canistra == bom3)
            {
                bomba3.Visible = true;
                bomba3.Location = new Point(231, 185);
            }
            if (canistra == sta)
            {
                star.Visible = true;
                star.Location = new Point(120, 131);
            }
            if (pictureBox3.Bounds.Contains(oil1.Location) || oil1.Bounds.Contains(pictureBox3.Location))
            {
                int diferenta;
                diferenta = 100 - progressBar1.Value;
                if (diferenta <= 50)
                {
                    progressBar1.Value = progressBar1.Value + diferenta;
                }
                if (diferenta > 50)
                {
                    progressBar1.Value = progressBar1.Value + 50;
                }
                oil1.Visible = false;
                oil1.Location = new Point(400, 0);
            }
            if (pictureBox3.Bounds.Contains(oil2.Location) || oil2.Bounds.Contains(pictureBox3.Location))
            {
                int diferenta;
                diferenta = 100 - progressBar1.Value;
                if (diferenta <= 50)
                {
                    progressBar1.Value = progressBar1.Value + diferenta;
                }
                if (diferenta > 50)
                {
                    progressBar1.Value = progressBar1.Value + 50;
                }
                oil2.Visible = false;
                oil2.Location = new Point(400, 0);
            }
            if (pictureBox3.Bounds.Contains(oil3.Location) || oil3.Bounds.Contains(pictureBox3.Location))
            {
                int diferenta;
                diferenta = 100 - progressBar1.Value;
                if (diferenta <= 50)
                {
                    progressBar1.Value = progressBar1.Value + diferenta;
                }
                if (diferenta > 50)
                {
                    progressBar1.Value = progressBar1.Value + 50;
                }
                oil3.Visible = false;
                oil3.Location = new Point(400, 0);
            }
            if (pictureBox3.Bounds.Contains(star.Location) || star.Bounds.Contains(pictureBox3.Location))
            {
                score = score + 1000;
                star.Visible = false;
                star.Location = new Point(400, 0);
            }
            if (pictureBox3.Bounds.Contains(bomba1.Location) || bomba1.Bounds.Contains(pictureBox3.Location) || pictureBox3.Bounds.Contains(bomba2.Location) || bomba2.Bounds.Contains(pictureBox3.Location) || pictureBox3.Bounds.Contains(bomba3.Location) || bomba3.Bounds.Contains(pictureBox3.Location))
            {
                timer1.Enabled = false;
                timer2.Enabled = false;
                timer3.Enabled = false;
                //timer4.Enabled = false;
                timer5.Enabled = false;
                bomba1.Location = new Point(400, 0);
                bomba2.Location = new Point(400, 0);
                bomba3.Location = new Point(400, 0);
                pictureBox3.Location = new Point(120, 440);
                car1.Location = new Point(12, 27);
                car2.Location = new Point(102, 27);
                car1.Visible = false;
                car2.Visible = false;
                pictureBox3.Visible = false;
                label1.Visible = false;
                line1.Visible = true;
                line2.Visible = true;
                line3.Visible = true;
                line4.Visible = true;
                line5.Visible = true;
                line6.Visible = true;
                line7.Visible = true;
                line8.Visible = true;
                oil1.Visible = false;
                oil2.Visible = false;
                oil3.Visible = false;
                bomba1.Visible = false;
                bomba2.Visible = false;
                bomba3.Visible = false;
                progressBar1.Visible = false;
                star.Visible = false;
                MessageBox.Show("Ваш результат " + score.ToString());
                string record = score + " " + textBox1.Text;
                File.AppendAllText(path, record, Encoding.UTF8);
                File.AppendAllText(path, "\r\n", Encoding.UTF8);
            }
            if (bomba1.Visible == true)
            {
                bomba2.Visible = false;
                bomba3.Visible = false;
                bomba2.Location = new Point(400, 0);
                bomba3.Location = new Point(400, 0);
            }
            if (bomba2.Visible == true)
            {
                bomba1.Visible = false;
                bomba3.Visible = false;
                bomba1.Location = new Point(400, 0);
                bomba3.Location = new Point(400, 0);
            }
            if (bomba3.Visible == true)
            {
                bomba1.Visible = false;
                bomba2.Visible = false;
                bomba1.Location = new Point(400, 0);
                bomba2.Location = new Point(400, 0);
            }

        }
    }
}
