using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graficslab2
{
    class Points2D
    {
        public float X { get; set; }
        public float Y { get; set; }
        

        public Points2D(float x, float y)
        {
            X = x;
            Y = y;
        }

        public Points2D()
        {
            X = 0;
            Y = 0;
        }
    }
}
