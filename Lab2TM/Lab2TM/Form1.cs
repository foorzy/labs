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
using System.Runtime.Serialization.Json;

namespace Lab2TM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Domino blocks = null;

        private void OpenFile(ref string nameread)
        {
            OpenFileDialog opf = new OpenFileDialog();
            if (opf.ShowDialog() == DialogResult.OK)
            {
                nameread = opf.FileName;
            }
        }

        private void ReadFile(string path)
        {
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(Domino));
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                blocks = (Domino)jsonFormatter.ReadObject(fs);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();

            try
            {
                string namefile = "";
                OpenFile(ref namefile);
                ReadFile(namefile);

                MessageBox.Show("Считка файла успешна", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Ошибка считки файла!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();

            int result = Obrabotka.Process(blocks);           

            if (result == 1)
            {
                textBox1.Text = "Принято";
                textBox2.Text = Obrabotka.infoif.Indexes.ToString() + "," + Obrabotka.infoif.i.ToString();
                textBox3.Text = Obrabotka.infoif.OutString.ToString();
                textBox4.Text = Obrabotka.infoif.Glubina.ToString();

                MessageBox.Show("Принято", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                textBox1.Text = "Не принято";
                textBox4.Text = Obrabotka.rejectCount.ToString();
                MessageBox.Show("Не принято!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            
        }
    }
}
