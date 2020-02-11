using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        int x = 100;
        int y = 100;
        Bitmap bmp;
        Graphics graph;
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            x = x + 1;
            y = y + 1;
            DrawCar(x, y);
            graph.Clear(Color.White);
            picture.Image = bmp;
        }
            
        
            void DrawCar(int x, int y)
            {
         

                Pen pen = new Pen(Color.Black);
                SolidBrush myBrush = new SolidBrush(Color.Red);

                graph.FillRectangle(myBrush, x, y, 100, 40);
                SolidBrush myBrush2 = new SolidBrush(Color.Black);
                SolidBrush myBrush3 = new SolidBrush(Color.Blue);
                graph.FillEllipse(myBrush2, x + 10, y + 40, 20, 20);
                graph.FillEllipse(myBrush2, x + 70, y + 40, 20, 20);
                Point point1 = new Point(x + 10, y);
                Point point2 = new Point(x + 30, y - 30);
                Point point3 = new Point(x + 80, y - 30);
                Point point4 = new Point(x + 90, y);
                Point[] curvePoints =
                 {
                 point1,
                 point2,
                 point3,
                 point4

        };
                graph.FillPolygon(myBrush3, curvePoints);
            }

        private void Form1_Load(object sender, EventArgs e)
        {
             bmp = new Bitmap(picture.Width, picture.Height);
            graph = Graphics.FromImage(bmp);

            timer1.Start();
        }
    }
}
