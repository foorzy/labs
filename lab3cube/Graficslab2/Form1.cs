using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Graficslab2
{
    public partial class Form1 : Form
    {
        const int x0 = 348;
        const int y0 = 228;
        const int z0 = 170;

    
        Graphics gr;
        Bitmap myBitmap;

        _3DPoints[] Points3D = new _3DPoints[8];
        Points2D[] Points2D = new Points2D[8];
        Vspomag[] vsp = new Vspomag[8];
        FirstPoints[] fp = new FirstPoints[8];

        Plate[] plate = new Plate[12];
     

        public Form1()
        {
            InitializeComponent();
            myBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            gr = Graphics.FromImage(myBitmap);
        }

        private void OpenFile(ref string nameread)
        {
            OpenFileDialog opf = new OpenFileDialog();
            if (opf.ShowDialog() == DialogResult.OK)
            {
                nameread = opf.FileName;
            }
        }

        private void ReadPoints(string nameread)
        {
            AddToMass3D(Points3D);

            StreamReader reader = File.OpenText(nameread);
            string xy = "";
            int i = 0;

            try
            {
                while ((xy = reader.ReadLine()) != null && i < 8)
                {
                    string[] split = xy.Split(' ');
                    Points3D[i].X = Convert.ToInt32(split[0]);
                    Points3D[i].Y = Convert.ToInt32(split[1]);
                    Points3D[i].Z = Convert.ToInt32(split[2]);
                    i++;
                }
            }
            catch
            {
                MessageBox.Show("Запись файла не верна!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReadMatrix(string nameread)
        {
            string s = "color";
            AddToPlate(plate);

            StreamReader reader = File.OpenText(nameread);
            string xy = "";
            int i = 0;

            try
            {
                while ((xy = reader.ReadLine()) != null && i < 12)
                {
                    string[] split = xy.Split(' ');
                    plate[i].A = Convert.ToInt32(split[0]);
                    plate[i].B = Convert.ToInt32(split[1]);
                    plate[i].C = Convert.ToInt32(split[2]);
                    s = split[3];
                    switch (s)
                    {
                        case "green":
                            plate[i].Col = new SolidBrush(Color.Green);
                            break;
                        case "red":
                            plate[i].Col = new SolidBrush(Color.Red);
                            break;
                        case "blue":
                            plate[i].Col = new SolidBrush(Color.Blue);
                            break;
                        case "gray":
                            plate[i].Col = new SolidBrush(Color.Gray);
                            break;
                        case "yellow":
                            plate[i].Col = new SolidBrush(Color.Yellow);
                            break;
                        case "orange":
                            plate[i].Col = new SolidBrush(Color.Orange);
                            break;
                        case "brown":
                            plate[i].Col = new SolidBrush(Color.Brown);
                            break;
                        case "black":
                            plate[i].Col = new SolidBrush(Color.Black);
                            break;
                        case "purple":
                            plate[i].Col = new SolidBrush(Color.Purple);
                            break; 
                    }
                    i++;
                }
            }
            catch
            {
                MessageBox.Show("Запись файла не верна!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void Glubina()
        {
            for(int i = 0; i < plate.Length; i ++)
            {
                int a = plate[i].A;
                int b = plate[i].B;
                int c = plate[i].C;
                plate[i].Z = (Points3D[a].Z + Points3D[b].Z + Points3D[c].Z) / 3;
            }
        }

        private void SortByZ()
        {
            for (int j = 0; j < plate.Length; j++)
            {
                for (int i = 0; i < plate.Length - 1; i++)
                {
                    if (plate[i].Z > plate[i + 1].Z)
                    {
                        int tmp1 = plate[i].A;
                        int tmp2 = plate[i].B;
                        int tmp3 = plate[i].C;
                        double tmp4 = plate[i].Z;
                        SolidBrush c1 = plate[i].Col;

                        plate[i].A = plate[i + 1].A;
                        plate[i].B = plate[i + 1].B;
                        plate[i].C = plate[i + 1].C;
                        plate[i].Z = plate[i + 1].Z;
                        plate[i].Col = plate[i + 1].Col;


                        plate[i + 1].A = tmp1;
                        plate[i + 1].B = tmp2;
                        plate[i + 1].C = tmp3;
                        plate[i + 1].Z = tmp4;
                        plate[i + 1].Col = c1;
                    }
                }
            }
        }

        private void DrawPlates()
        {
            if (Granica())
            {
                for (int i = 0; i < plate.Length; i++)
                {
                    int a = plate[i].A;
                    int b = plate[i].B;
                    int c = plate[i].C;

                    Point points1 = new Point(Convert.ToInt32(Points2D[a].X + x0), Convert.ToInt32(Points2D[a].Y + y0));
                    Point points2 = new Point(Convert.ToInt32(Points2D[b].X + x0), Convert.ToInt32(Points2D[b].Y + y0));
                    Point points3 = new Point(Convert.ToInt32(Points2D[c].X + x0), Convert.ToInt32(Points2D[c].Y + y0));
                    Point[] positions = new Point[]  { points1, points2, points3 };
                    gr.FillPolygon(plate[i].Col,positions);
                }
            }
            else
            {
                for (int i = 0; i < 8; i++)
                {
                    Points3D[i].X = vsp[i].X;
                    Points3D[i].Y = vsp[i].Y;
                    Points3D[i].Z = vsp[i].Z;
                }
                From3To2DPoints();

                timer1.Enabled = false;
                timer2.Enabled = false;
                timer3.Enabled = false;
                timer4.Enabled = false;
                timer5.Enabled = false;

                for (int i = 0; i < plate.Length; i++)
                {
                    int a = plate[i].A;
                    int b = plate[i].B;
                    int c = plate[i].C;

                    Point points1 = new Point(Convert.ToInt32(Points2D[a].X + x0), Convert.ToInt32(Points2D[a].Y + y0));
                    Point points2 = new Point(Convert.ToInt32(Points2D[b].X + x0), Convert.ToInt32(Points2D[b].Y + y0));
                    Point points3 = new Point(Convert.ToInt32(Points2D[c].X + x0), Convert.ToInt32(Points2D[c].Y + y0));
                    Point[] positions = { points1, points2, points3 };
                    gr.FillPolygon(plate[i].Col, positions);
                }
                MessageBox.Show("Невозможно произвести преобразование!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddToMass3D(_3DPoints[] Points3D)
        {
            for (int i = 0; i < Points3D.Length;  i++)
            {
                Points3D[i] = new _3DPoints(1212312, 12122,1212121);
            }
        }

        private void AddToPlate(Plate[] plate)
        {
            for (int i = 0; i < plate.Length; i++)
            {
                plate[i] = new Plate();
            }
        }

        private void AddToVspMass3D(Vspomag[] vsp)
        {
            for (int i = 0; i < vsp.Length; i++)
            {
               vsp[i] = new Vspomag(1212312, 12122, 1212121);
            }
        }

        private void AddToFirstPoints(FirstPoints[] fp)
        {
            for (int i = 0; i < fp.Length; i++)
            {
                fp[i] = new FirstPoints(1212312, 12122, 1212121);
            }
        }

        private void AddToMass2D(Points2D[] Points2D)
        {
            for (int i = 0; i < Points2D.Length; i++)
            {
                Points2D[i] = new Points2D(1212312, 12122);
            }
        }

        private void AddToMatrix(int[,] arr)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                    arr[i,j] = 11;
                }
            }
        }

        public void From3To2DPoints()
        {
            AddToMass2D(Points2D);
            for (int i = 0; i < 8; i++)
            {
                Points2D[i].X = (Points3D[i].X) / (1 - (Points3D[i].Z / z0));
                Points2D[i].Y = (Points3D[i].Y) / (1 - (Points3D[i].Z / z0));
            }
        }

        bool Granica()
        {
            for (int i = 0; i < 8; i++)
            {
                if (Points2D[i].X >= (pictureBox1.Width) / 2  || Points2D[i].X <= (pictureBox1.Width) / 2 * -1)
                {
                    return false;
                }
                if (Points2D[i].Y >= ((pictureBox1.Height) / 2)  || Points2D[i].Y <= (pictureBox1.Height) / 2  * -1)
                {
                    return false;
                }
            }
            return true;
        }


        private void Perenos(double x, double y, double z)
        {
            for (int i = 0; i < 8; i++)
            {
                vsp[i].X = Points3D[i].X;
                vsp[i].Y = Points3D[i].Y;
                vsp[i].Z = Points3D[i].Z;
            }

            double dx = x - Points3D[0].X;
            double dy = y - Points3D[0].Y;
            double dz = z - Points3D[0].Z;
            for (int i = 0; i < Points3D.Length; i++)
            {

                double[] a = new double[] { Points3D[i].X, Points3D[i].Y, Points3D[i].Z, 1 };
                double[,] b = new double[,] { { 1, 0, 0, 0 },
                                            { 0, 1, 0, 0 },
                                            { 0, 0, 1, 0 },
                                            { dx, dy, dz, 1 } };
                double[] r = new double[b.GetLength(1)];
                for (int j = 0; j < b.GetLength(1); j++)
                {
                    for (int k = 0; k < b.GetLength(0); k++)
                    {
                        r[j] += a[k] * b[k, j];
                    }
                }
                Points3D[i].X = (float)r[0];
                Points3D[i].Y = (float)r[1];              
                Points3D[i].Z = (float)r[2];

            }
        }

        
        public void KrivayaVLevo(double ugol)
        {
            for (int i = 0; i < 8; i++)
            {
                vsp[i].X = Points3D[i].X;
                vsp[i].Y = Points3D[i].Y;
                vsp[i].Z = Points3D[i].Z;
            }

            float koef = 2;
            for (int i = 0; i < 8; i++)
            {
                float x = Points3D[i].X;
                float y = Points3D[i].Y;
                float z = Points3D[i].Z;

                Points3D[i].X = x - koef;
                Points3D[i].Y = y * (float)Math.Cos(ugol) - z * (float)Math.Sin(ugol);
                Points3D[i].Z = y * (float)Math.Sin(ugol) + z * (float)Math.Cos(ugol);                           
            }
        }

        public void KrivayaVPravo(double ugol)
        {
            for (int i = 0; i < 8; i++)
            {
                vsp[i].X = Points3D[i].X;
                vsp[i].Y = Points3D[i].Y;
                vsp[i].Z = Points3D[i].Z;
            }

            float koef = 2;
            for (int i = 0; i < 8; i++)
            {
              
                float x = Points3D[i].X;
                float y = Points3D[i].Y;
                float z = Points3D[i].Z;

                Points3D[i].X = x + koef;
                Points3D[i].Y = y * (float)Math.Cos(ugol) - z * (float)Math.Sin(ugol);
                Points3D[i].Z = y * (float)Math.Sin(ugol) + z * (float)Math.Cos(ugol);

            }

        }

        public void Povorot(double ugol)
        {
            for (int i = 0; i < 8; i++)
            {
                vsp[i].X = Points3D[i].X;
                vsp[i].Y = Points3D[i].Y;
                vsp[i].Z = Points3D[i].Z;
            }

            for (int i = 0; i < 8; i++)
            {
                float x = Points3D[i].X;
                float y = Points3D[i].Y;
                float z = Points3D[i].Z;

                Points3D[i].X = x;
                Points3D[i].Y = y * (float)Math.Cos(ugol) - z * (float)Math.Sin(ugol);
                Points3D[i].Z = y * (float)Math.Sin(ugol) + z * (float)Math.Cos(ugol);

            }
        }

        public void PovorotOYY(double ugol)
        {
            for (int i = 0; i < 8; i++)
            {
                vsp[i].X = Points3D[i].X;
                vsp[i].Y = Points3D[i].Y;
                vsp[i].Z = Points3D[i].Z;
            }

            for (int i = 0; i < 8; i++)
            {
                float x = Points3D[i].X;
                float y = Points3D[i].Y;
                float z = Points3D[i].Z;

                Points3D[i].X = x * (float)Math.Cos(ugol) - z * (float)Math.Sin(ugol);
                Points3D[i].Y = y;
                Points3D[i].Z = x * (float)Math.Sin(ugol) + z * (float)Math.Cos(ugol);
            }
        }

        public void PovorotOZZ(double ugol)
        {
            for (int i = 0; i < 8; i++)
            {
                vsp[i].X = Points3D[i].X;
                vsp[i].Y = Points3D[i].Y;
                vsp[i].Z = Points3D[i].Z;
            }

            for (int i = 0; i < 8; i++)
            {
                float x = Points3D[i].X;
                float y = Points3D[i].Y;
                float z = Points3D[i].Z;

                Points3D[i].X = x * (float)Math.Cos(ugol) - y * (float)Math.Sin(ugol);
                Points3D[i].Y = x * (float)Math.Sin(ugol) + y * (float)Math.Cos(ugol); 
                Points3D[i].Z = z;
            }
        }

        private void Otrazenie(double x, double y, double z)
        {
            for (int i = 0; i < Points3D.Length; i++)
            {

                double[] a = new double[] { Points3D[i].X, Points3D[i].Y, Points3D[i].Z, 1 };
                double[,] b = new double[,] { { y, 0, 0, 0 },
                                            { 0, x, 0, 0 },
                                            { 0, 0, z, 0 },
                                            { 0, 0, 0, 1 } };
                double[] r = new double[b.GetLength(1)];
                for (int j = 0; j < b.GetLength(1); j++)
                {
                    for (int k = 0; k < b.GetLength(0); k++)
                    {
                        r[j] += a[k] * b[k, j];
                    }
                }
                
                    Points3D[i].X = (float)r[0];           
                    Points3D[i].Y = (float)r[1];           
                    Points3D[i].Z = (float)r[2];
            }
        }

        private void MashtabPow(double x, double y, double z)
        {
            for (int i = 0; i < 8; i++)
            {
                vsp[i].X = Points3D[i].X;
                vsp[i].Y = Points3D[i].Y;
                vsp[i].Z = Points3D[i].Z;
            }

            for (int i = 0; i < Points3D.Length; i++)
            {

                double[] a = new double[] { Points3D[i].X, Points3D[i].Y, Points3D[i].Z, 1 };
                double[,] b = new double[,] { { y, 0, 0, 0 },
                                            { 0, x, 0, 0 },
                                            { 0, 0, z, 0 },
                                            { 0, 0, 0, 1 } };
                double[] r = new double[b.GetLength(1)];
                for (int j = 0; j < b.GetLength(1); j++)
                {
                    for (int k = 0; k < b.GetLength(0); k++)
                    {
                        r[j] += a[k] * b[k, j];
                    }
                }
                Points3D[i].X = (float)r[0];
                Points3D[i].Y = (float)r[1];          
                Points3D[i].Z = (float)r[2];
            }
            
        }

        private void MashtabLow(double x, double y, double z)
        {
            for (int i = 0; i < 8; i++)
            {
                vsp[i].X = Points3D[i].X;
                vsp[i].Y = Points3D[i].Y;
                vsp[i].Z = Points3D[i].Z;
            }

            for (int i = 0; i < Points3D.Length; i++)
            {

                double[] a = new double[] { Points3D[i].X, Points3D[i].Y, Points3D[i].Z, 1 };
                double[,] b = new double[,] { { y, 0, 0, 0 },
                                            { 0, x, 0, 0 },
                                            { 0, 0, z, 0 },
                                            { 0, 0, 0, 1 } };
                double[] r = new double[b.GetLength(1)];
                for (int j = 0; j < b.GetLength(1); j++)
                {
                    for (int k = 0; k < b.GetLength(0); k++)
                    {
                        r[j] += a[k] * b[k, j];
                    }
                }
                Points3D[i].X = (float)r[0];
                Points3D[i].Y = (float)r[1];
                Points3D[i].Z = (float)r[2];
            }
        }

        private void ЗагрузитьТочки_Click(object sender, EventArgs e)
        {
            try
            {
                string nameread = "";
                OpenFile(ref nameread);
                ReadPoints(nameread);
            }
            catch
            {
                MessageBox.Show("Неверная запись файла!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ЗагрузитьМатрицу_Click(object sender, EventArgs e)
        {
            try
            {
                string nameread = "";
                OpenFile(ref nameread);
                ReadMatrix(nameread);              
            }
            catch
            {
                MessageBox.Show("Неверная запись файла !", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Draw_Click(object sender, EventArgs e)
        {
             //try
            //{
                gr.Clear(Color.White);
                gr.DrawLine(new Pen(Color.Black), x0, y0, x0, 0);
                gr.DrawLine(new Pen(Color.Black), x0, y0, 0, 456);
                gr.DrawLine(new Pen(Color.Black), x0, y0, 697, y0);
                AddToVspMass3D(vsp);

                for (int i = 0; i < vsp.Length; i++)
                {
                    vsp[i].X = Points3D[i].X;
                    vsp[i].Y = Points3D[i].Y;
                    vsp[i].Z = Points3D[i].Z;
                }

                AddToFirstPoints(fp);

                for (int i = 0; i < fp.Length; i++)
                {
                    fp[i].X = Points3D[i].X;
                    fp[i].Y = Points3D[i].Y;
                    fp[i].Z = Points3D[i].Z;
                }
                Glubina();
                SortByZ();
                From3To2DPoints();
                DrawPlates();
                pictureBox1.Image = myBitmap;


                button18.Enabled = true;

            //}
            //catch
            //{
            //    MessageBox.Show("Невозможно нарисовать букву !", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //}
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            pictureBox1.Image = myBitmap;
        }

        private void Povor_Click(object sender, EventArgs e)
        {
            timer3.Enabled = true;
        }

        private void Увеличить_Click(object sender, EventArgs e)
        {
            gr.Clear(Color.White);
            gr.DrawLine(new Pen(Color.Black), x0, y0, x0, 0);
            gr.DrawLine(new Pen(Color.Black), x0, y0, 0, 456);
            gr.DrawLine(new Pen(Color.Black), x0, y0, 697, y0);

            MashtabPow(1.02, 1.02, 1.02);
            Glubina();
            SortByZ();
            From3To2DPoints();


            DrawPlates();
            pictureBox1.Image = myBitmap;
        }

        private void Перенести_Click(object sender, EventArgs e)
        {
            try
            {
                float x = Convert.ToInt32(textBox3.Text);
                float y = Convert.ToInt32(textBox4.Text);
                float z = Convert.ToInt32(textBox5.Text);

                gr.Clear(Color.White);
                gr.DrawLine(new Pen(Color.Black), x0, y0, x0, 0);
                gr.DrawLine(new Pen(Color.Black), x0, y0, 0, 456);
                gr.DrawLine(new Pen(Color.Black), x0, y0, 697, y0);

                Perenos(x, y, z);
                Glubina();
                SortByZ();
                From3To2DPoints();

                DrawPlates();

                pictureBox1.Image = myBitmap;
            }
            catch
            {
                MessageBox.Show("Невозможно произвести преобразование !", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void PovorotOZ_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void PovorotOY_Click(object sender, EventArgs e)
        {
            timer2.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                double ugol = 69;

                gr.Clear(Color.White);
                gr.DrawLine(new Pen(Color.Black), x0, y0, x0, 0);
                gr.DrawLine(new Pen(Color.Black), x0, y0, 0, 456);
                gr.DrawLine(new Pen(Color.Black), x0, y0, 697, y0);

                PovorotOZZ(ugol);
                Glubina();
                SortByZ();
                From3To2DPoints();
                DrawPlates();
                pictureBox1.Image = myBitmap;
            }
            catch
            {
                MessageBox.Show("Действие невозможно!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            try
            {
                double ugol = 69;

                gr.Clear(Color.White);
                gr.DrawLine(new Pen(Color.Black), x0, y0, x0, 0);
                gr.DrawLine(new Pen(Color.Black), x0, y0, 0, 456);
                gr.DrawLine(new Pen(Color.Black), x0, y0, 697, y0);

                PovorotOYY(ugol);
                Glubina();
                SortByZ();
                From3To2DPoints();
                DrawPlates();
                pictureBox1.Image = myBitmap;
            }
            catch
            {
                MessageBox.Show("Действие невозможно!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            try
            {
                double ugol = 69;

                gr.Clear(Color.White);
                gr.DrawLine(new Pen(Color.Black), x0, y0, x0, 0);
                gr.DrawLine(new Pen(Color.Black), x0, y0, 0, 456);
                gr.DrawLine(new Pen(Color.Black), x0, y0, 697, y0);

                Povorot(ugol);
                Glubina();
                SortByZ();
                From3To2DPoints();
                DrawPlates();
                pictureBox1.Image = myBitmap;
            }
            catch
            {
                MessageBox.Show("Действие невозможно!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                timer3.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer3.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer2.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }
   
        private void timer4_Tick(object sender, EventArgs e)
        {
            try
            {
                double ugol = 50;

                float angle = 1.0472f;
                float an = angle * 0.174533f;

                gr.Clear(Color.White);
                gr.DrawLine(new Pen(Color.Black), x0, y0, x0, 0);
                gr.DrawLine(new Pen(Color.Black), x0, y0, 0, 456);
                gr.DrawLine(new Pen(Color.Black), x0, y0, 697, y0);

                KrivayaVLevo(ugol);
                Glubina();
                SortByZ();
                From3To2DPoints();
                DrawPlates();
                pictureBox1.Image = myBitmap;

                
            }
            catch
            {
                MessageBox.Show("Действие невозможно!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ПоКривой_Click(object sender, EventArgs e)
        { 
            timer4.Enabled = true;
        }

        private void timer5_Tick(object sender, EventArgs e)
        {           
                double ugol = 50;

                gr.Clear(Color.White);
                gr.DrawLine(new Pen(Color.Black), x0, y0, x0, 0);
                gr.DrawLine(new Pen(Color.Black), x0, y0, 0, 456);
                gr.DrawLine(new Pen(Color.Black), x0, y0, 697, y0);

                KrivayaVPravo(ugol);
                Glubina();
                SortByZ();
                From3To2DPoints();
                DrawPlates();
                pictureBox1.Image = myBitmap;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            timer5.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            double ugol = 69;

            gr.Clear(Color.White);
            gr.DrawLine(new Pen(Color.Black), x0, y0, x0, 0);
            gr.DrawLine(new Pen(Color.Black), x0, y0, 0, 456);
            gr.DrawLine(new Pen(Color.Black), x0, y0, 697, y0);

            Povorot(ugol);
            Glubina();
            SortByZ();
            From3To2DPoints();
            DrawPlates();
            pictureBox1.Image = myBitmap;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            double ugol = 69;

            gr.Clear(Color.White);
            gr.DrawLine(new Pen(Color.Black), x0, y0, x0, 0);
            gr.DrawLine(new Pen(Color.Black), x0, y0, 0, 456);
            gr.DrawLine(new Pen(Color.Black), x0, y0, 697, y0);

            PovorotOYY(ugol);
            Glubina();
            SortByZ();
            From3To2DPoints();
            DrawPlates();
            pictureBox1.Image = myBitmap;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            double ugol = 69;

            gr.Clear(Color.White);
            gr.DrawLine(new Pen(Color.Black), x0, y0, x0, 0);
            gr.DrawLine(new Pen(Color.Black), x0, y0, 0, 456);
            gr.DrawLine(new Pen(Color.Black), x0, y0, 697, y0);

            PovorotOZZ(ugol);
            Glubina();
            SortByZ();
            From3To2DPoints();
            DrawPlates();
            pictureBox1.Image = myBitmap;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            timer4.Enabled = false;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            timer5.Enabled = false;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            gr.Clear(Color.White);
            gr.DrawLine(new Pen(Color.Black), x0, y0, x0, 0);
            gr.DrawLine(new Pen(Color.Black), x0, y0, 0, 456);
            gr.DrawLine(new Pen(Color.Black), x0, y0, 697, y0);
            Otrazenie(1, 1, -1);
            Glubina();
            SortByZ();
            From3To2DPoints();
            DrawPlates();
            pictureBox1.Image = myBitmap;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            gr.Clear(Color.White);
            gr.DrawLine(new Pen(Color.Black), x0, y0, x0, 0);
            gr.DrawLine(new Pen(Color.Black), x0, y0, 0, 456);
            gr.DrawLine(new Pen(Color.Black), x0, y0, 697, y0);
            Otrazenie(-1, -1, 1);
            Glubina();
            SortByZ();
            From3To2DPoints();
            DrawPlates();
            pictureBox1.Image = myBitmap;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            gr.Clear(Color.White);
            gr.DrawLine(new Pen(Color.Black), x0, y0, x0, 0);
            gr.DrawLine(new Pen(Color.Black), x0, y0, 0, 456);
            gr.DrawLine(new Pen(Color.Black), x0, y0, 697, y0);
            Otrazenie(1,-1, 1);
            Glubina();
            SortByZ();
            From3To2DPoints();
            DrawPlates();
            pictureBox1.Image = myBitmap;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 45)
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 45)
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 45)
            {
                e.Handled = true;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 45)
            {
                e.Handled = true;
            }
        }         

        private void button13_Click(object sender, EventArgs e)
        {
            gr.Clear(Color.White);
            gr.DrawLine(new Pen(Color.Black), x0, y0, x0, 0);
            gr.DrawLine(new Pen(Color.Black), x0, y0, 0, 456);
            gr.DrawLine(new Pen(Color.Black), x0, y0, 697, y0);

            MashtabLow(0.98, 0.98, 0.98);
            Glubina();
            SortByZ();
            From3To2DPoints();


            DrawPlates();
            pictureBox1.Image = myBitmap;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            try
            {
                double x = Convert.ToDouble(textBox2.Text);

                double q = 1 + x / 100;

                gr.Clear(Color.White);
                gr.DrawLine(new Pen(Color.Black), x0, y0, x0, 0);
                gr.DrawLine(new Pen(Color.Black), x0, y0, 0, 456);
                gr.DrawLine(new Pen(Color.Black), x0, y0, 697, y0);

                MashtabLow(q, 1, 1);
                Glubina();
                SortByZ();
                From3To2DPoints();

                DrawPlates();
                pictureBox1.Image = myBitmap;
            }
            catch
            {
                MessageBox.Show("Невозможно произвести преобразование !", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            try
            {
                double y = Convert.ToDouble(textBox8.Text);

                double q = 1 + y / 100;

                gr.Clear(Color.White);
                gr.DrawLine(new Pen(Color.Black), x0, y0, x0, 0);
                gr.DrawLine(new Pen(Color.Black), x0, y0, 0, 456);
                gr.DrawLine(new Pen(Color.Black), x0, y0, 697, y0);

                MashtabLow(1, q, 1);
                Glubina();
                SortByZ();
                From3To2DPoints();


                DrawPlates();
                pictureBox1.Image = myBitmap;
            }
            catch
            {
                MessageBox.Show("Невозможно произвести преобразование !", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            try
            {
                double z = Convert.ToDouble(textBox9.Text);

                double q = 1 + z / 100;

                gr.Clear(Color.White);
                gr.DrawLine(new Pen(Color.Black), x0, y0, x0, 0);
                gr.DrawLine(new Pen(Color.Black), x0, y0, 0, 456);
                gr.DrawLine(new Pen(Color.Black), x0, y0, 697, y0);

                MashtabLow(1, 1, q);
                Glubina();
                SortByZ();
                From3To2DPoints();


                DrawPlates();
                pictureBox1.Image = myBitmap;
            }
            catch
            {
                MessageBox.Show("Невозможно произвести преобразование !", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            gr.Clear(Color.White);
            gr.DrawLine(new Pen(Color.Black), x0, y0, x0, 0);
            gr.DrawLine(new Pen(Color.Black), x0, y0, 0, 456);
            gr.DrawLine(new Pen(Color.Black), x0, y0, 697, y0);

            for(int i = 0; i < 8; i ++)
            {
                Points3D[i].X = fp[i].X;
                Points3D[i].Y = fp[i].Y;
                Points3D[i].Z = fp[i].Z;
            }

            Glubina();
            SortByZ();
            From3To2DPoints();
            DrawPlates();
            pictureBox1.Image = myBitmap;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button14.Enabled = true;
            button15.Enabled = true;
            button16.Enabled = true;
            button13.Enabled = true;
            Увеличить.Enabled = true;
            Перенести.Enabled = true;
            PovorotOY.Enabled = true;
            button2.Enabled = true;
            PovorotOZ.Enabled = true;
            button3.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button10.Enabled = true;
            button12.Enabled = true;
            button11.Enabled = true;
            button17.Enabled = true;
            ПоКривой.Enabled = true;
            button8.Enabled = true;
            button4.Enabled = true;
            button9.Enabled = true;
            Povor.Enabled = true;
        }
    }
}
