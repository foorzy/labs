using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace букваП
{
    //этот класс нужен для точек
    class MyPoints
    {
        //координата х
        public float X { get; set; }

        //координата y
        public float Y { get; set; }

        //координата z
        public float Z { get; set; }

        //экранная координата х
        public float X2d { get; set; }

        //экранная координата у
        public float Y2d { get; set; }


        //конструкторы
        public MyPoints(float x, float y, float z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
            //преобразование в экранные
            this.X2d = x / (1 - z / 250);
            this.Y2d = y / (1 - z / 250);
        }
        public MyPoints()
        {
            X = 0;
            Y = 0;
            Z = 0;
        }
    }
}
