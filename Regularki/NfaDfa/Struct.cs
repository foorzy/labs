using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NfaDfaBondarenko
{
    class Struct
    {
        public static string[] alphabet = {"a", "b"};
        public static int[,] states;
        public static bool[] isFinish;

        public static int[,] table;

        public static List<int> finstates = new List<int>();
        public static List<int> unfinstates = new List<int>();


        public static List<DlyaParVTabl> pairs = new List<DlyaParVTabl>();

        public static DlyaParVTabl[,] findStates;

        public static int[,] mintable;
        public static bool[] IsFinForMin;

        public static List<List<int>> nfaStates = new List<List<int>>();
        public static List<int> startList = new List<int>();
        public static List<bool> finish = new List<bool>();

        public static List<List<int>> toDfaTable = new List<List<int>>();

        public static List<int> resultDFA = new List<int>();

        public static List<bool> resultfinishDFA = new List<bool>();

        public static List<List<int>> nfaStatesForFile = new List<List<int>>();
        public static List<int> startListForFile = new List<int>();
        public static List<bool> finishForFile = new List<bool>();
    }
}
