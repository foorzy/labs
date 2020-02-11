using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Graficslab2
{
    class Plate 
    {
        public int A { get; set; }
        public int B { get; set; }
        public int C { get; set; }

        public SolidBrush Col { get; set; }
        public double Z { get; set; }

        public Plate(int a, int b, int c, SolidBrush col, double z)
        {
            A = a;
            B = b;
            C = c;
            Col = col;
            Z = z;
        }

        public Plate()
        {
            A = 0;
            B = 0;
            C = 0;
            Col = new SolidBrush(Color.Black);
            Z = 0;
        }
    }
}
