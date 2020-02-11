using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NfaDfaBondarenko
{
    class DlyaParVTabl
    {
        public int FirstIndex { get; set; }
        public int SecondIndex { get; set; }

        public DlyaParVTabl(int f, int s)
        {
            FirstIndex = f;
            SecondIndex = s;
        }
    }
}
