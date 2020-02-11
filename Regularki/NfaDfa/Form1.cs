using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace NfaDfaBondarenko
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Otkrit(ref string nameread)
        {
            OpenFileDialog opf = new OpenFileDialog();
            if (opf.ShowDialog() == DialogResult.OK)
            {
                nameread = opf.FileName;
            }
        }

        int countLetter = 0;
        int currentState = 0;
        bool isFinish;

        string str;
        private void ChitatDFA(string nameread)
        {

            int n = 0;
            StreamReader reader = File.OpenText(nameread);
            StreamReader reader2 = File.OpenText(nameread);
            string xy = "";

            while ((xy = reader.ReadLine()) != null)
            {
                n++;
            }


            Struct.states = new int[n, Struct.alphabet.Length];
            Struct.isFinish = new bool[n];

            n = 0;

            while ((xy = reader2.ReadLine()) != null)
            {
                string[] split = xy.Split(' ');

                for (int i = 0; i < Struct.alphabet.Length; i++)
                {
                    Struct.states[n, i] = Convert.ToInt32(split[i]);
                }


                if (split[Struct.alphabet.Length].Equals("f"))
                {
                    Struct.isFinish[n] = false;
                }
                else
                {
                    Struct.isFinish[n] = true;
                }
                n++;

            }
        }


        public void ChitatNFA(string nameread)
        {
            StreamReader reader = File.OpenText(nameread);
            string xy = "";
            int count = 0;

            List<int> l = new List<int>();

            while ((xy = reader.ReadLine()) != null)
            {
                if (count == 0)
                {
                    string[] fsplit = xy.Split(',');

                    for (int i = 0; i < fsplit.Length; i++)
                    {
                        Struct.startList.Add(Convert.ToInt32(fsplit[i]));
                    }
                }
                else
                {

                    string[] split = xy.Split(' ');

                    for (int i = 0; i < split.Length - 1; i++)
                    {
                        List<int> list = new List<int>();
                        string[] s = split[i].Split(',');

                        for (int j = 0; j < s.Length; j++)
                        {
                            list.Add(Convert.ToInt32(s[j]));
                        }

                        Struct.nfaStates.Add(list);
                    }


                    if (split[Struct.alphabet.Length].Equals("f"))
                    {
                        Struct.finish.Add(false);
                    }
                    else
                    {
                        Struct.finish.Add(true);
                    }
                }
                count++;
            }

        }

        List<forRE> nfa = new List<forRE>();
        Stack<int> state = new Stack<int>();
        int nfa_size;


        string rebuilt(string re)
        {
            string res = "";
            char symb, symb2;
            for (int i = 0; i < re.Length; i++)
            {
                symb = re[i];
                if (i + 1 < re.Length)
                {
                    symb2 = re[i + 1];
                    res += symb;
                    if (symb != '(' && symb2 != ')' && symb != '+' && symb2 != '+' && symb2 != '*')
                    {
                        res += '.';
                    }
                }
            }

            res += re[re.Length - 1];
            string postfix = "";

            Stack<char> op = new Stack<char>();
            char c;
            for (int i = 0; i < res.Length; i++)
            {
                switch (res[i])
                {
                    case 'a':
                    case 'b':
                        postfix += res[i]; break;
                    case '(':
                        op.Push(res[i]); break;
                    case ')':
                        while (op.Peek() != '(')
                        {
                            postfix += op.Peek();
                            op.Pop();
                        }
                        op.Pop();
                        break;
                    default:
                        while (op.Count != 0)
                        {
                            c = op.Peek();
                            if (priority(c) >= priority(res[i]))
                            {
                                postfix += op.Peek();
                                op.Pop();
                            }
                            else break;
                        }
                        op.Push(res[i]);
                        break;
                }

            }
            while (op.Count != 0)
            {
                postfix += op.Peek();
                op.Pop();
            }
            return postfix;
        }
        int priority(char c)
        {
            switch (c)
            {
                case '*': return 3;
                case '.': return 2;
                case '+': return 1;
                default: return 0;
            }
        }

        void symbol(int i)
        {
            forRE init_nfa_state = new forRE();
            forRE init_nfa_state2 = new forRE();
            nfa.Add(init_nfa_state);
            nfa.Add(init_nfa_state2);
            nfa[nfa_size].vetki[i] = Convert.ToString((nfa_size + 1));
            state.Push(nfa_size);
            nfa_size++;
            state.Push(nfa_size);
            nfa_size++;
        }
        void plus()
        {
            forRE init_nfa_state = new forRE();
            forRE init_nfa_state2 = new forRE();
            nfa.Add(init_nfa_state);
            nfa.Add(init_nfa_state2);
            int d = state.Peek(); state.Pop();
            int c = state.Peek(); state.Pop();
            int b = state.Peek(); state.Pop();
            int a = state.Peek(); state.Pop();

            nfa[nfa_size].e.Add(a);
            nfa[nfa_size].e.Add(c);
            nfa[b].e.Add(nfa_size + 1);
            nfa[d].e.Add(nfa_size + 1);

            state.Push(nfa_size);
            nfa_size++;
            state.Push(nfa_size);
            nfa_size++;
        }
        //если это .
        void tochka()
        {
            int d = state.Peek(); state.Pop();
            int c = state.Peek(); state.Pop();
            int b = state.Peek(); state.Pop();
            int a = state.Peek(); state.Pop();
            nfa[b].e.Add(c);
            state.Push(a);
            state.Push(d);
        }
        void zvezda()
        {
            forRE init_nfa_state = new forRE();
            forRE init_nfa_state2 = new forRE();
            nfa.Add(init_nfa_state);
            nfa.Add(init_nfa_state2);
            int b = state.Peek();
            state.Pop();
            int a = state.Peek();
            state.Pop();
            nfa[nfa_size].e.Add(a);
            nfa[nfa_size].e.Add(nfa_size + 1);
            nfa[b].e.Add(a);
            nfa[b].e.Add(nfa_size + 1);
            state.Push(nfa_size);
            nfa_size++;
            state.Push(nfa_size);
            nfa_size++;
        }

        void postfix_to_nfa(string postfix)
        {
            for (int i = 0; i < postfix.Length; i++)
            {
                string h;
                switch (postfix[i])
                {
                    case 'a':
                    case 'b':
                        if (postfix[i] == 'a') symbol(0);
                        else symbol(1);
                        break;
                    case '*': zvezda(); break;
                    case '.': tochka(); break;
                    case '+': plus(); break;
                }
            }
        }

        public void CreateFirstString()
        {
            List<int> list = new List<int>();
            int nach = 0;
            for (int i = 0; i < nfa.Count; i++)
            {
                if (nfa[i].f == "nachalnoe")
                {
                    nach = i;
                    break;
                }
            }

            Struct.startList.Add(nach);

            for (int i = 0; i < nfa[nach].e.Count; i++)
            {
                list.Add(nfa[nach].e[i]);
                Struct.startList.Add(nfa[nach].e[i]);
            }

            while (list.Count != 0)
            {
                int pos = list[0];
                for (int i = 0; i < nfa[pos].e.Count; i++)
                {
                    if (!Struct.startList.Contains(nfa[pos].e[i]))
                    {
                        list.Add(nfa[pos].e[i]);
                        Struct.startList.Add(nfa[pos].e[i]);
                    }
                }

                list.RemoveAt(0);
            }
            Struct.startList.Sort();
        }

        public void CreateNFAstates()
        {
            List<int> list = new List<int>();


            for (int i = 0; i < nfa.Count; i++)
            {
                for (int n = 0; n < nfa[i].vetki.Length; n++)
                {
                    List<int> forAdding = new List<int>();

                    if (nfa[i].vetki[n] == "-")
                    {
                        Struct.nfaStates.Add(new List<int> { -1 });
                    }
                    else
                    {
                        int q = Convert.ToInt32(nfa[i].vetki[n]);
                        forAdding.Add(q);

                        for (int k = 0; k < nfa[q].e.Count; k++)
                        {
                            list.Add(Convert.ToInt32(nfa[q].e[k]));
                            forAdding.Add(Convert.ToInt32(nfa[q].e[k]));
                        }

                        while (list.Count != 0)
                        {
                            int pos = list[0];
                            for (int j = 0; j < nfa[pos].e.Count; j++)
                            {
                                if (!forAdding.Contains(nfa[pos].e[j]))
                                {
                                    list.Add(nfa[pos].e[j]);
                                    forAdding.Add(nfa[pos].e[j]);
                                }
                            }

                            list.RemoveAt(0);
                        }

                        forAdding.Sort();
                        Struct.nfaStates.Add(forAdding);
                    }

                }
            }
        }

        public void CreateFinish()
        {
            for (int i = 0; i < nfa.Count; i++)
            {
                if (nfa[i].f == "false" || nfa[i].f == "nachalnoe")
                {
                    Struct.finish.Add(false);
                }
                else
                {
                    Struct.finish.Add(true);
                }
            }
        }

        private void Vvod_Click(object sender, EventArgs e)
        {
            try
            {
                nfa.Clear();
                nfa_size = 0;
                postfix_to_nfa(rebuilt(InputBox.Text));
                int final_state = state.Peek(); state.Pop();
                int start_state = state.Peek(); state.Pop();


                nfa[final_state].f = "true";

                nfa[start_state].f = "nachalnoe";    


                CreateFirstString();
                CreateNFAstates();
                CreateFinish();
                transformaciyaNfaDfa.Enabled = true;


            }
            catch
            {
                MessageBox.Show("Регулярное выражение написано неверно", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Chitat(string nameread)
        {

            int n = 0;
            StreamReader reader = File.OpenText(nameread);
            StreamReader reader2 = File.OpenText(nameread);
            string xy = "";

            while ((xy = reader.ReadLine()) != null)
            {
                n++;
            }


            Struct.states = new int[n, Struct.alphabet.Length];
            Struct.isFinish = new bool[n];

            n = 0;

            while ((xy = reader2.ReadLine()) != null)
            {
                string[] split = xy.Split(' ');

                for (int i = 0; i < Struct.alphabet.Length; i++)
                {
                    Struct.states[n, i] = Convert.ToInt32(split[i]);
                }


                if (split[Struct.alphabet.Length].Equals("f"))
                {
                    Struct.isFinish[n] = false;
                }
                else
                {
                    Struct.isFinish[n] = true;
                }
                n++;

            }
        }

        public int KolichestvoSostoyaniy()
        {
            int max = -99;
            for (int i = 0; i < Struct.states.GetLength(0); i++)
            {
                for (int j = 0; j < Struct.states.GetLength(1); j++)
                {
                    if (max < Struct.states[i, j])
                    {
                        max = Struct.states[i, j];
                    }
                }
            }
            return max + 1;
        }



        public void VstavkaTablici()
        {

            int max = KolichestvoSostoyaniy();
            Struct.table = new int[max, max];

            for (int i = 0; i < max; i++) 
            {
                for (int j = 0; j < max; j++)
                {
                    Struct.table[i, j] = -1;
                }
            }

            for (int i = 0; i < max; i++)
            {
                for (int j = 0; j < max; j++)
                {
                    if (i > j)
                    {
                        Struct.table[i, j] = -99;
                    }
                }
            }


            for (int i = 0; i < max; i++)
            {
                Struct.table[i, i] = 2;
            }


            for (int i = 0; i < Struct.isFinish.Length; i++)
            {
                if (Struct.isFinish[i] == true)
                {
                    Struct.finstates.Add(i);
                }
                else
                {
                    Struct.unfinstates.Add(i);
                }
            }



            for (int i = 0; i < Struct.finstates.Count; i++)
            {
                for (int j = 0; j < Struct.unfinstates.Count; j++)
                {
                    if (Struct.finstates[i] < Struct.unfinstates[j])
                    {
                        Struct.table[Struct.finstates[i], Struct.unfinstates[j]] = 1;
                    }
                }
            }


            for (int k = 0; k < Struct.unfinstates.Count; k++)
            {
                for (int f = 0; f < Struct.finstates.Count; f++)
                {
                    if (Struct.unfinstates[k] < Struct.finstates[f])
                    {
                        Struct.table[Struct.unfinstates[k], Struct.finstates[f]] = 1;
                    }
                }
            }

            for (int i = 0; i < max; i++)
            {
                for (int j = 0; j < max; j++)
                {
                    if (Struct.table[i, j] == -1)
                    {
                        Struct.pairs.Add(new DlyaParVTabl(i, j));
                    }
                }
            }

            Struct.findStates = new DlyaParVTabl[Struct.pairs.Count, Struct.alphabet.Length + 1];


            for (int i = 0; i < Struct.pairs.Count; i++)
            {
                int n = Struct.pairs[i].FirstIndex;
                int m = Struct.pairs[i].SecondIndex;

                int firstA = Struct.states[n, 0];
                int secondA = Struct.states[m, 0];

                int firstB = Struct.states[n, 1];
                int secondB = Struct.states[m, 1];



                Struct.findStates[i, 0] = new DlyaParVTabl(n, m);

                if (firstA < secondA)
                {
                    Struct.findStates[i, 1] = new DlyaParVTabl(firstA, secondA);
                }
                else
                {
                    Struct.findStates[i, 1] = new DlyaParVTabl(secondA, firstA);
                }



                if (firstB < secondB)
                {
                    Struct.findStates[i, 2] = new DlyaParVTabl(firstB, secondB);
                }
                else
                {
                    Struct.findStates[i, 2] = new DlyaParVTabl(secondB, firstB);
                }
            }

            int flag = 0;
            while (flag < 8)
            {
                for (int i = 0; i < Struct.pairs.Count; i++)
                {
                    int n = Struct.findStates[i, 1].FirstIndex;
                    int m = Struct.findStates[i, 1].SecondIndex;

                    int l = Struct.findStates[i, 2].FirstIndex;
                    int k = Struct.findStates[i, 2].SecondIndex;


                    int oboznachA = Struct.table[n, m];
                    int oboznachB = Struct.table[l, k];

                    if (oboznachA == 1 || oboznachB == 1)
                    {
                        Struct.table[Struct.findStates[i, 0].FirstIndex, Struct.findStates[i, 0].SecondIndex] = 1;
                    }
                    if (oboznachA == 0 || oboznachB == 0)
                    {
                        Struct.table[Struct.findStates[i, 0].FirstIndex, Struct.findStates[i, 0].SecondIndex] = 2;
                    }
                }
                flag++;
            }


            for (int d = 0; d < Struct.table.GetLength(0); d++)
            {
                for (int y = 0; y < Struct.table.GetLength(1); y++)
                {
                    if (Struct.table[d, y] == -1)
                    {
                        Struct.table[d, y] = 2;
                    }
                }
            }
        }

        public void SozdaniyeMin()
        {
            List<List<int>> pari = new List<List<int>>();

            int i = 0;


            while (i < Struct.table.GetLength(0))
            {
                List<int> list = new List<int>();
                for (int j = 0; j < Struct.table.GetLength(1); j++)
                {
                    if (Struct.table[i, j] == 2)
                    {
                        if (!list.Contains(i))
                        {
                            list.Add(i);
                        }
                        if (!list.Contains(j))
                        {
                            list.Add(j);
                        }



                        for (int k = 0; k < Struct.table.GetLength(1); k++)
                        {
                            if (Struct.table[k, j] == 2)
                            {
                                if (!list.Contains(k))
                                {
                                    list.Add(k);
                                }
                                if (!list.Contains(j))
                                {
                                    list.Add(j);
                                }
                            }
                        }
                    }
                }
                pari.Add(list);
                i++;


                List<int> isp = new List<int>();
                for (int x = 0; x < pari.Count; x++)
                {
                    for (int y = 0; y < pari[x].Count; y++)
                    {
                        isp.Add(pari[x][y]);
                    }
                }


                bool flag = true;

                while (flag)
                {
                    if (isp.Contains(i))
                    {
                        i++;
                    }
                    else
                    {
                        flag = false;
                    }
                }
            }



            List<int> shifr = new List<int>();

            for (int a = 0; a < pari.Count; a++)
            {
                shifr.Add(a);
            }
            pari.Add(shifr);


            Struct.IsFinForMin = new bool[pari.Count - 1];

            for (int x = 0; x < pari.Count - 1; x++)
            {
                int e = pari[x][0];
                Struct.IsFinForMin[x] = Struct.isFinish[e];
            }

            Struct.mintable = new int[pari.Count - 1, Struct.alphabet.Length];


            for (int c = 0; c < pari.Count - 1; c++)
            {
                for (int j = 0; j < pari[c].Count; j++)
                {
                    int k = pari[c][j];

                    int a = Struct.states[k, 0];
                    int b = Struct.states[k, 1];


                    for (int q = 0; q < pari.Count - 1; q++)
                    {
                        for (int x = 0; x < pari[q].Count; x++)
                        {
                            if (pari[q][x] == a)
                            {
                                Struct.mintable[c, 0] = pari[pari.Count - 1][q];
                            }
                            if (pari[q][x] == b)
                            {
                                Struct.mintable[c, 1] = pari[pari.Count - 1][q];
                            }
                        }
                    }
                }
            }
        }

        public void ZapisMin()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter("Minimizirovanniy.txt", false, System.Text.Encoding.Default))
                {
                    for (int i = 0; i < Struct.mintable.GetLength(0); i++)
                    {
                        string s = "";
                        if (Struct.IsFinForMin[i])
                        {
                            s = "t";
                        }
                        if (!Struct.IsFinForMin[i])
                        {
                            s = "f";
                        }
                        sw.WriteLine(Struct.mintable[i, 0] + " " + Struct.mintable[i, 1] + " " + s);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }



        // ForNFA
        public void Determinizaciya()
        {
            bool flag = true;

            Struct.toDfaTable.Add(Struct.startList);

            int k = 0;

            int z = 1;

            List<List<int>> ostatok = new List<List<int>>();

            while (flag)
            {
                for (int s = 0; s < Struct.alphabet.Length; s++)
                {
                    List<int> list = new List<int>();
                    for (int i = 0; i < Struct.toDfaTable[k].Count; i++)
                    {
                        int x = Struct.toDfaTable[k][i];
                        for (int j = 0; j < Struct.nfaStates[Struct.alphabet.Length * x + s].Count; j++)
                        {
                            if (!list.Contains(Struct.nfaStates[Struct.alphabet.Length * x + s][j]) && Struct.nfaStates[Struct.alphabet.Length * x + s][j] != -1)
                            {
                                list.Add(Struct.nfaStates[Struct.alphabet.Length * x + s][j]);
                            }
                        }
                    }

                    list.Sort();
                    Struct.toDfaTable.Add(list);
                }

                int count = 0;

                for (int s = 0; s < Struct.alphabet.Length; s++)
                {
                    for (int a = 0; a < Struct.toDfaTable.Count; a = a + Struct.alphabet.Length + 1)
                    {
                        if (Struct.toDfaTable[a].Count == Struct.toDfaTable[k + 1 + s].Count)
                        {
                            for (int p = 0; p < Struct.toDfaTable[a].Count; p++)
                            {
                                if (Struct.toDfaTable[a][p] == Struct.toDfaTable[k + 1 + s][p])
                                {

                                }
                            }
                        }

                        else
                        {
                            count++;
                        }
                    }

                    if (count == z)
                    {
                        ostatok.Add(Struct.toDfaTable[k + 1 + s]);
                        count = 0;
                    }
                }
                if (ostatok.Count == 0)
                {
                    flag = false;
                }

                else
                {
                    Struct.toDfaTable.Add(ostatok[0]);
                    ostatok.RemoveAt(0);
                    k = k + Struct.alphabet.Length + 1;
                    z++;
                }
            }


        }

        public void Shifrovanie()
        {
            int count = 0;

            int b = 0;

            for (int i = 0; i < Struct.toDfaTable.Count; i++)
            {
                Struct.resultDFA.Add(i);
            }

            for (int j = 0; j < Struct.toDfaTable.Count; j = j + Struct.alphabet.Length + 1, count++)
            {
                for (int k = 0; k < Struct.toDfaTable.Count; k++)
                {
                    if (Struct.toDfaTable[j].Count == Struct.toDfaTable[k].Count)
                    {
                        if (Struct.toDfaTable[j].All(Struct.toDfaTable[k].Contains))
                        {
                            Struct.resultDFA[k] = b;
                        }
                    }

                }
                b++;
            }
        }

        public void KonechniyeDlyaDFA()
        {
            int count = 0;

            for (int i = 0; i < Struct.toDfaTable.Count; i = i + Struct.alphabet.Length + 1)
            {
                for (int j = 0; j < Struct.toDfaTable[i].Count; j++)
                {
                    int k = Struct.toDfaTable[i][j];

                    if (Struct.finish[k] == false)
                    {
                        count++;
                    }
                }

                if (count == Struct.toDfaTable[i].Count)
                {
                    Struct.resultfinishDFA.Add(false);
                }
                else
                {
                    Struct.resultfinishDFA.Add(true);
                }
                count = 0;
            }
        }

        public void UdaleniyeStroki()
        {

            for (int h = 0; h < Struct.resultDFA.Count; h = h + Struct.alphabet.Length)
            {
                Struct.resultDFA.RemoveAt(h);
            }

        }

        public void ZapisDFA()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter("DFA.txt", false, System.Text.Encoding.Default))
                {
                    if (Struct.alphabet.Length == 2)
                    {
                        for (int i = 0; i < Struct.resultfinishDFA.Count; i++)
                        {
                            string s = "";
                            if (Struct.resultfinishDFA[i])
                            {
                                s = "t";
                            }
                            if (!Struct.resultfinishDFA[i])
                            {
                                s = "f";
                            }
                            sw.WriteLine(Struct.resultDFA[2 * i] + " " + Struct.resultDFA[2 * i + 1] + " " + s);
                        }
                    }

                    if (Struct.alphabet.Length == 1)
                    {
                        for (int i = 0; i < Struct.resultfinishDFA.Count; i++)
                        {
                            string s = "";
                            if (Struct.resultfinishDFA[i])
                            {
                                s = "t";
                            }
                            if (!Struct.resultfinishDFA[i])
                            {
                                s = "f";
                            }
                            sw.WriteLine(Struct.resultDFA[2 * i] + " " + s);
                        }
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void VvodTexta_Click(object sender, EventArgs e)
        {
                str = StringInput.Text;

                string alphabet = string.Join(null, Struct.alphabet);

                for (int i = 0; i < str.Length; i++)
                {
                    if (!alphabet.Contains(str[i].ToString()))
                    {
                        MessageBox.Show("Owibochnaya zapis, v alfavite net takix simvolov", "Obrati vnimamiye", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                NomerSostoyaniya.Text = "0";

                NextSostoyaniye.Enabled = true;
                VvodTexta.Enabled = false;
                VsyaStrokaSrazu.Enabled = true;
        }

        private void NextSostoyaniye_Click(object sender, EventArgs e)
        {
            if (str.Length == 0)
            {
                MessageBox.Show("Ostanovka na poziciyi " + currentState + Environment.NewLine + "eto ne finish, = stroka ploxaya", "Struct", MessageBoxButtons.OK, MessageBoxIcon.Error);
                NextSostoyaniye.Enabled = false;
                VvodTexta.Enabled = true;
                return;
            }


            for (int i = 0; i < Struct.alphabet.Length; i++)
            {
                if (str[countLetter].ToString().Equals(Struct.alphabet[i]))
                {
                    currentState = Struct.states[currentState, i];
                }
            }
                      isFinish = Struct.isFinish[currentState];
            countLetter++;

            NextSostoyaniye.Text = ("Proverka simvola №" + (countLetter + 1)).ToString();



            NomerSostoyaniya.Text = currentState.ToString();
            if (isFinish)
            {
                NomerSostoyaniya.ForeColor = Color.Green;
            }
            else NomerSostoyaniya.ForeColor = Color.Black;



            if (str.Length == countLetter)
            {
                if (isFinish)
                {
                    MessageBox.Show("Ostanovka na poziciyi " + currentState + Environment.NewLine + "eto finish, = stroka xorowaya", "Struct", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    currentState = 0;
                    countLetter = 0;
                    NextSostoyaniye.Text = ("Proverka simvola №" + (countLetter + 1)).ToString();

                    NextSostoyaniye.Enabled = false;
                    VvodTexta.Enabled = true;
                    VsyaStrokaSrazu.Enabled = false;

                }
                if (!isFinish)
                {
                    MessageBox.Show("Ostanovka na poziciyi " + currentState + Environment.NewLine + "eto ne finish, = stroka ploxaya", "Struct", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    currentState = 0;
                    countLetter = 0;
                    NextSostoyaniye.Text = ("Proverka simvola №" + (countLetter + 1)).ToString();

                    NomerSostoyaniya.ForeColor = Color.Black;

                    NextSostoyaniye.Enabled = false;
                    VvodTexta.Enabled = true;
                    VsyaStrokaSrazu.Enabled = false;
                }
            }
        }

        private void VsyaStrokaSrazu_Click(object sender, EventArgs e)
        {
            for (int j = 0; j < str.Length; j++)
            {
                if (str.Length == 0)
                {
                    MessageBox.Show("Ostanovka na poziciyi " + currentState + Environment.NewLine + "eto ne finish, = stroka ploxaya", "Struct", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    NextSostoyaniye.Enabled = false;
                    VvodTexta.Enabled = true;
                    return;
                }


                for (int i = 0; i < Struct.alphabet.Length; i++)
                {
                    if (str[countLetter].ToString().Equals(Struct.alphabet[i]))
                    {
                        currentState = Struct.states[currentState, i];
                    }
                }

                isFinish = Struct.isFinish[currentState];

                countLetter++;


                NomerSostoyaniya.Text = currentState.ToString();
                if (isFinish)
                {
                    NomerSostoyaniya.ForeColor = Color.Green;
                }
                else NomerSostoyaniya.ForeColor = Color.Black;



                if (str.Length == countLetter)
                {
                    if (isFinish)
                    {
                        MessageBox.Show("Ostanovka na poziciyi " + currentState + Environment.NewLine + "eto finish, = stroka xorowaya", "Struct", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        currentState = 0;
                        countLetter = 0;


                        NextSostoyaniye.Enabled = false;
                        VvodTexta.Enabled = true;
                        VsyaStrokaSrazu.Enabled = false;

                    }
                    if (!isFinish)
                    {
                        MessageBox.Show("Ostanovka na poziciyi " + currentState + Environment.NewLine + "eto ne finish, = stroka ploxaya", "Struct", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        currentState = 0;
                        countLetter = 0;

                        NomerSostoyaniya.ForeColor = Color.Black;

                        NextSostoyaniye.Enabled = false;
                        VvodTexta.Enabled = true;
                        VsyaStrokaSrazu.Enabled = false;
                    }
                }
            }
        }

        private void MinimizaciyaAvtomata_Click(object sender, EventArgs e)
        {
            VstavkaTablici();
            SozdaniyeMin();
            ZapisMin();
            groupBox3.Enabled = true;
            VvodTextaMin.Enabled = true;
        }

        private void VvodTextaMin_Click(object sender, EventArgs e)
        {
            str = StringInputMin.Text;

            string alphabet = string.Join(null, Struct.alphabet);

            for (int i = 0; i < str.Length; i++)
            {
                if (!alphabet.Contains(str[i].ToString()))
                {
                    MessageBox.Show("Owibochnaya zapis, v alfavite net takix simvolov", "Obrati vnimamiye", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            NomerSostoyaniyaMin.Text = "0";

            NextSostoyaniyeMin.Enabled = true;
            VvodTextaMin.Enabled = false;
            VsyaStrokaSrazuMin.Enabled = true;
        }

        private void NextSostoyaniyeMin_Click(object sender, EventArgs e)
        {
            if (str.Length == 0)
            {
                MessageBox.Show("Ostanovka na poziciyi " + currentState + Environment.NewLine + "eto ne finish, = stroka ploxaya", "Struct", MessageBoxButtons.OK, MessageBoxIcon.Error);
                NextSostoyaniyeMin.Enabled = false;
                VvodTextaMin.Enabled = true;
                return;
            }


            for (int i = 0; i < Struct.alphabet.Length; i++)
            {
                if (str[countLetter].ToString().Equals(Struct.alphabet[i]))
                {
                    currentState = Struct.mintable[currentState, i];
                }
            }

            isFinish = Struct.IsFinForMin[currentState];


            countLetter++;

            NextSostoyaniyeMin.Text = ("Proverka simvola №" + (countLetter + 1)).ToString();



            NomerSostoyaniyaMin.Text = currentState.ToString();
            if (isFinish)
            {
                NomerSostoyaniyaMin.ForeColor = Color.Green;
            }
            else NomerSostoyaniyaMin.ForeColor = Color.Black;



            if (str.Length == countLetter)
            {
                if (isFinish)
                {
                    MessageBox.Show("Ostanovka na poziciyi " + currentState + Environment.NewLine + "eto finish, = stroka xorowaya", "Struct", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    currentState = 0;
                    countLetter = 0;
                    NextSostoyaniyeMin.Text = ("Proverka simvola №" + (countLetter + 1)).ToString();

                    NextSostoyaniyeMin.Enabled = false;
                    VvodTextaMin.Enabled = true;
                    VsyaStrokaSrazuMin.Enabled = false;

                }
                if (!isFinish)
                {
                    MessageBox.Show("Ostanovka na poziciyi " + currentState + Environment.NewLine + "eto ne finish, = stroka ploxaya", "Struct", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    currentState = 0;
                    countLetter = 0;
                    NextSostoyaniyeMin.Text = ("Proverka simvola №" + (countLetter + 1)).ToString();

                    NomerSostoyaniyaMin.ForeColor = Color.Black;

                    NextSostoyaniyeMin.Enabled = false;
                    VvodTextaMin.Enabled = true;
                    VsyaStrokaSrazuMin.Enabled = false;
                }
            }
        }

        private void VsyaStrokaSrazuMin_Click(object sender, EventArgs e)
        {
            for (int j = 0; j < str.Length; j++)
            {
                if (str.Length == 0)
                {
                    MessageBox.Show("Ostanovka na poziciyi " + currentState + Environment.NewLine + "eto ne finish, = stroka ploxaya", "Struct", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    NextSostoyaniyeMin.Enabled = false;
                    VvodTextaMin.Enabled = true;
                    return;
                }


                for (int i = 0; i < Struct.alphabet.Length; i++)
                {
                    if (str[countLetter].ToString().Equals(Struct.alphabet[i]))
                    {
                        currentState = Struct.mintable[currentState, i];
                    }
                }

                isFinish = Struct.IsFinForMin[currentState];


                countLetter++;

                NextSostoyaniyeMin.Text = ("Proverka simvola №" + (countLetter + 1)).ToString();



                NomerSostoyaniyaMin.Text = currentState.ToString();
                if (isFinish)
                {
                    NomerSostoyaniyaMin.ForeColor = Color.Green;
                }
                else NomerSostoyaniyaMin.ForeColor = Color.Black;



                if (str.Length == countLetter)
                {
                    if (isFinish)
                    {
                        MessageBox.Show("Ostanovka na poziciyi " + currentState + Environment.NewLine + "eto finish, = stroka xorowaya", "Struct", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        currentState = 0;
                        countLetter = 0;
                        NextSostoyaniyeMin.Text = ("Proverka simvola №" + (countLetter + 1)).ToString();

                        NextSostoyaniyeMin.Enabled = false;
                        VvodTextaMin.Enabled = true;
                        VsyaStrokaSrazuMin.Enabled = false;

                    }
                    if (!isFinish)
                    {
                        MessageBox.Show("Ostanovka na poziciyi " + currentState + Environment.NewLine + "eto ne finish, = stroka ploxaya", "Struct", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        currentState = 0;
                        countLetter = 0;
                        NextSostoyaniyeMin.Text = ("Proverka simvola №" + (countLetter + 1)).ToString();

                        NomerSostoyaniyaMin.ForeColor = Color.Black;

                        NextSostoyaniyeMin.Enabled = false;
                        VvodTextaMin.Enabled = true;
                        VsyaStrokaSrazuMin.Enabled = false;
                    }
                }
            }
        }

        private void TransformaciyaNfaDfa_Click(object sender, EventArgs e)
        {
            Determinizaciya();
            Shifrovanie();
            KonechniyeDlyaDFA();
            UdaleniyeStroki();
            ZapisDFA();

            string path = "DFA.txt";
            Chitat(path);

            groupBox2.Enabled = true;
            MinimizaciyaAvtomata.Enabled = true;
        }

        
    }
}
