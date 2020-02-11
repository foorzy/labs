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


                if (split[Struct.alphabet.Length].Equals("n"))
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
                if (count == 0) //считываем сначала 1 строку файла
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


                    if (split[Struct.alphabet.Length].Equals("n"))
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
        private void VvodAlfavita_Click(object sender, EventArgs e)
        {
            try
            {
                string strr = InputBox.Text;

                if (strr.Length == 0)
                {
                    MessageBox.Show("Owibka v faile s alfavitom!", "Obrati vnimamiye", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (strr.Length > 1)
                {
                    for (int i = 1; i < strr.Length; i = i + 2)
                    {
                        if (!strr[i].Equals('*'))
                        {
                            MessageBox.Show("Owibka v faile s alfavitom!", "Obrati vnimamiye", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }

                Struct.alphabet = strr.Split('*');
                Schitka.Enabled = true;
            }
            catch
            {
                MessageBox.Show("Owibka schitki alfavita", "Obrati vnimamiye", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (Struct.alphabet.Length != 0)
            {
                ChtoVNem.Text = "'";
                for (int i = 0; i < Struct.alphabet.Length; i++)
                {
                    if (i == Struct.alphabet.Length - 1)
                    {
                        ChtoVNem.Text += Struct.alphabet[i];
                    }
                    else ChtoVNem.Text += Struct.alphabet[i] + " ";
                }
                ChtoVNem.Text += "'";
            }
        }

        private void Schitka_Click(object sender, EventArgs e)
        {
            try
            {
                string file = "";
                Otkrit(ref file);
                ChitatNFA(file);
                transformaciyaNfaDfa.Enabled = true;
            }
            catch
            {
                MessageBox.Show("Owibka schitki faila", "Obrati vnimamiye", MessageBoxButtons.OK, MessageBoxIcon.Error);
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


                if (split[Struct.alphabet.Length].Equals("n"))
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
            //int max = 5;
            int max = KolichestvoSostoyaniy();
            Struct.table = new int[max, max];

            for (int i = 0; i < max; i++) // заполняем всё -1
            {
                for (int j = 0; j < max; j++)
                {
                    Struct.table[i, j] = -1;
                }
            }

            for (int i = 0; i < max; i++) // заполняем -99 ниже главной диагонали
            {
                for (int j = 0; j < max; j++)
                {
                    if (i > j)
                    {
                        Struct.table[i, j] = -99;
                    }
                }
            }


            for (int i = 0; i < max; i++)  //заполняем 0лями главную диагональ
            {
                Struct.table[i, i] = 2;
            }


            for (int i = 0; i < Struct.isFinish.Length; i++)  //узнаем конечные и не конечные состояния и кидаем их в список
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



            for (int i = 0; i < Struct.finstates.Count; i++) //доб в пары где сначала фигальные сост и заносим в таблицу
            {
                for (int j = 0; j < Struct.unfinstates.Count; j++)
                {
                    if (Struct.finstates[i] < Struct.unfinstates[j])
                    {
                        Struct.table[Struct.finstates[i], Struct.unfinstates[j]] = 1;
                    }
                }
            }


            for (int k = 0; k < Struct.unfinstates.Count; k++)  // доб в пары где сначала нефинальные сост и заносим в таблицу
            {
                for (int f = 0; f < Struct.finstates.Count; f++)
                {
                    if (Struct.unfinstates[k] < Struct.finstates[f])
                    {
                        Struct.table[Struct.unfinstates[k], Struct.finstates[f]] = 1;
                    }
                }
            }

            for (int i = 0; i < max; i++)  // добавляем в пары пустые места в таблице
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


            for (int i = 0; i < Struct.pairs.Count; i++)  // ищем переходы по буквам и загружаем в массив findStates
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
                for (int i = 0; i < Struct.pairs.Count; i++) // Переводим состояния в обозначения и заносим таблицу
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


            for (int d = 0; d < Struct.table.GetLength(0); d++) // если остались пустые клетки в таблице
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


            while (i < Struct.table.GetLength(0)) // проходим по строкам, while чтобы можно было перескочить строку, если такое состояние уже было в списке
            {
                List<int> list = new List<int>();
                for (int j = 0; j < Struct.table.GetLength(1); j++) //по столбцам
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


                List<int> isp = new List<int>(); // созд лист куда поместим все состояния которые уже есть в листах
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

            for (int a = 0; a < pari.Count; a++) //добавляем в конец шифрование для каждого состояния
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

            //составляем финальную табличку с минимальным колличеством переходов

            Struct.mintable = new int[pari.Count - 1, Struct.alphabet.Length];


            for (int c = 0; c < pari.Count - 1; c++) //идем по всем листам
            {
                for (int j = 0; j < pari[c].Count; j++) //по всем элементам листа
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
                            s = "y";
                        }
                        if (!Struct.IsFinForMin[i])
                        {
                            s = "n";
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
                    for (int a = 0; a < Struct.toDfaTable.Count; a = a + Struct.alphabet.Length + 1) // проверка на совпадение списков состояний
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
            //List<int>shoudaliat = new List<int>();
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
                                s = "y";
                            }
                            if (!Struct.resultfinishDFA[i])
                            {
                                s = "n";
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
                                s = "y";
                            }
                            if (!Struct.resultfinishDFA[i])
                            {
                                s = "n";
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
                MessageBox.Show("Ostanovka na poziciyi " + currentState + Environment.NewLine + "eto ne finish, = stroka ploxaya", "Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show("Ostanovka na poziciyi " + currentState + Environment.NewLine + "eto finish, = stroka xorowaya", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    currentState = 0;
                    countLetter = 0;
                    NextSostoyaniye.Text = ("Proverka simvola №" + (countLetter + 1)).ToString();

                    NextSostoyaniye.Enabled = false;
                    VvodTexta.Enabled = true;
                    VsyaStrokaSrazu.Enabled = false;

                }
                if (!isFinish)
                {
                    MessageBox.Show("Ostanovka na poziciyi " + currentState + Environment.NewLine + "eto ne finish, = stroka ploxaya", "Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show("Ostanovka na poziciyi " + currentState + Environment.NewLine + "eto ne finish, = stroka ploxaya", "Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        MessageBox.Show("Ostanovka na poziciyi " + currentState + Environment.NewLine + "eto finish, = stroka xorowaya", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        currentState = 0;
                        countLetter = 0;


                        NextSostoyaniye.Enabled = false;
                        VvodTexta.Enabled = true;
                        VsyaStrokaSrazu.Enabled = false;

                    }
                    if (!isFinish)
                    {
                        MessageBox.Show("Ostanovka na poziciyi " + currentState + Environment.NewLine + "eto ne finish, = stroka ploxaya", "Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Ostanovka na poziciyi " + currentState + Environment.NewLine + "eto ne finish, = stroka ploxaya", "Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show("Ostanovka na poziciyi " + currentState + Environment.NewLine + "eto finish, = stroka xorowaya", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    currentState = 0;
                    countLetter = 0;
                    NextSostoyaniyeMin.Text = ("Proverka simvola №" + (countLetter + 1)).ToString();

                    NextSostoyaniyeMin.Enabled = false;
                    VvodTextaMin.Enabled = true;
                    VsyaStrokaSrazuMin.Enabled = false;

                }
                if (!isFinish)
                {
                    MessageBox.Show("Ostanovka na poziciyi " + currentState + Environment.NewLine + "eto ne finish, = stroka ploxaya", "Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show("Ostanovka na poziciyi " + currentState + Environment.NewLine + "eto ne finish, = stroka ploxaya", "Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        MessageBox.Show("Ostanovka na poziciyi " + currentState + Environment.NewLine + "eto finish, = stroka xorowaya", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        currentState = 0;
                        countLetter = 0;
                        NextSostoyaniyeMin.Text = ("Proverka simvola №" + (countLetter + 1)).ToString();

                        NextSostoyaniyeMin.Enabled = false;
                        VvodTextaMin.Enabled = true;
                        VsyaStrokaSrazuMin.Enabled = false;

                    }
                    if (!isFinish)
                    {
                        MessageBox.Show("Ostanovka na poziciyi " + currentState + Environment.NewLine + "eto ne finish, = stroka ploxaya", "Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            // функиции для перевода из NFA --> DFA
            Determinizaciya();
            Shifrovanie();
            KonechniyeDlyaDFA();
            UdaleniyeStroki();
            ZapisDFA();

            //считываем готовый DFA 
            string path = "DFA.txt";
            Chitat(path);

            groupBox2.Enabled = true;
            MinimizaciyaAvtomata.Enabled = true;
        }
    }
}
