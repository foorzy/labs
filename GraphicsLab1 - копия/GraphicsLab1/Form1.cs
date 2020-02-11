using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicsLab1
{
    public partial class Form1 : Form
    {
        int tx = -400;
        int ty = 300;
        Bitmap myBitmap;
        Graphics gr;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            myBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            gr = Graphics.FromImage(myBitmap);
            gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            //tx = -400;
            timer1.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
      //      timer1.Start();
        }

        private void DrawBattlefeld(Graphics Battlefield)
        {
            // Graphics Battlefield = pictureBox1.CreateGraphics();
            Battlefield.Clear(Color.Goldenrod);
            Battlefield.FillRectangle(Brushes.PaleTurquoise, pictureBox1.DisplayRectangle.X, pictureBox1.DisplayRectangle.Y, pictureBox1.Width, pictureBox1.Height / 2);
            Battlefield.FillPie(Brushes.LightSlateGray, pictureBox1.Width / 2, pictureBox1.Height / 2 - 25, 200, 100, 0, -180);
            Battlefield.FillPie(Brushes.LightSlateGray, pictureBox1.Width / 9, pictureBox1.Height / 2 - 25, 100, 50, 0, -180);
            Battlefield.FillEllipse(Brushes.Yellow, pictureBox1.Width - 110, pictureBox1.DisplayRectangle.Y + 10, 100, 100);
            SolidBrush sb = new SolidBrush(Color.GhostWhite);
            Battlefield.FillEllipse(sb, 20, 110, 132, 82);
            Battlefield.FillEllipse(sb, 100, 130, 132, 82);
            Battlefield.FillEllipse(sb, 120, 90, 120, 90);

            Battlefield.FillEllipse(sb, 420, 100, 132, 72);
            Battlefield.FillEllipse(sb, 500, 120, 132, 72);
            Battlefield.FillEllipse(sb, 520, 80, 120, 80);
        }

        private void DrawTank(Graphics tank)
        {
         //   Graphics tank = pictureBox1.CreateGraphics();
            Pen myPen = new Pen(Color.Black, 2);
            Pen myPen2 = new Pen(Color.Black, 5);
            Point p1 = new Point(tx, ty);
            Point p2 = new Point(tx + 200, ty);
            Point p3 = new Point(tx - 20, ty + 30);
            Point p4 = new Point(tx + 250, ty + 30);
            Point p5 = new Point(tx + 105, ty);
            Point p6 = new Point(tx + 105, ty - 5);
            Point p7 = new Point(tx + 75, ty - 5);
            Point p8 = new Point(tx + 78, ty - 35);
            Point p9 = new Point(tx + 85, ty - 40);
            Point p10 = new Point(tx + 110, ty - 40);
            Point p11 = new Point(tx + 110, ty - 45);
            Point p12 = new Point(tx + 140, ty - 45);
            Point p13 = new Point(tx + 140, ty - 40);
            Point p14 = new Point(tx + 180, ty - 40);
            Point p15 = new Point(tx + 200, ty - 35);
            Point p16 = new Point(tx + 210, ty - 30);
            Point p17 = new Point(tx + 220, ty - 30);
            Point p18 = new Point(tx + 220, ty - 25);
            Point p19 = new Point(tx + 395, ty - 25);
            Point p20 = new Point(tx + 395, ty - 17);
            Point p21 = new Point(tx + 220, ty - 17);
            Point p22 = new Point(tx + 220, ty - 10);
            Point p23 = new Point(tx + 210, ty - 10);
            Point p24 = new Point(tx + 200, ty - 5);
            Point p25 = new Point(tx + 200, ty);
            Point p26 = new Point(tx + 10 , ty + 55);
            Point p27 = new Point(tx + 200, ty + 55);
            Point[] body = { p1, p2, p4, p27, p26, p3 };
            tank.FillPolygon(Brushes.DarkOliveGreen, body);
            tank.DrawLine(myPen, p1, p2);
            tank.DrawLine(myPen, p1, p3);
            tank.DrawLine(myPen, p3, p4);
            tank.DrawLine(myPen, p2, p4);
            Point[] top = { p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16, p17, p18, p19, p20, p21, p22, p23, p24, p25};
            tank.FillPolygon(Brushes.DarkOliveGreen, top);
            tank.DrawLine(myPen, p5, p6);
            tank.DrawLine(myPen, p6, p7);
            tank.DrawLine(myPen, p7, p8);
            tank.DrawLine(myPen, p8, p9);
            tank.DrawLine(myPen, p9, p10);
            tank.DrawLine(myPen, p10, p11);
            tank.DrawLine(myPen, p11, p12);
            tank.DrawLine(myPen, p12, p13);
            tank.DrawLine(myPen, p13, p14);
            tank.DrawLine(myPen, p14, p15);
            tank.DrawLine(myPen, p15, p16);
            tank.DrawLine(myPen, p16, p17);
            tank.DrawLine(myPen, p17, p18);
            tank.DrawLine(myPen, p18, p19);
            tank.DrawLine(myPen, p19, p20);
            tank.DrawLine(myPen, p20, p21);
            tank.DrawLine(myPen, p21, p22);
            tank.DrawLine(myPen, p22, p23);
            tank.DrawLine(myPen, p23, p24);
            tank.DrawLine(myPen, p24, p25);
            tank.DrawLine(myPen, p25, p5);
            tank.DrawLine(myPen, p4, p27);
            tank.DrawLine(myPen, p27, p26);
            tank.DrawLine(myPen, p26, p3);
            tank.FillRectangle(Brushes.DarkOliveGreen, tx-10, ty-7, 65, 22);
            tank.DrawRectangle(myPen, tx - 10, ty - 7, 65, 22);
            tank.DrawLine(myPen, tx + 10, ty -7, tx + 10, ty +15);
            tank.DrawLine(myPen, tx + 35, ty - 7, tx + 35, ty + 15);
            tank.FillEllipse(Brushes.DarkOliveGreen, tx-35, ty+35, 30, 30);
            tank.FillEllipse(Brushes.DarkOliveGreen, tx, ty + 40, 40, 40);
            tank.FillEllipse(Brushes.DarkOliveGreen, tx+45, ty + 40, 40, 40);
            tank.FillEllipse(Brushes.DarkOliveGreen, tx+90, ty + 40, 40, 40);
            tank.FillEllipse(Brushes.DarkOliveGreen, tx + 145, ty + 40, 40, 40);
            tank.FillEllipse(Brushes.DarkOliveGreen, tx + 190, ty + 40, 40, 40);
            tank.FillEllipse(Brushes.DarkOliveGreen, tx + 235, ty + 35, 25, 25);
            tank.DrawEllipse(myPen2, tx - 35, ty + 35, 30, 30);
            tank.DrawEllipse(myPen2, tx, ty + 40, 40, 40);
            tank.DrawEllipse(myPen2, tx + 45, ty + 40, 40, 40);
            tank.DrawEllipse(myPen2, tx + 90, ty + 40, 40, 40);
            tank.DrawEllipse(myPen2, tx + 145, ty + 40, 40, 40);
            tank.DrawEllipse(myPen2, tx + 190, ty + 40, 40, 40);
            tank.DrawEllipse(myPen2, tx + 235, ty + 35, 25, 25);
            tank.DrawLine(myPen2, tx - 35, ty + 33, tx + 260, ty + 33);
            tank.DrawLine(myPen2, tx + 260, ty + 33, tx + 265, ty + 55);
            tank.DrawLine(myPen2, tx + 265, ty + 55, tx + 225, ty + 83);
            tank.DrawLine(myPen2, tx + 225, ty + 83, tx - 5, ty + 83);
            tank.DrawLine(myPen2, tx - 5, ty + 83, tx - 45, ty + 60);
            tank.DrawLine(myPen2, tx - 45, ty + 60, tx - 35, ty + 33);
            tank.DrawLine(myPen, p10, p13);
            tank.DrawLine(myPen, p16, p23);
            tank.DrawLine(myPen, p17, p22);
            string drawString = "НА БЕРЛИН!";
            System.Drawing.Font drawFont = new System.Drawing.Font("Impact", 15);
            System.Drawing.SolidBrush drawBrush = new System.Drawing.SolidBrush(System.Drawing.Color.White);
            float x = tx+90;
            float y = ty-35;
            System.Drawing.StringFormat drawFormat = new System.Drawing.StringFormat();
            tank.DrawString(drawString, drawFont, drawBrush, x, y, drawFormat);


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DrawBattlefeld(gr);
           // Graphics gr = pictureBox1.CreateGraphics();
            DrawTank(gr);
            if (tx-50 <= pictureBox1.Width)
            { tx += 1; }
            else { tx = pictureBox1.DisplayRectangle.Left-400; }
            pictureBox1.Image = myBitmap;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            //gr.Clear(Color.White);
            pictureBox1.Image = myBitmap;
        }
    }
}
