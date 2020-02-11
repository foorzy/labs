using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Лаба__2
{
    public class Z_Buffer1
    {
        public Cell[,] buffer;
        // размер зет-буфера
        int Cell1;
        int Cell2;
        public Z_Buffer1(int C1, int C2)
        {
            Cell1 = C1;
            Cell2 = C2;
            buffer = new Cell[C1, C2];
        }
        public void Fon()
        {

            for (int i = 0; i < Cell1; i++)
            {
                for (int j = 0; j < Cell2; j++)
                {
                    buffer[i, j].C = Color.LightSkyBlue;
                    buffer[i, j].z = 300f;
                }

            }
        }

        public Bitmap DrawLetter()
        {
            Bitmap bmp = new Bitmap(Cell1, Cell2);
            for (int i = 0; i < Cell1; i++)
            {
                for (int j = 0; j < Cell2; j++)
                {
                    bmp.SetPixel(i, j, buffer[i, j].C); //задает цвет указанного пикселя
                }
            }


            for (int b = Cell1 / 2; b < Cell1; b++)
            {
                int a = (Cell1 / 2 - 100) * 2 - 5 * b / 13 + 80;
                bmp.SetPixel(b, a, Color.Black);

            }

            int a1 = (Cell2 / 2 - 64);
            for (int b1 = 0; b1 < Cell2 / 2 + 40; b1++)
            {
                bmp.SetPixel(a1, b1, Color.Black);
            }

            for (int b2 = 0; b2 < Cell1 / 2; b2++)
            {
                int a2 = (Cell1 / 2 - 100) * 2 + 5 * b2 / 13 - 147;
                bmp.SetPixel(b2, a2, Color.Black);

            }

            return bmp;
        }


        public void DrawTriangles(Triangles triangle)
        {
            int YMax, YMin, e1, e;
            int[] x = new int[3];
            int[] y = new int[3];

            for (int i = 0; i < 3; i++)
            {
                x[i] = Convert.ToInt32(triangle.p[i].x);
                y[i] = Convert.ToInt32(triangle.p[i].y);
            }
            YMin = y[0];
            YMax = y[0];
            if (YMax < y[1])
            {
                YMax = y[1];
            }
            else if (YMin > y[1])
            {
                YMin = y[1];
            }

            if (YMax < y[2])
            {
                YMax = y[2];
            }
            else if (YMin > y[2])
            {
                YMin = y[2];
            }
            YMin = (YMin < 0) ? 0 : YMin;
            YMax = (YMin < Cell2) ? YMax : Cell2;


            int n;
            int x1 = 0, x2 = 0;
            int cx1, cx2;
            float z1 = 0, z2 = 0;
            e1 = 0;

            float partofformule, z;

            for (int cy = YMin; cy < YMax; cy++)
            {
                n = 0;
                for (e = 0; e < 3; e++)
                {
                    e1 = e + 1;
                    if (e1 == 3) e1 = 0;
                    if (y[e] < y[e1])
                    {
                        if (y[e1] <= cy || cy < y[e]) continue;
                    }
                    else if (y[e] > y[e1])
                    {
                        if (y[e1] > cy || cy >= y[e]) continue;
                    }
                    else continue;
                    partofformule = (float)(y[e] - cy) / (y[e] - y[e1]);
                    if (n != 0)
                    {
                        x2 = x[e] + Convert.ToInt32(partofformule * (x[e1] - x[e]));
                        z2 = triangle.p[e].z + partofformule * (triangle.p[e1].z - triangle.p[e].z);
                    }
                    else
                    {
                        x1 = x[e] + Convert.ToInt32(partofformule * (x[e1] - x[e]));
                        z1 = triangle.p[e].z + partofformule * (triangle.p[e1].z - triangle.p[e].z);
                        n = 1;
                    }

                }
                if (x2 < x1)
                {
                    e = x1;
                    x1 = x2;
                    x2 = e;
                    partofformule = z1;
                    z1 = z2;
                    z2 = partofformule;
                }
                cx1 = (x1 < 0) ? 0 : x1;
                cx2 = (x2 < Cell1) ? x2 : Cell1;
                for (int cx = cx1; cx < cx2; cx++)
                {
                    partofformule = (float)(x1 - cx) / (x1 - x2);
                    z = z1 + partofformule * (z2 - z1);
                    //Если полученная глубина пиксела меньше той,
                    //что находится в Z-Буфере - заменяем храняшуюся на новую.
                    if (z < buffer[cx, cy].z)
                    {
                        buffer[cx, cy].C = triangle.C;
                        buffer[cx, cy].z = z;
                    }
                }

            }

        }
    }
}
