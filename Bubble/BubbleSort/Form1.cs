using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BubbleSort
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            FomrParametrs fp = new FomrParametrs();
            List<double> l = TimeForArrays();

            int j = 0;
            for (int i = Parametrs.Ot; i < Parametrs.Do; i = i + Parametrs.Shag)
            {
                chart1.Series[0].Points.AddXY(i, l[j]);
                j++;
            }
            j = 0;
            KramerShcet();
            double y = 0;
            for (int i = 0; i < Parametrs.Do + 1; i = i + Parametrs.Shag)
            {
                y = A * Math.Pow(i, 2) + B * i + C;
                chart1.Series[1].Points.AddXY(i, y);
                chart1.Series[1].BorderWidth = 2;
            }
        }
        double A = 0;
        double B = 0;
        double C = 0;

        List<double> allResults = new List<double>();

        void KramerShcet()
        {
            int N = 0;
            for(int i = Parametrs.Ot; i < Parametrs.Do; i = i + Parametrs.Shag)
            {
                N++;
            }
            double f11 = 0, f12 = 0, f13 = 0,
                   f21 = 0, f22 = 0, f23 = 0, 
                   f31 = 0, f32 = 0, f33 = 0, 
                   f1 = 0, f2 = 0, f3 = 0;
            int counter = 0;
            for (int i = Parametrs.Ot; i < Parametrs.Do; i = i + Parametrs.Shag)
            {
                f11 += Math.Pow(i, 4);
                f12 += Math.Pow(i, 3);
                f13 += Math.Pow(i, 2);

                f21 += Math.Pow(i, 3);
                f22 += Math.Pow(i, 2);
                f23 += Math.Pow(i, 1);

                f31 += Math.Pow(i, 2);
                f32 += Math.Pow(i, 1);

                f1 += Math.Pow(i, 2) * allResults[counter];
                f2 += Math.Pow(i, 1) * allResults[counter];
                f3 += allResults[counter];

                counter++;
            }
            f33 = N;
            double delta = 0, deltaA = 0, deltaB = 0, deltaC = 0;
            delta = f11 * f22 * f33 + f12 * f23 * f31 + f13 * f21 * f32
               - f13 * f22 * f31 - f11 * f23 * f32 - f12 * f21 * f33;
            deltaA = f1 * f22 * f33 + f12 * f23 * f3 + f13 * f2 * f32
                - f13 * f22 * f3 - f1 * f23 * f32 - f12 * f2 * f33;
            deltaB = f11 * f2 * f33 + f1 * f23 * f31 + f13 * f21 * f3
                - f13 * f2 * f31 - f11 * f23 * f3 - f1 * f21 * f33;
            deltaC = f11 * f22 * f3 + f12 * f2 * f31 + f1 * f21 * f32
                - f1 * f22 * f31 - f11 * f2 * f32 - f12 * f21 * f3;
            A = deltaA / delta;
            B = deltaB / delta;
            C = deltaC / delta;
        }
        static int[] BubbleSort(int[] mas)
        {
            int temp;
            for (int i = 0; i < mas.Length; i++)
            {
                for (int j = i + 1; j < mas.Length; j++)
                {
                    if (mas[i] > mas[j])
                    {
                        temp = mas[i];
                        mas[i] = mas[j];
                        mas[j] = temp;
                    }
                }
            }
            return mas;
        }
        public List<double> TimeForArrays()
        {
            double Vremya = 0;

            for (int i = Parametrs.Ot; i < Parametrs.Do; i = i + Parametrs.Shag)
            {
                for (int k = 0; k < Parametrs.Progonok; k++)
                {
                    int[] array = new int[i];
                    Random rand = new Random();
                    for (int j = 0; j < array.Length; j++)
                    {
                        array[j] = rand.Next(0, 99);
                    }
                    System.Diagnostics.Stopwatch StartStopTimer = new System.Diagnostics.Stopwatch();
                    StartStopTimer.Start();
                    BubbleSort(array);
                    StartStopTimer.Stop();
                    Vremya+= Convert.ToDouble(StartStopTimer.ElapsedMilliseconds);
                }
                Vremya = Vremya / Parametrs.Progonok;
                allResults.Add(Vremya);
                Vremya = 0;
            }
            return allResults;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<double> l = TimeForArrays();
            int j = 0;
            for(int i = Parametrs.Ot; i < Parametrs.Do; i = i + Parametrs.Shag)
            {
                chart1.Series[0].Points.AddXY(i, l[j]);
                j++;
            }
            j = 0;
        }
        private void button6_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();

            allResults.Clear();

            this.Hide();

            FomrParametrs f = new FomrParametrs();
            f.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int size = Convert.ToInt32(textBox4.Text);
            double Vremya = 0;
                for (int k = 0; k < Parametrs.Progonok; k++)
                {
                    int[] array = new int[size]; //генерим массив с размером n.i
                    Random rand = new Random();
                    for (int j = 0; j < array.Length; j++)
                    {
                        array[j] = rand.Next(0, 99);
                    }
                    System.Diagnostics.Stopwatch StartStopTimer = new System.Diagnostics.Stopwatch();

                    StartStopTimer.Start(); 
                    BubbleSort(array);
                    StartStopTimer.Stop();

                Vremya += Convert.ToDouble(StartStopTimer.ElapsedMilliseconds);
                }
                Vremya = Vremya / Parametrs.Progonok;
            chart1.Series[0].Points.AddXY(size, Vremya); // рандом
            double y = A * Math.Pow(size, 2) + B * size + C;
            chart1.Series[1].Points.AddXY(size, y);
        }
    }
}
