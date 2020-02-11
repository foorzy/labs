using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;


namespace Boyer_MooreBondarenko
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void TimerPoiska(string pattern, string text, SearchBase search, SearchResults results)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            int pos = search.Search(text, 0);
            while (pos != -1)
            {
                results.Matches++;
                pos = search.Search(text, pos + pattern.Length);
            }
            timer.Stop();
            results.Milliseconds += timer.ElapsedMilliseconds;
        }
        private void OtkritiyeFaila(ref string nameread)
        {
            OpenFileDialog opf = new OpenFileDialog();
            if (opf.ShowDialog() == DialogResult.OK)
            {
                nameread = opf.FileName;
            }
        }
        private string SchitkaFaila(string nameread)
        {
            string str = "";
            try
            {
                StreamReader reader = new StreamReader(nameread, Encoding.Default);
                string xy = "";

                while ((xy = reader.ReadLine()) != null)
                {
                    str += xy;

                }
            }
            catch
            {
                MessageBox.Show("Ошибка считки файла", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return str;
        }
        private void buttonZagruzka_Click(object sender, EventArgs e)
        {
            string namefile = "";

            OtkritiyeFaila(ref namefile);
            txtText.Text = SchitkaFaila(namefile);
        }

        private void buttonOchistit_Click(object sender, EventArgs e)
        {
            txtText.Text = "";
        }
        private void buttonPoisk_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string[] patterns = txtPatterns.Text.Split('*');
                string text = txtText.Text;
                SearchResults BoyerMooreResults = new SearchResults();
                SearchResults BoyerMoore2Results = new SearchResults();
                SearchResults IndexOfResults = new SearchResults();
                for (int i = 0; i < 10; i++)
                {
                    foreach (string pattern in patterns)
                    {
                        TimerPoiska(pattern, text,
                            new BoyerMoore(pattern), BoyerMooreResults);

                        TimerPoiska(pattern, text,
                            new IndexOf(pattern), IndexOfResults);
                    }
                }
                label7.Text = "Sovpadeniy(Vhozhdeniy)" + " = " + BoyerMooreResults.Matches / 10;
                label8.Text = "Potrachennoye vremya" + " = " + BoyerMooreResults.Milliseconds + " (ms)";

                label10.Text = "Sovpadeniy(Vhozhdeniy)" + " = " + IndexOfResults.Matches / 10;
                label9.Text = "Potrachennoye vremya" + " = " + IndexOfResults.Milliseconds + " (ms)";

                MessageBox.Show("Xorowo :)", "Info");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }

    class SearchResults
    {
        public int Matches { get; set; }
        public long Milliseconds { get; set; }
    }
}
