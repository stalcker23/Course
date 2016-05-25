namespace Race
{
    partial class Form1
    {

        private System.ComponentModel.IContainer components = null;


        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code


        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.car1 = new System.Windows.Forms.PictureBox();
            this.car2 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.line1 = new System.Windows.Forms.PictureBox();
            this.line2 = new System.Windows.Forms.PictureBox();
            this.line3 = new System.Windows.Forms.PictureBox();
            this.line4 = new System.Windows.Forms.PictureBox();
            this.line5 = new System.Windows.Forms.PictureBox();
            this.line6 = new System.Windows.Forms.PictureBox();
            this.timer4 = new System.Windows.Forms.Timer(this.components);
            this.line7 = new System.Windows.Forms.PictureBox();
            this.line8 = new System.Windows.Forms.PictureBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.timer5 = new System.Windows.Forms.Timer(this.components);
            this.oil1 = new System.Windows.Forms.PictureBox();
            this.oil2 = new System.Windows.Forms.PictureBox();
            this.oil3 = new System.Windows.Forms.PictureBox();
            this.bomba1 = new System.Windows.Forms.PictureBox();
            this.bomba2 = new System.Windows.Forms.PictureBox();
            this.bomba3 = new System.Windows.Forms.PictureBox();
            this.star = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.car1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.car2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.line1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.line2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.line3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.line4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.line5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.line6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.line7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.line8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.oil1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.oil2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.oil3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bomba1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bomba2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bomba3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.star)).BeginInit();
            this.SuspendLayout();
            // 
            // car1
            // 
            this.car1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.car1.Image = ((System.Drawing.Image)(resources.GetObject("car1.Image")));
            this.car1.Location = new System.Drawing.Point(16, 27);
            this.car1.Name = "car1";
            this.car1.Size = new System.Drawing.Size(60, 113);
            this.car1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.car1.TabIndex = 0;
            this.car1.TabStop = false;
            // 
            // car2
            // 
            this.car2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.car2.Image = ((System.Drawing.Image)(resources.GetObject("car2.Image")));
            this.car2.Location = new System.Drawing.Point(207, 290);
            this.car2.Name = "car2";
            this.car2.Size = new System.Drawing.Size(59, 113);
            this.car2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.car2.TabIndex = 1;
            this.car2.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 1;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // timer3
            // 
            this.timer3.Interval = 3;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox3.BackgroundImage")));
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(120, 440);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(30, 80);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox3_MouseDown);
            this.pictureBox3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox3_MouseMove);
            this.pictureBox3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox3_MouseUp);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Silver;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem,
            this.exitToolStripMenuItem,
            this.recordToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 667);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(280, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // newGameToolStripMenuItem
            // 
            this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            this.newGameToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.newGameToolStripMenuItem.Text = "Старт";
            this.newGameToolStripMenuItem.Click += new System.EventHandler(this.newGameToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.exitToolStripMenuItem.Text = "Выход";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // recordToolStripMenuItem
            // 
            this.recordToolStripMenuItem.Name = "recordToolStripMenuItem";
            this.recordToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.recordToolStripMenuItem.Text = "Рекорды";
            this.recordToolStripMenuItem.Click += new System.EventHandler(this.recordToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 611);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Результат";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // line1
            // 
            this.line1.BackColor = System.Drawing.Color.White;
            this.line1.Location = new System.Drawing.Point(88, 0);
            this.line1.Name = "line1";
            this.line1.Size = new System.Drawing.Size(10, 571);
            this.line1.TabIndex = 6;
            this.line1.TabStop = false;
            // 
            // line2
            // 
            this.line2.BackColor = System.Drawing.Color.White;
            this.line2.Location = new System.Drawing.Point(88, 160);
            this.line2.Name = "line2";
            this.line2.Size = new System.Drawing.Size(8, 70);
            this.line2.TabIndex = 7;
            this.line2.TabStop = false;
            // 
            // line3
            // 
            this.line3.BackColor = System.Drawing.Color.White;
            this.line3.Location = new System.Drawing.Point(88, 290);
            this.line3.Name = "line3";
            this.line3.Size = new System.Drawing.Size(8, 70);
            this.line3.TabIndex = 8;
            this.line3.TabStop = false;
            // 
            // line4
            // 
            this.line4.BackColor = System.Drawing.Color.White;
            this.line4.Location = new System.Drawing.Point(88, 429);
            this.line4.Name = "line4";
            this.line4.Size = new System.Drawing.Size(8, 70);
            this.line4.TabIndex = 9;
            this.line4.TabStop = false;
            // 
            // line5
            // 
            this.line5.BackColor = System.Drawing.Color.White;
            this.line5.Location = new System.Drawing.Point(185, -2);
            this.line5.Name = "line5";
            this.line5.Size = new System.Drawing.Size(10, 573);
            this.line5.TabIndex = 10;
            this.line5.TabStop = false;
            // 
            // line6
            // 
            this.line6.BackColor = System.Drawing.Color.White;
            this.line6.Location = new System.Drawing.Point(185, 160);
            this.line6.Name = "line6";
            this.line6.Size = new System.Drawing.Size(8, 70);
            this.line6.TabIndex = 11;
            this.line6.TabStop = false;
            // 
            // timer4
            // 
            this.timer4.Interval = 1;
            this.timer4.Tick += new System.EventHandler(this.timer4_Tick);
            // 
            // line7
            // 
            this.line7.BackColor = System.Drawing.Color.White;
            this.line7.Location = new System.Drawing.Point(185, 290);
            this.line7.Name = "line7";
            this.line7.Size = new System.Drawing.Size(8, 70);
            this.line7.TabIndex = 12;
            this.line7.TabStop = false;
            // 
            // line8
            // 
            this.line8.BackColor = System.Drawing.Color.White;
            this.line8.Location = new System.Drawing.Point(185, 429);
            this.line8.Name = "line8";
            this.line8.Size = new System.Drawing.Size(8, 70);
            this.line8.TabIndex = 13;
            this.line8.TabStop = false;
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.Color.White;
            this.progressBar1.Location = new System.Drawing.Point(76, 578);
            this.progressBar1.Maximum = 101;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(190, 19);
            this.progressBar1.TabIndex = 14;
            // 
            // timer5
            // 
            this.timer5.Interval = 200;
            this.timer5.Tick += new System.EventHandler(this.timer5_Tick);
            // 
            // oil1
            // 
            this.oil1.Image = ((System.Drawing.Image)(resources.GetObject("oil1.Image")));
            this.oil1.Location = new System.Drawing.Point(27, 246);
            this.oil1.Name = "oil1";
            this.oil1.Size = new System.Drawing.Size(35, 35);
            this.oil1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.oil1.TabIndex = 15;
            this.oil1.TabStop = false;
            // 
            // oil2
            // 
            this.oil2.Image = ((System.Drawing.Image)(resources.GetObject("oil2.Image")));
            this.oil2.Location = new System.Drawing.Point(120, 246);
            this.oil2.Name = "oil2";
            this.oil2.Size = new System.Drawing.Size(35, 35);
            this.oil2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.oil2.TabIndex = 16;
            this.oil2.TabStop = false;
            // 
            // oil3
            // 
            this.oil3.Image = ((System.Drawing.Image)(resources.GetObject("oil3.Image")));
            this.oil3.Location = new System.Drawing.Point(221, 246);
            this.oil3.Name = "oil3";
            this.oil3.Size = new System.Drawing.Size(35, 35);
            this.oil3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.oil3.TabIndex = 17;
            this.oil3.TabStop = false;
            // 
            // bomba1
            // 
            this.bomba1.Image = ((System.Drawing.Image)(resources.GetObject("bomba1.Image")));
            this.bomba1.Location = new System.Drawing.Point(27, 185);
            this.bomba1.Name = "bomba1";
            this.bomba1.Size = new System.Drawing.Size(35, 35);
            this.bomba1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.bomba1.TabIndex = 18;
            this.bomba1.TabStop = false;
            // 
            // bomba2
            // 
            this.bomba2.Image = ((System.Drawing.Image)(resources.GetObject("bomba2.Image")));
            this.bomba2.Location = new System.Drawing.Point(120, 185);
            this.bomba2.Name = "bomba2";
            this.bomba2.Size = new System.Drawing.Size(35, 35);
            this.bomba2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.bomba2.TabIndex = 19;
            this.bomba2.TabStop = false;
            // 
            // bomba3
            // 
            this.bomba3.Image = ((System.Drawing.Image)(resources.GetObject("bomba3.Image")));
            this.bomba3.Location = new System.Drawing.Point(221, 185);
            this.bomba3.Name = "bomba3";
            this.bomba3.Size = new System.Drawing.Size(35, 35);
            this.bomba3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.bomba3.TabIndex = 20;
            this.bomba3.TabStop = false;
            // 
            // star
            // 
            this.star.Image = ((System.Drawing.Image)(resources.GetObject("star.Image")));
            this.star.Location = new System.Drawing.Point(120, 131);
            this.star.Name = "star";
            this.star.Size = new System.Drawing.Size(35, 35);
            this.star.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.star.TabIndex = 21;
            this.star.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(102, 633);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(131, 20);
            this.textBox1.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(13, 640);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Введите имя";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(13, 584);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Бензин";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Maroon;
            this.panel2.Location = new System.Drawing.Point(0, 571);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(280, 10);
            this.panel2.TabIndex = 26;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(280, 691);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.car2);
            this.Controls.Add(this.car1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.line1);
            this.Controls.Add(this.line5);
            this.Controls.Add(this.line6);
            this.Controls.Add(this.line2);
            this.Controls.Add(this.line3);
            this.Controls.Add(this.line7);
            this.Controls.Add(this.line4);
            this.Controls.Add(this.line8);
            this.Controls.Add(this.oil3);
            this.Controls.Add(this.oil2);
            this.Controls.Add(this.oil1);
            this.Controls.Add(this.bomba1);
            this.Controls.Add(this.bomba2);
            this.Controls.Add(this.bomba3);
            this.Controls.Add(this.star);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Racing Moto";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.car1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.car2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.line1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.line2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.line3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.line4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.line5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.line6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.line7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.line8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.oil1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.oil2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.oil3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bomba1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bomba2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bomba3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.star)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox car1;
        private System.Windows.Forms.PictureBox car2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox line1;
        private System.Windows.Forms.PictureBox line2;
        private System.Windows.Forms.PictureBox line3;
        private System.Windows.Forms.PictureBox line4;
        private System.Windows.Forms.PictureBox line5;
        private System.Windows.Forms.PictureBox line6;
        private System.Windows.Forms.Timer timer4;
        private System.Windows.Forms.PictureBox line7;
        private System.Windows.Forms.PictureBox line8;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Timer timer5;
        private System.Windows.Forms.PictureBox oil1;
        private System.Windows.Forms.PictureBox oil2;
        private System.Windows.Forms.PictureBox oil3;
        private System.Windows.Forms.PictureBox bomba1;
        private System.Windows.Forms.PictureBox bomba2;
        private System.Windows.Forms.PictureBox bomba3;
        private System.Windows.Forms.PictureBox star;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recordToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
    }
}

