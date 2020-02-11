using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Xml.Serialization;

namespace copybook
{
    [Serializable]
    public class copybook
    {
        public string firm { get; set; }
        public string factory { get; set; }
        public int price { get; set; }
        public int stran { get; set; }

        public copybook()
        {
            firm = "aa";
            factory = "bb";
            price = 0;
            stran = 0;
        }

        public copybook(string f, string fac, int pric, int str)
        {
            firm = f;
            factory = fac;
            price = pric;
            stran = str;
        }

        public override string ToString()
        {
            string output = "";
            output += firm.ToString() + " ";
            output += factory.ToString() + " ";
            output += price.ToString() + " ";
            output += stran.ToString() + " ";
            return output;
        }
    }
}
