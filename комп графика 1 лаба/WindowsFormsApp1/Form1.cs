using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        int X=100, Y=100;
        float t = 0f;
        int m1 = 0, m2 = 50;
        bool direct = true;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Drawbody();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Drawbody();
        }

        void Drawbody()
        {
            Graphics obj = pictureBox1.CreateGraphics();
            Pen mypen = new Pen(Color.Black,5);
            Bitmap staticpic = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics staticbody = Graphics.FromImage(staticpic);
            SolidBrush mybrush = new SolidBrush(Color.Brown);
            SolidBrush mybrush2 = new SolidBrush(Color.Red);
            SolidBrush mybrush3 = new SolidBrush(Color.Lime);
            SolidBrush mybrush4 = new SolidBrush(Color.Blue);
            SolidBrush mybrush5 = new SolidBrush(Color.Yellow);
            SolidBrush mybrush6 = new SolidBrush(Color.White);
            staticbody.FillRectangle(mybrush3, new Rectangle(0, 100, pictureBox1.Width, 390));
            staticbody.FillRectangle(mybrush4, new Rectangle(0, 0, pictureBox1.Width, 180));
            staticbody.FillEllipse(mybrush5, 400, 30, 30, 30);
            staticbody.FillEllipse(mybrush6, 250, 50, 80, 30);
            staticbody.FillEllipse(mybrush6, 265, 30, 50, 30);

            //staticbody.FillEllipse(mybrush6, 250, 50, 70, 30);
            //staticbody.FillEllipse(mybrush6, 270, 30, 70, 30);

            staticbody.DrawRectangle(mypen, 100, 100, 80, 80);
            staticbody.DrawLine(mypen,100,100,140,60);
            staticbody.DrawLine(mypen, 180, 100, 140, 60);
            staticbody.FillRectangle(mybrush, new Rectangle(100, 100, 80, 80));
            Point p1 = new Point(100, 100);
            Point p2 = new Point(140, 60);
            Point p3 = new Point(180, 100);
            Point[] triangle = { p1, p2, p3 };
            staticbody.FillPolygon(mybrush2, triangle);
            
          
            
            Pen mypen2 = new Pen(Color.White, 5);
            //Bitmap staticpic = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            //Graphics staticbody = Graphics.FromImage(staticpic);

            //obj.Clear(Color.White);
            float x, y;
            x = (float)(40 * Math.Cos(t)) + 140;
            y = (float)(40 * Math.Sin(t)) + 60;
            t += (float)0.02;
            staticbody.DrawLine(mypen, 140, 60, x, y);
            x = (float)(40 * Math.Cos(t+1.57)) + 140;
            y = (float)(40 * Math.Sin(t+1.57)) + 60;
            staticbody.DrawLine(mypen, 140, 60,x,y);
            x = (float)(40 * Math.Cos(t + 3.14)) + 140;
            y = (float)(40 * Math.Sin(t + 3.14)) + 60;
            staticbody.DrawLine(mypen, 140, 60, x, y);
            x = (float)(40 * Math.Cos(t - 1.57)) + 140;
            y = (float)(40 * Math.Sin(t - 1.57)) + 60;
            staticbody.DrawLine(mypen, 140, 60, x, y);
            if (t >= 6.28)
                t = 0;
            if(direct)
            {
                staticbody.DrawLine(mypen, m1, 20, m2, 20);
                m1 += 2;m2 += 2;
                if (m2 >= pictureBox1.Width)
                    direct = false;
            }
            else
            {
                staticbody.DrawLine(mypen, m1, 20, m2, 20);
                m1 -= 2;
                m2 -= 2;
                if (m1 <= 0)
                    direct = true;
            }
            //Point p4 = new Point(0, 500);
            //Point p5 = new Point(0, 540);
            //Point p6 = new Point(40, 500);
            //Point[] vedmed = { p4, p5, p6 };
            //staticbody.FillPolygon(mybrush2, vedmed);
            pictureBox1.Image = staticpic;
            
            //Point p1 = new Point(X, Y);
            //Point p2 = new Point(X+100, Y);
            //Point p3 = new Point(X, Y+100);
            //Point p4 = new Point(X+100, Y+100);
            //Point[] square = { p1, p2, p4, p3 };
            //obj.DrawLine(mypen, p1, p2);
            //obj.DrawLine(mypen, p1, p3);
            //obj.DrawLine(mypen, p3, p4);
            //obj.DrawLine(mypen, p4, p2);
            //obj.FillPolygon(Brushes.Aqua, square);
        }
        
        //void MakeMoves()
        //{
        //    Graphics obj = pictureBox1.CreateGraphics();
        //    Pen mypen = new Pen(Color.Black, 5);
        //    Bitmap staticpic = new Bitmap(pictureBox1.Width, pictureBox1.Height);
        //    Graphics staticbody = Graphics.FromImage(staticpic);
        //    for (double t = 0;t<2*3.14; t+=0.2)
        //    {
        //        float x, y;
        //        x = (float)(20 * Math.Cos(t));
        //        y = (float)(20 * Math.Sin(t));
        //        staticbody.DrawLine(mypen, 140, 60,x,y );
        //    }
        //}
    }
}
