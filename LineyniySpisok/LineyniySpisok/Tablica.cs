using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineyniySpisok
{
    class Tablica
    {
        public int Key { get; set; }
        public string Value { get; set; }

        public Tablica(int k, string v)
        {
            Key = k;
            Value = v;
        }
    }
}
