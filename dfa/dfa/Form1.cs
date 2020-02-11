using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dfaBondarenko
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int schetchikDlyaBukv = 0;
        int tekuweeSostoyaniye = 0;
        bool FiniteOrNot;
        string str;

        private void Otkrit(ref string imya)
        {
            OpenFileDialog otkrit = new OpenFileDialog();
            try
            {
                if (otkrit.ShowDialog() == DialogResult.OK)
                {
                    imya = otkrit.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Chitat(string imya)
        {
            int counter = 0;
            StreamReader chitaem = File.OpenText(imya);
            StreamReader chitayemnext = File.OpenText(imya);
            string vvodimayaStroka = "";
            try
            {
                while ((vvodimayaStroka = chitaem.ReadLine()) != null)
                {
                    counter++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Struct.sostoyaniye = new int[counter, Struct.alfavit.Length];
            Struct.finite = new bool[counter];
            counter = 0;
            try
            {
                while ((vvodimayaStroka = chitayemnext.ReadLine()) != null)
                {
                    string[] split = vvodimayaStroka.Split(' ');

                    for (int schetchik1 = 0; schetchik1 < Struct.alfavit.Length; schetchik1++)
                    {
                        Struct.sostoyaniye[counter, schetchik1] = Convert.ToInt32(split[schetchik1]);
                    }
                    if (split[Struct.alfavit.Length].Equals("n"))
                    {
                        Struct.finite[counter] = false;
                    }
                    else
                    {
                        Struct.finite[counter] = true;
                    }
                    counter++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public int PodschetSostoyaniyDlyaMin()
        {
            int granica = -1;
            try
            {
                for (int schetchik1 = 0; schetchik1 < Struct.sostoyaniye.GetLength(0); schetchik1++)
                {
                    for (int schetchik2 = 0; schetchik2 < Struct.sostoyaniye.GetLength(1); schetchik2++)
                    {
                        if (granica < Struct.sostoyaniye[schetchik1, schetchik2])
                        {
                            granica = Struct.sostoyaniye[schetchik1, schetchik2] + 1;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return granica;
        }

        private void VvodAlfavita_Click(object sender, EventArgs e)
        {
            try
            {
                string stroka = InputBox.Text;
                if (stroka.Length == 0)
                {
                    MessageBox.Show("Nekorrektniy vvod!", "Vnimaniye!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (stroka.Length > 1)
                {
                    for (int schetchik1 = 1; schetchik1 < stroka.Length; schetchik1 = schetchik1 + 2)
                    {
                        if (!stroka[schetchik1].Equals('*'))
                        {
                            MessageBox.Show("Nekorrektniy vvod!", "Vnimaniye!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }

                Struct.alfavit = stroka.Split('*');
                Schitka.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (Struct.alfavit.Length != 0)
            {
                ChtoVNem.Text = "'";
                try
                {
                    for (int schetchik1 = 0; schetchik1 < Struct.alfavit.Length; schetchik1++)
                    {
                        if (schetchik1 == Struct.alfavit.Length - 1)
                        {
                            ChtoVNem.Text += Struct.alfavit[schetchik1];
                        }
                        else ChtoVNem.Text += Struct.alfavit[schetchik1] + " ";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                ChtoVNem.Text += "'";
            }
        }

        private void VvodTexta_Click(object sender, EventArgs e)
        {
            str = StringInput.Text;
            string alfavit = string.Join(null, Struct.alfavit);
            try
            {
                for (int schetchik1 = 0; schetchik1 < str.Length; schetchik1++)
                {
                    if (!alfavit.Contains(str[schetchik1].ToString()))
                    {
                        MessageBox.Show("Nekorrektniy vvod!!", "Vnimaniye!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            NomerSostoyaniya.Text = "0";
            NextSostoyaniye.Enabled = true;
            VvodTexta.Enabled = false;
            VsyaStrokaSrazu.Enabled = true;
        }

        private void Schitka_Click(object sender, EventArgs e)
        {
            try
            {
                string file = "";
                Otkrit(ref file);
                Chitat(file);
                groupBox2.Enabled = true;
                MinimizaciyaAvtomata.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void NextSostoyaniye_Click(object sender, EventArgs e)
        {
            try
            {
                if (str.Length == 0)
                {
                    MessageBox.Show("Pustaya stroka", ":c", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    NextSostoyaniye.Enabled = false;
                    VvodTexta.Enabled = true;
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                for (int schetchik1 = 0; schetchik1 < Struct.alfavit.Length; schetchik1++)
                {
                    if (str[schetchikDlyaBukv].ToString().Equals(Struct.alfavit[schetchik1]))
                    {
                        tekuweeSostoyaniye = Struct.sostoyaniye[tekuweeSostoyaniye, schetchik1];
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            FiniteOrNot = Struct.finite[tekuweeSostoyaniye];
            schetchikDlyaBukv++;
            NomerSostoyaniya.Text = tekuweeSostoyaniye.ToString();
            try
            {
                if (FiniteOrNot)
                {
                    NomerSostoyaniya.ForeColor = Color.Green;
                }
                else NomerSostoyaniya.ForeColor = Color.Black;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                if (str.Length == schetchikDlyaBukv)
                {
                    if (FiniteOrNot)
                    {
                        MessageBox.Show("Itogovoye sostoyeniye " + tekuweeSostoyaniye + Environment.NewLine + "Ono finishnoye, peremoga!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tekuweeSostoyaniye = 0;
                        schetchikDlyaBukv = 0;
                        NextSostoyaniye.Enabled = false;
                        VvodTexta.Enabled = true;
                        VsyaStrokaSrazu.Enabled = false;

                    }
                    if (!FiniteOrNot)
                    {
                        MessageBox.Show("Itogovoye sostoyeniye " + tekuweeSostoyaniye + Environment.NewLine + "Ono ne finishnoye, zrada!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        tekuweeSostoyaniye = 0;
                        schetchikDlyaBukv = 0;
                        NomerSostoyaniya.ForeColor = Color.Black;
                        NextSostoyaniye.Enabled = false;
                        VvodTexta.Enabled = true;
                        VsyaStrokaSrazu.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void VsyaStrokaSrazu_Click(object sender, EventArgs e)
        {
            try
            {
                for (int schetchik2 = 0; schetchik2 < str.Length; schetchik2++)
                {
                    try
                    {
                        if (str.Length == 0)
                        {
                            MessageBox.Show("Itogovoye sostoyeniye " + tekuweeSostoyaniye + Environment.NewLine + "Ono ne finishnoye, zrada!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            NextSostoyaniye.Enabled = false;
                            VvodTexta.Enabled = true;
                            return;
                        }
                        for (int schetchik1 = 0; schetchik1 < Struct.alfavit.Length; schetchik1++)
                        {
                            if (str[schetchikDlyaBukv].ToString().Equals(Struct.alfavit[schetchik1]))
                            {
                                tekuweeSostoyaniye = Struct.sostoyaniye[tekuweeSostoyaniye, schetchik1];
                            }
                        }

                        FiniteOrNot = Struct.finite[tekuweeSostoyaniye];
                        schetchikDlyaBukv++;
                        NomerSostoyaniya.Text = tekuweeSostoyaniye.ToString();
                        try
                        {
                            if (FiniteOrNot)
                            {
                                NomerSostoyaniya.ForeColor = Color.Green;
                            }
                            else NomerSostoyaniya.ForeColor = Color.Black;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        try
                        {
                            if (str.Length == schetchikDlyaBukv)
                            {
                                if (FiniteOrNot)
                                {
                                    MessageBox.Show("Itogovoye sostoyeniye " + tekuweeSostoyaniye + Environment.NewLine + "Ono finishnoye, peremoga!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    tekuweeSostoyaniye = 0;
                                    schetchikDlyaBukv = 0;
                                    NextSostoyaniye.Enabled = false;
                                    VvodTexta.Enabled = true;
                                    VsyaStrokaSrazu.Enabled = false;
                                }
                                if (!FiniteOrNot)
                                {
                                    MessageBox.Show("Itogovoye sostoyeniye " + tekuweeSostoyaniye + Environment.NewLine + "Ono ne finishnoye, zrada!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    tekuweeSostoyaniye = 0;
                                    schetchikDlyaBukv = 0;
                                    NomerSostoyaniya.ForeColor = Color.Black;
                                    NextSostoyaniye.Enabled = false;
                                    VvodTexta.Enabled = true;
                                    VsyaStrokaSrazu.Enabled = false;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void TablicaDlyaMin()
        {
            int granica = PodschetSostoyaniyDlyaMin();
            Struct.tablica = new int[granica, granica];
            // zapolneniye -1 vsego
            try
            {
                for (int schetchik1 = 0; schetchik1 < granica; schetchik1++)
                {
                    for (int schetchik2 = 0; schetchik2 < granica; schetchik2++)
                    {
                        Struct.tablica[schetchik1, schetchik2] = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // -99 - vse, wo nizhe diagonali
            try
            {
                for (int schetchik1 = 0; schetchik1 < granica; schetchik1++)
                {
                    for (int schetchik2 = 0; schetchik2 < granica; schetchik2++)
                    {
                        if (schetchik1 > schetchik2)
                        {
                            Struct.tablica[schetchik1, schetchik2] = -99;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //2-ki - diagonal, dlya otdeleniya
            try
            {
                for (int schetchik1 = 0; schetchik1 < granica; schetchik1++)
                {
                    Struct.tablica[schetchik1, schetchik1] = 2;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //check na finite i nefinite
            try
            {
                for (int schetchik1 = 0; schetchik1 < Struct.finite.Length; schetchik1++)
                {
                    if (Struct.finite[schetchik1] == true)
                    {
                        Struct.finiteSostoyaniya.Add(schetchik1);
                    }
                    else
                    {
                        Struct.nefiniteSostoyaniya.Add(schetchik1);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //add finite
            try
            {
                for (int schetchik1 = 0; schetchik1 < Struct.finiteSostoyaniya.Count; schetchik1++)
                {
                    for (int schetchik2 = 0; schetchik2 < Struct.nefiniteSostoyaniya.Count; schetchik2++)
                    {
                        if (Struct.finiteSostoyaniya[schetchik1] < Struct.nefiniteSostoyaniya[schetchik2])
                        {
                            Struct.tablica[Struct.finiteSostoyaniya[schetchik1], Struct.nefiniteSostoyaniya[schetchik2]] = 1;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // add nefinite
            try
            {
                for (int counter22 = 0; counter22 < Struct.nefiniteSostoyaniya.Count; counter22++) 
                {
                    for (int f = 0; f < Struct.finiteSostoyaniya.Count; f++)
                    {
                        if (Struct.nefiniteSostoyaniya[counter22] < Struct.finiteSostoyaniya[f])
                        {
                            Struct.tablica[Struct.nefiniteSostoyaniya[counter22], Struct.finiteSostoyaniya[f]] = 1;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //pustie - v pari dlya raboti
            try
            {
                for (int schetchik1 = 0; schetchik1 < granica; schetchik1++) 
                {
                    for (int schetchik2 = 0; schetchik2 < granica; schetchik2++)
                    {
                        if (Struct.tablica[schetchik1, schetchik2] == -1)
                        {
                            Struct.pairs.Add(new DlyaParVTabl(schetchik1, schetchik2));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Struct.poiskSostoyaniy = new DlyaParVTabl[Struct.pairs.Count, Struct.alfavit.Length + 1];
            // perehodi - v poiskSostoyaniy
            for (int schetchik1 = 0; schetchik1 < Struct.pairs.Count; schetchik1++)
            {
                int counter = Struct.pairs[schetchik1].Pervoe;
                int counter2 = Struct.pairs[schetchik1].Vtoroye;
                int Pervoe1 = Struct.sostoyaniye[counter, 0];
                int Vtoroe1 = Struct.sostoyaniye[counter2, 0];
                int Pervoe2 = Struct.sostoyaniye[counter, 1];
                int Vtoroe2 = Struct.sostoyaniye[counter2, 1];
                Struct.poiskSostoyaniy[schetchik1, 0] = new DlyaParVTabl(counter, counter2);
                if (Pervoe1 < Vtoroe1)
                {
                    Struct.poiskSostoyaniy[schetchik1, 1] = new DlyaParVTabl(Pervoe1, Vtoroe1);
                }
                else
                {
                    Struct.poiskSostoyaniy[schetchik1, 1] = new DlyaParVTabl(Vtoroe1, Pervoe1);
                }
                if (Pervoe2 < Vtoroe2)
                {
                    Struct.poiskSostoyaniy[schetchik1, 2] = new DlyaParVTabl(Pervoe2, Vtoroe2);
                }
                else
                {
                    Struct.poiskSostoyaniy[schetchik1, 2] = new DlyaParVTabl(Vtoroe2, Pervoe2);
                }
            }
            int flag = 0;
            // sostoyaniya - v tabl
            while (flag < 8)
            {
                for (int schetchik1 = 0; schetchik1 < Struct.pairs.Count; schetchik1++)
                {
                    int counter = Struct.poiskSostoyaniy[schetchik1, 1].Pervoe;
                    int counter2 = Struct.poiskSostoyaniy[schetchik1, 1].Vtoroye;
                    int counter11 = Struct.poiskSostoyaniy[schetchik1, 2].Pervoe;
                    int counter22 = Struct.poiskSostoyaniy[schetchik1, 2].Vtoroye;
                    int oboznachA = Struct.tablica[counter, counter2];
                    int oboznachB = Struct.tablica[counter11, counter22];

                    if (oboznachA == 1 || oboznachB == 1)
                    {
                        Struct.tablica[Struct.poiskSostoyaniy[schetchik1, 0].Pervoe, Struct.poiskSostoyaniy[schetchik1, 0].Vtoroye] = 1;
                    }
                    if (oboznachA == 0 || oboznachB == 0)
                    {
                        Struct.tablica[Struct.poiskSostoyaniy[schetchik1, 0].Pervoe, Struct.poiskSostoyaniy[schetchik1, 0].Vtoroye] = 2;
                    }
                }
                flag++;
            }
            for (int dop = 0; dop < Struct.tablica.GetLength(0); dop++) // check na pustie dlya dop kruga
            {
                for (int dop2 = 0; dop2 < Struct.tablica.GetLength(1); dop2++)
                {
                    if (Struct.tablica[dop, dop2] == -1)
                    {
                        Struct.tablica[dop, dop2] = 2;
                    }
                }
            }
        }

        public void SozdaniyeMinimizirovannorgo()
        {
            List<List<int>> parnieTochkiVTablice = new List<List<int>>();
            int schetchik1 = 0;
            // po strokam
            try
            {
                while (schetchik1 < Struct.tablica.GetLength(0)) 
                {
                    List<int> spisok = new List<int>();
                    //po stolbcam
                    for (int schetchik2 = 0; schetchik2 < Struct.tablica.GetLength(1); schetchik2++)
                    {
                        try
                        {
                            if (Struct.tablica[schetchik1, schetchik2] == 2)
                            {
                                try
                                {
                                    if (!spisok.Contains(schetchik1))
                                    {
                                        spisok.Add(schetchik1);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                try
                                {
                                    if (!spisok.Contains(schetchik2))
                                    {
                                        spisok.Add(schetchik2);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                for (int counter22 = 0; counter22 < Struct.tablica.GetLength(1); counter22++)
                                {
                                    try
                                    {
                                        if (Struct.tablica[counter22, schetchik2] == 2)
                                        {
                                            try
                                            {
                                                if (!spisok.Contains(counter22))
                                                {
                                                    spisok.Add(counter22);
                                                }
                                            }
                                            catch (Exception ex)
                                            {
                                                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            }
                                            try
                                            {
                                                if (!spisok.Contains(schetchik2))
                                                {
                                                    spisok.Add(schetchik2);
                                                }
                                            }
                                            catch (Exception ex)
                                            {
                                                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    parnieTochkiVTablice.Add(spisok);
                    schetchik1++;
                    //v nego - to chto est
                    List<int> isp = new List<int>();
                    for (int x = 0; x < parnieTochkiVTablice.Count; x++)
                    {
                        for (int y = 0; y < parnieTochkiVTablice[x].Count; y++)
                        {
                            isp.Add(parnieTochkiVTablice[x][y]);
                        }
                    }
                    bool flag = true;
                    while (flag)
                    {
                        if (isp.Contains(schetchik1))
                        {
                            schetchik1++;
                        }
                        else
                        {
                            flag = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            List<int> Shifrovaniye = new List<int>();
            // add shifrovku v konec
            try
            {
                for (int a = 0; a < parnieTochkiVTablice.Count; a++)
                {
                    Shifrovaniye.Add(a);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            parnieTochkiVTablice.Add(Shifrovaniye);
            Struct.finiteForMinOrNot = new bool[parnieTochkiVTablice.Count - 1];
            for (int x = 0; x < parnieTochkiVTablice.Count - 1; x++)
            {
                int e = parnieTochkiVTablice[x][0];
                Struct.finiteForMinOrNot[x] = Struct.finite[e];
            }
            //fin tablichka s perexodami
            Struct.tablicaSMinKol = new int[parnieTochkiVTablice.Count - 1, Struct.alfavit.Length];
            //po listam
            for (int schetDlyaFin = 0; schetDlyaFin < parnieTochkiVTablice.Count - 1; schetDlyaFin++)
            {
                //po ix elementam
                try
                {
                    for (int schetchik2 = 0; schetchik2 < parnieTochkiVTablice[schetDlyaFin].Count; schetchik2++)
                    {
                        int counter22 = parnieTochkiVTablice[schetDlyaFin][schetchik2];
                        int a = Struct.sostoyaniye[counter22, 0];
                        int b = Struct.sostoyaniye[counter22, 1];
                        try
                        {
                            for (int schetDlyaFin2 = 0; schetDlyaFin2 < parnieTochkiVTablice.Count - 1; schetDlyaFin2++)
                            {
                                try
                                {
                                    for (int x = 0; x < parnieTochkiVTablice[schetDlyaFin2].Count; x++)
                                    {
                                        try
                                        {
                                            if (parnieTochkiVTablice[schetDlyaFin2][x] == a)
                                            {
                                                Struct.tablicaSMinKol[schetDlyaFin, 0] = parnieTochkiVTablice[parnieTochkiVTablice.Count - 1][schetDlyaFin2];
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                        try
                                        {
                                            if (parnieTochkiVTablice[schetDlyaFin2][x] == b)
                                            {
                                                Struct.tablicaSMinKol[schetDlyaFin, 1] = parnieTochkiVTablice[parnieTochkiVTablice.Count - 1][schetDlyaFin2];
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void WriteMinInFile()
        {
            try
            {
                using (StreamWriter zapis = new StreamWriter("Minimizirovan.txt", false, System.Text.Encoding.Default))
                {
                    try
                    {
                        for (int schetchik1 = 0; schetchik1 < Struct.tablicaSMinKol.GetLength(0); schetchik1++)
                        {
                            string s = "";
                            try
                            {
                                if (Struct.finiteForMinOrNot[schetchik1])
                                {
                                    s = "y";
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            try
                            {
                                if (!Struct.finiteForMinOrNot[schetchik1])
                                {
                                    s = "n";
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            zapis.WriteLine(Struct.tablicaSMinKol[schetchik1, 0] + " " + Struct.tablicaSMinKol[schetchik1, 1] + " " + s);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void MinimizaciyaAvtomata_Click(object sender, EventArgs e)
        {
            TablicaDlyaMin();
            SozdaniyeMinimizirovannorgo();
            WriteMinInFile();
            groupBox3.Enabled = true;
        }

        private void VvodTextaMin_Click(object sender, EventArgs e)
        {
            str = StringInputMin.Text;
            string alfavit = string.Join(null, Struct.alfavit);
            try
            {
                for (int schetchik1 = 0; schetchik1 < str.Length; schetchik1++)
                {
                    try
                    {
                        if (!alfavit.Contains(str[schetchik1].ToString()))
                        {
                            MessageBox.Show("Nekorrektniy vvod!!", "Vnimaniye!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            NomerSostoyaniyaMin.Text = "0";
            NextSostoyaniyeMin.Enabled = true;
            VvodTextaMin.Enabled = false;
            VsyaStrokaSrazuMin.Enabled = true;
        }

        private void NextSostoyaniyeMin_Click(object sender, EventArgs e)
        {
            try
            {
                if (str.Length == 0)
                {
                    MessageBox.Show("Itogovoye sostoyeniye " + tekuweeSostoyaniye + Environment.NewLine + "Ono ne finishnoye, zrada!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    NextSostoyaniyeMin.Enabled = false;
                    VvodTextaMin.Enabled = true;
                    return;
                }
                try
                {
                    for (int schetchik1 = 0; schetchik1 < Struct.alfavit.Length; schetchik1++)
                    {
                        try
                        {
                            if (str[schetchikDlyaBukv].ToString().Equals(Struct.alfavit[schetchik1]))
                            {
                                tekuweeSostoyaniye = Struct.tablicaSMinKol[tekuweeSostoyaniye, schetchik1];
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            FiniteOrNot = Struct.finiteForMinOrNot[tekuweeSostoyaniye];
            schetchikDlyaBukv++;
            NomerSostoyaniyaMin.Text = tekuweeSostoyaniye.ToString();
            try
            {
                if (FiniteOrNot)
                {
                    NomerSostoyaniyaMin.ForeColor = Color.Green;
                }
                else NomerSostoyaniyaMin.ForeColor = Color.Black;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                if (str.Length == schetchikDlyaBukv)
                {
                    try
                    {
                        if (FiniteOrNot)
                        {
                            MessageBox.Show("Itogovoye sostoyeniye " + tekuweeSostoyaniye + Environment.NewLine + "Ono finishnoye, peremoga!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            tekuweeSostoyaniye = 0;
                            schetchikDlyaBukv = 0;
                            NextSostoyaniyeMin.Enabled = false;
                            VvodTextaMin.Enabled = true;
                            VsyaStrokaSrazuMin.Enabled = false;

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    try
                    {
                        if (!FiniteOrNot)
                        {
                            MessageBox.Show("Itogovoye sostoyeniye " + tekuweeSostoyaniye + Environment.NewLine + "Ono ne finishnoye, zrada!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            tekuweeSostoyaniye = 0;
                            schetchikDlyaBukv = 0;
                            NomerSostoyaniyaMin.ForeColor = Color.Black;
                            NextSostoyaniyeMin.Enabled = false;
                            VvodTextaMin.Enabled = true;
                            VsyaStrokaSrazuMin.Enabled = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void VsyaStrokaSrazuMin_Click(object sender, EventArgs e)
        {
            try
            {
                for (int schetchik2 = 0; schetchik2 < str.Length; schetchik2++)
                {
                    try
                    {
                        if (str.Length == 0)
                        {
                            MessageBox.Show("Itogovoye sostoyeniye " + tekuweeSostoyaniye + Environment.NewLine + "Ono ne finishnoye, zrada!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            NextSostoyaniyeMin.Enabled = false;
                            VvodTextaMin.Enabled = true;
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    try
                    {
                        for (int schetchik1 = 0; schetchik1 < Struct.alfavit.Length; schetchik1++)
                        {
                            try
                            {
                                if (str[schetchikDlyaBukv].ToString().Equals(Struct.alfavit[schetchik1]))
                                {
                                    tekuweeSostoyaniye = Struct.tablicaSMinKol[tekuweeSostoyaniye, schetchik1];
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    FiniteOrNot = Struct.finiteForMinOrNot[tekuweeSostoyaniye];
                    schetchikDlyaBukv++;
                    NomerSostoyaniyaMin.Text = tekuweeSostoyaniye.ToString();
                    try
                    {
                        if (FiniteOrNot)
                        {
                            NomerSostoyaniyaMin.ForeColor = Color.Green;
                        }
                        else NomerSostoyaniyaMin.ForeColor = Color.Black;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    try
                    {
                        if (str.Length == schetchikDlyaBukv)
                        {
                            try
                            {
                                if (FiniteOrNot)
                                {
                                    MessageBox.Show("Itogovoye sostoyeniye " + tekuweeSostoyaniye + Environment.NewLine + "Ono finishnoye, peremoga!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    tekuweeSostoyaniye = 0;
                                    schetchikDlyaBukv = 0;
                                    NextSostoyaniyeMin.Enabled = false;
                                    VvodTextaMin.Enabled = true;
                                    VsyaStrokaSrazuMin.Enabled = false;
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            try
                            {
                                if (!FiniteOrNot)
                                {
                                    MessageBox.Show("Itogovoye sostoyeniye " + tekuweeSostoyaniye + Environment.NewLine + "Ono ne finishnoye, zrada!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    tekuweeSostoyaniye = 0;
                                    schetchikDlyaBukv = 0;
                                    NomerSostoyaniyaMin.ForeColor = Color.Black;
                                    NextSostoyaniyeMin.Enabled = false;
                                    VvodTextaMin.Enabled = true;
                                    VsyaStrokaSrazuMin.Enabled = false;
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
} 