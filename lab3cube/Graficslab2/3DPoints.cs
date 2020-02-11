using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graficslab2
{
    class _3DPoints
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public _3DPoints(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public _3DPoints()
        {
            X = 0;
            Y = 0;
            Z = 0;
        }

    }

}
