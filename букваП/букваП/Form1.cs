using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace букваП
{
    public partial class Form1 : Form
    {
        List<MyPoints> points = new List<MyPoints>();
        List<MyPoints> arr = new List<MyPoints>();

        int[,] matr= new int[8, 8];
        Graphics f;
        Graphics g;
        Bitmap b;
        char ch ;
        double an = 1.0472;

        //проверка границ
        bool Gradica()
        {
            foreach (MyPoints p in points)
            {
                if (p.X2d >= pictureBox.Width/2  || p.X2d <= (pictureBox.Width / 2)*-1)
                {
                    return false;
                }
                if (p.Y2d >= pictureBox.Height / 2 || p.Y2d <= (pictureBox.Height / 2) * -1)
                {
                    return false;
                }
            }
            return true;
        }

        //преобразование в экранные коордитнаты
        private void To2d()
        {
            foreach (MyPoints i in points)
            {
                i.X2d = i.X / (1 - i.Z / 250);
                i.Y2d = i.Y / (1 - i.Z / 250);
            }
        }

        public Form1()
        {
            InitializeComponent();           
        }
     
        //кнопка открытия файла
        private void btnOpen_Click(object sender, EventArgs e)
        {
            string fileNum = null;

            using (OpenFileDialog file = new OpenFileDialog())
            {
                file.InitialDirectory = "WindowsFormsApp12/bin/Debug";
                file.Filter = "txt files (*.txt)|*.txt";
                file.FilterIndex = 2;
                file.RestoreDirectory = true;

                if (file.ShowDialog() == DialogResult.OK)
                {
                    fileNum = file.FileName;
                }
            }

            fileNum = "test.txt";
            if (fileNum != null)
            {
                StreamReader file1 = new StreamReader(fileNum);
                try
                {
                    string ln;
                    string text = File.ReadAllText(fileNum);
                    string[] buf;
                    char[] sep = { ',', ' ' };
                    while ((ln = file1.ReadLine()) != null)
                    {
                        buf = ln.Split(sep, StringSplitOptions.RemoveEmptyEntries);
                        points.Add(new MyPoints(Convert.ToInt32(buf[0]),
                              Convert.ToInt32(buf[1]),
                             Convert.ToInt32(buf[2])));
                        arr.Add(new MyPoints(Convert.ToInt32(buf[0]),
                                                 Convert.ToInt32(buf[1]),
                                                 Convert.ToInt32(buf[2])));
                    }
                    file1.Close();
                    
                    StreamReader Mfile = new StreamReader("matr.txt");
                    string line;
                    string[] buff;
                    int i = 0;
                    while ((line = Mfile.ReadLine()) != null)
                    {
                        buff = line.Split(sep, StringSplitOptions.RemoveEmptyEntries);
                        for (int j = 0; j < buff.Length; j++)
                        {
                             matr[i, j] = Convert.ToInt32(buff[j]);
                        }
                        i++;
                    }


                     Draw();
                }
                catch (System.FormatException)
                {
                    MessageBox.Show("Неверный формат записей в файле.", "Ошибка!");
                }
                buttonAgain.Visible = true;

            }

        }

        //отрисовка буквы П
        public bool Draw()
        {
            if (!Gradica())
            {
                timerRotx.Stop();
                MessageBox.Show(" Soory :( ");

                return false;
            }
            else
            {
                int W = pictureBox.Width, H = pictureBox.Height;
                b = new Bitmap(W, H);
                g = f = Graphics.FromImage(b);
                Pen gr = new Pen(Color.RosyBrown);
                Pen pen = new Pen(Color.DarkRed);
                g.DrawLine(gr, W / 2, 11, W / 2, H - 11);
                g.DrawLine(gr, 11, H / 2, W - 11, H / 2);
                f.TranslateTransform(W / 2, H / 2);
               
                for (int i = 0; i < matr.GetLength(0); i++)
                {
                    for (int j = i; j < matr.GetLength(1); j++)
                    {
                        if (matr[i, j] == 1)
                        {
                            f.DrawLine(pen, points[i].X2d, points[i].Y2d, points[j].X2d, points[j].Y2d);
                        }
                    }
                }

                for (int i = 0, k = matr.GetLength(0); i < matr.GetLength(0); i++, k++)
                {
                    for (int j = 0, n = matr.GetLength(1); j < matr.GetLength(1); j++, n++)
                    {
                        if (matr[i, j] == 1)
                        {
                            f.DrawLine(pen, points[k].X2d, points[k].Y2d, points[n].X2d, points[n].Y2d);
                        }
                    }
                }

                for (int i = 0, j = points.Count / 2; j < points.Count; i++, j++)
                {
                    f.DrawLine(pen, points[i].X2d, points[i].Y2d, points[j].X2d, points[j].Y2d);
                }
               pictureBox.Image = b;
                return true;
            }
        }

        //матрица поворота
        private void RotationX(int an)
        {
            float angle = an * 0.0174533f;
            for (int i = 0; i < points.Count; i++)
            {
                float[] a = new float[] { points[i].X, points[i].Y, points[i].Z, 1 };
                float[,] b = new float[,] { { 1, 0, 0, 0 },
                                            { 0, (float)Math.Cos(angle), (float)Math.Sin(angle), 0 },
                                            { 0, -(float)Math.Sin(angle), (float)Math.Cos(angle), 0 },
                                            { 0, 0, 0, 1 } };
                float[] r = new float[b.GetLength(1)];
                for (int j = 0; j < b.GetLength(1); j++)
                {
                    for (int k = 0; k < b.GetLength(0); k++)
                    {
                        r[j] += a[k] * b[k, j];
                    }
                }
                points[i].X = r[0];
                points[i].Y = r[1];
                points[i].Z = r[2];
            }
            To2d();
            Draw();
        }
        private void RotationY(int an)
        {
            float angle = an * 0.0174533f;
            for (int i = 0; i < points.Count; i++)
            {
                float[] a = new float[] { points[i].X, points[i].Y, points[i].Z, 1 };
                float[,] b = new float[,] { { (float)Math.Cos(angle), 0,  -(float)Math.Sin(angle), 0 },
                                            { 0, 1, 0, 0 },
                                            { (float)Math.Sin(angle), 0, (float)Math.Cos(angle), 0 },
                                            { 0, 0, 0, 1 } };
                float[] r = new float[b.GetLength(1)];
                for (int j = 0; j < b.GetLength(1); j++)
                {
                    for (int k = 0; k < b.GetLength(0); k++)
                    {
                        r[j] += a[k] * b[k, j];
                    }
                }
                points[i].X = r[0];
                points[i].Y = r[1];
                points[i].Z = r[2];
            }
            To2d();
            Draw();
        }
        private void RotationZ(int an)
        {
            float angle = an * 0.0174533f;
            for (int i = 0; i < points.Count; i++)
            {
                float[] a = new float[] { points[i].X, points[i].Y, points[i].Z, 1 };
                float[,] b = new float[,] { { (float)Math.Cos(angle), (float)Math.Sin(angle), 0, 0 },
                                            { -(float)Math.Sin(angle), (float)Math.Cos(angle), 0, 0 },
                                            { 0, 0, 1, 0 },
                                            { 0, 0, 0, 1 } };
                float[] r = new float[b.GetLength(1)];
                for (int j = 0; j < b.GetLength(1); j++)
                {
                    for (int k = 0; k < b.GetLength(0); k++)
                    {
                        r[j] += a[k] * b[k, j];
                    }
                }
                points[i].X = r[0];
                points[i].Y = r[1];
                points[i].Z = r[2];
            }
            To2d();
            Draw();
        }

        //матрица масштабирования
        private void Scaling(double x, double y, double z)
        {
            if (z > 2)
            {
                MessageBox.Show("Слишком много!");
                return;
            }
            for (int i = 0; i < points.Count; i++)
            {
                double[] a = new double[] { points[i].X, points[i].Y, points[i].Z, 1 };
                double[,] b = new double[,] { { x, 0, 0, 0 },
                                            { 0, y, 0, 0 },
                                            { 0, 0, z, 0 },
                                            { 0, 0, 0, 1 } };
                double[] r = new double[b.GetLength(1)];

                //перемножаем две матрицы
                for (int j = 0; j < b.GetLength(1); j++)
                {
                    for (int k = 0; k < b.GetLength(0); k++)
                    {
                        r[j] += a[k] * b[k, j];
                    }
                }
              
                if (r[0] < pictureBox.Width / 2 && r[0] > (pictureBox.Width / 2) * -1)  points[i].X = (float)r[0]; 
                if (r[1] < pictureBox.Height / 2 && r[1] > (pictureBox.Height / 2) * -1) points[i].Y = (float)r[1];
                double zyd = (r[1] / (1 - r[2] / 250));
                double zxd = (r[0] / (1 - r[2] / 250));
                // эта штука должна проверять масштаб по зету 
                //if ((zyd < pictureBox.Height / 2 && zyd > (pictureBox.Height / 2) * -1 )
                //    ||
                //     (zxd< pictureBox.Width / 2 && zxd > (pictureBox.Width / 2) * -1))
                //{
                //}
                points[i].Z = (float)r[2];

                
            }
            To2d();
            Draw();

        }
            
        //матрица отражения
        private void Otrazenie(double x, double y, double z)
        {
            for (int i = 0; i < points.Count; i++)
            {
                
                double[] a = new double[] { points[i].X, points[i].Y, points[i].Z, 1 };
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
                if (r[0] < pictureBox.Width / 2 || r[0] > (pictureBox.Width / 2) * -1) points[i].X = (float)r[0];
                if (r[1] < pictureBox.Height / 2 || r[1] > (pictureBox.Height / 2) * -1) points[i].Y = (float)r[1];
                if ((r[1] / (1 - r[2] / 250) < pictureBox.Height / 2 || (r[1] / (1 - r[2] / 250) > (pictureBox.Height / 2) * -1 ||
                    (r[0] / (1 - r[2] / 250) < pictureBox.Width / 2 || (r[0] / (1 - r[2] / 250) > (pictureBox.Width / 2) * -1)))))
                {
                    points[i].Z = (float)r[2];
                }
            }
            To2d();
            Draw();
        }


        //матрица переноса 
        private void Perenos(double x, double y, double z)
        {

            double dx = x - points[0].X;
            double dy = y - points[0].Y;
            double dz = z - points[0].Z;
            for (int i = 0; i < points.Count; i++)
            {

                double[] a = new double[] { points[i].X, points[i].Y, points[i].Z, 1 };
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
                //if (r[0] < pictureBox.Width / 2 || r[0] > (pictureBox.Width / 2) * -1)
                    points[i].X = (float)r[0];
               // if (r[1] < pictureBox.Height / 2 || r[1] > (pictureBox.Height / 2) * -1)
                    points[i].Y = (float)r[1];
                //if ((r[1] / (1 - r[2] / 250) < pictureBox.Height / 2 || (r[1] / (1 - r[2] / 250) > (pictureBox.Height / 2) * -1 ||
                  //  (r[0] / (1 - r[2] / 250) < pictureBox.Width / 2 || (r[0] / (1 - r[2] / 250) > (pictureBox.Width / 2) * -1)))))
                
                    points[i].Z = (float)r[2];
                
            }
            To2d();
            Draw();
        }

        //движение по кривой
        private void Curve()
        {          
            an += 0.2;
            if (ch == 'c')
            {
                foreach (MyPoints p in points)
                {
                    p.X++;
                    p.Y = p.Y + (float)(Math.Sin(an));
                }
            }
            if (ch == 's')
            {
                foreach (MyPoints p in points)
                {
                    p.X--;
                    p.Y = p.Y - (float)(Math.Sin(an));
                }
            }
            To2d();
            Draw();            
        }

        //кнопки автоматического вращения
        private void buttonOKX_Click(object sender, EventArgs e)
        {
            ch = 'x';
            timerRotx.Start();
            if (buttonOKX.Text != "Стоп") buttonOKX.Text = "Стоп";
            else
            {
                timerRotx.Stop();
                if (buttonOKX.Text != "Автоматически") buttonOKX.Text = "Автоматически";
                else
                {
                    timerRotx.Start();
                }
            }

        }
        private void buttonOKY_Click(object sender, EventArgs e)
        {
            ch = 'y';
            timerRotx.Start();
            if (buttonOKY.Text != "Стоп") buttonOKY.Text = "Стоп";
            else
            {
                timerRotx.Stop();
                if (buttonOKY.Text != "Автоматически") buttonOKY.Text = "Автоматически";
                else
                {
                    timerRotx.Start();
                }
            }


        }
        private void buttonOKZ_Click(object sender, EventArgs e)
        {
            ch = 'z';
            timerRotx.Start();
            if (buttonOKZ.Text != "Стоп") buttonOKZ.Text = "Стоп";
            else
            {
                timerRotx.Stop();
                if (buttonOKZ.Text != "Автоматически") buttonOKZ.Text = "Автоматически";
                else
                {
                    timerRotx.Start();
                }
            }


        }

        //таймер вращения
        private void timerRotx_Tick(object sender, EventArgs e)
        {          
                Draw();
                if(ch=='x')RotationX(1);
                if (ch == 'y') RotationY(1);
                if (ch == 'z') RotationZ(1);
                if (ch == 'c') Curve();
                if (ch == 's') Curve();
        }

        //кнопки поворота на указанный угол
        private void buttonXRot_Click(object sender, EventArgs e)
        {
            try { 
            RotationX((int)(Convert.ToInt32(RotX.Text)));
            Draw();
            }
            catch (System.FormatException)
            {
                MessageBox.Show("Неверный формат !");
            }
        }
        private void buttonYRot_Click(object sender, EventArgs e)
        {
            try { 
            RotationY((int)(Convert.ToInt32(textBoxRotY.Text)));
            Draw();
            }
            catch (System.FormatException)
            {
                MessageBox.Show("Неверный формат !");
            }
        }
        private void buttonZRot_Click(object sender, EventArgs e)
        {
            try { 
            RotationZ((int)(Convert.ToInt32(textBoxRotZ.Text)));
            Draw();
            }
            catch (System.FormatException)
            {
                MessageBox.Show("Неверный формат !");
            }
        }

        //проверки текст боксов поворота
        private void RotX_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void textBoxRotY_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void textBoxRotZ_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }


        //кнопки для масштабирования 
        private void buttonIncrOk_Click(object sender, EventArgs e)
        {
            Scaling(1.1, 1.1, 1.1);
        }
        private void buttoDecrOK_Click(object sender, EventArgs e)
        {
            Scaling(0.9, 0.9, 0.9);
        }
        private void buttonScX_Click(object sender, EventArgs e)
        {
            try { 
            Scaling((double)Convert.ToDouble(textBoxScaleX.Text),1,1);
             }
            catch (System.FormatException)
            {
                MessageBox.Show("Неверный формат !");
            }
        }
        private void buttonScY_Click(object sender, EventArgs e)
        {
            try
            {
                Scaling(1, (double)Convert.ToDouble(textBoxScaleY.Text),1);
            }
            catch (System.FormatException)
            {
                MessageBox.Show("Неверный формат !");
            }
        }
        private void buttonScZ_Click(object sender, EventArgs e)
        {
            try
            {
                Scaling(1, 1, (double)Convert.ToDouble(textBoxScaleZ.Text));
            }
            catch (System.FormatException)
            {
                MessageBox.Show("Неверный формат !");
            }
        }

        //проверки текст боксов масштабирование
        private void textBoxScaleX_KeyPress(object sender, KeyPressEventArgs e)
        {         
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
                {
                    e.Handled = true;
                }           
        }
        private void textBoxScaleY_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        }
        private void textBoxScaleZ_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        }


        //кнопка переноса 
        private void buttonPerX_Click(object sender, EventArgs e)
        {
            try
            {               
                    Perenos(Convert.ToDouble(textBoxPerX.Text), Convert.ToDouble(textBoxPerY.Text), Convert.ToDouble(textBoxPerZ.Text));               
            }
            catch (System.FormatException)
            {
                MessageBox.Show("Неверный формат !");
            }
        }
        

        //проверки текст боксов переноса
        private void textBoxPerX_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != '-')
            {
                e.Handled = true;
            }
        }
        private void textBoxPerY_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != '-')
            {
                e.Handled = true;
            }
        }
        private void textBoxPerZ_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != '-')
            {
                e.Handled = true;
            }
        }

        //кнопки отражения
        private void buttonOtrX_Click(object sender, EventArgs e)
        {
            Otrazenie(-1, 1, 1);
        }
        private void buttonOtrY_Click(object sender, EventArgs e)
        {
            Otrazenie(1,-1, 1);
        }
        private void buttonOtrZ_Click(object sender, EventArgs e)
        {
            Otrazenie(1, 1, -1);
        }

        //кнопки движения по кривой
        private void button1_Click(object sender, EventArgs e)
        {
            ch = 'c';
            timerRotx.Start();
            if (buttonRight.Text != "Стоп") buttonRight.Text = "Стоп";
            else
            {
                timerRotx.Stop();
                if (buttonRight.Text != "Автоматически") buttonRight.Text = "Автоматически";
                else
                {
                    timerRotx.Start();
                }
            }
        }
        private void buttonLeft_Click(object sender, EventArgs e)
        {
            ch = 's';
            timerRotx.Start();
            if (buttonLeft.Text != "Стоп") buttonLeft.Text = "Стоп";
            else
            {
                timerRotx.Stop();
                if (buttonLeft.Text != "Автоматически") buttonLeft.Text = "Автоматически";
                else
                {
                    timerRotx.Start();
                }
            }
        }


        //заново
        private void buttonAgain_Click(object sender, EventArgs e)
        {
            points.Clear();

            for (int i = 0; i < arr.Count; i++)
            {
                points.Add(new MyPoints(arr[i].X, arr[i].Y, arr[i].Z));
            }
            Draw();
        }
    }
}
