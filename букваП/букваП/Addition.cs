using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Лаба__2
{
    //Структура для точки в трехмерном пространстве
    public struct Point3d
    {
        public float x, y, z;
        public Point3d(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }
    // структура ячейки, из которых буде состоять Z-buffer

    public struct Cell
    {
        public float z;
        public Color C;
    }

    //Класс треугольников
    public class Triangles
    {
        public Color C;
        public Point3d[] p = new Point3d[3];
        public Triangles(Point3d p1, Point3d p2, Point3d p3, Color color)
        {
            p[0] = p1;
            p[1] = p2;
            p[2] = p3;
            C = color;
        }
    }

}

