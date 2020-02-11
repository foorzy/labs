using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dfaBondarenko
{
    static class Struct
    {
        //DFA
        //
        public static string[] alfavit;
        public static int[,] sostoyaniye;
        public static bool[] finite;

        //Dlya min

        public static int[,] tablica;
        public static List<int> finiteSostoyaniya = new List<int>();
        public static List<int> nefiniteSostoyaniya = new List<int>();
        public static List<DlyaParVTabl> pairs = new List<DlyaParVTabl>();
        public static DlyaParVTabl[,] poiskSostoyaniy;
        public static int[,] tablicaSMinKol;
        public static bool[] finiteForMinOrNot;

    }
}
