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
    class Program
    {
        static void Main(string[] args)
        {
            copybook c1 = new copybook("firma", "zavod", 30, 96);

            XmlSerializer formatter = new XmlSerializer(typeof(copybook));

            using (FileStream fs = new FileStream("copybook.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, c1);

                Console.WriteLine("Объект сериализован");
            }

            using (FileStream fs = new FileStream("copybook.xml", FileMode.OpenOrCreate))
            {
                copybook c2 = (copybook)formatter.Deserialize(fs);

                Console.WriteLine("Объект десериализован");
                Console.WriteLine("object");
                Console.WriteLine(c2.ToString());
            }
        }
    }
}
