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

namespace LineyniySpisok
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        List<Tablica> tabl1 = new List<Tablica>();
        List<Tablica> tabl2 = new List<Tablica>();

        List<Tablica> copy = new List<Tablica>();

        List<Tablica> vsp1 = new List<Tablica>();
        List<Tablica> vsp2 = new List<Tablica>();



        private void OpenFile(ref string nameread)
        {
            OpenFileDialog opf = new OpenFileDialog();
            if (opf.ShowDialog() == DialogResult.OK)
            {
                nameread = opf.FileName;
            }
        }

        private void ReadFile(string nameread, List<Tablica> t)
        {
            StreamReader reader = File.OpenText(nameread);
            string xy = "";

            try
            {
                while ((xy = reader.ReadLine()) != null)
                {
                    string[] split = xy.Split(' ');
                    t.Add(new Tablica(Convert.ToInt32(split[0]), split[1]));
                }
            }
            catch
            {
                MessageBox.Show("Запись файла не верна!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowGivenList1(List<Tablica> t)
        {
            for (int i = 0; i < t.Count; i++)
            {
                richTextBox1.Text += i + Environment.NewLine;
                richTextBox3.Text += t[i].Key + Environment.NewLine;
                richTextBox6.Text += t[i].Value + Environment.NewLine;
            }
        }

        private void ShowGivenList2(List<Tablica> t)
        {
            for (int i = 0; i < t.Count; i++)
            {
                richTextBox2.Text += i + Environment.NewLine;
                richTextBox4.Text += t[i].Key + Environment.NewLine;
                richTextBox5.Text += t[i].Value + Environment.NewLine;
            }
        }

        private void ShowCutList(List<Tablica> vsp1, List<Tablica> vsp2)
        {
            for (int i = 0; i < vsp1.Count; i++)
            {
                richTextBox7.Text += i + Environment.NewLine;
                richTextBox8.Text += vsp1[i].Key + Environment.NewLine;
                richTextBox9.Text += vsp1[i].Value + Environment.NewLine;
            }

            for (int i = 0; i < vsp2.Count; i++)
            {
                richTextBox10.Text += i + Environment.NewLine;
                richTextBox11.Text += vsp2[i].Key + Environment.NewLine;
                richTextBox12.Text += vsp2[i].Value + Environment.NewLine;
            }
        }

        private void AddToList(List<Tablica> t, int k, string v, int position)
        {
            foreach (Tablica q in t)
            {
                if (q.Key == k)
                {
                    MessageBox.Show("Такой ключ уже существует!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (position > t.Count - 1)
            {
                t.Add(new Tablica(k, v));
            }
            else
            {
                t.Insert(position, new Tablica(k, v));
            }
        }

        private void InfoUzel(List<Tablica> t, int uzel)
        {
            if (uzel < t.Count)
            {
                MessageBox.Show("Узел номер - " + uzel + Environment.NewLine + Environment.NewLine + "Ключ - " + t[uzel].Key + Environment.NewLine + Environment.NewLine + "Значение - " + t[uzel].Value, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Узла с таким номером не существует!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void IzmenaInfo(List<Tablica> t, int uzel, int key, string value)
        {
            t[uzel].Key = key;
            t[uzel].Value = value;
        }

        private void RemoveUzel(List<Tablica> t, int uzel)
        {
            if (uzel >= t.Count)
            {
                MessageBox.Show("Узла с таким номером не существует!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                t.RemoveAt(uzel);
            }
        }

        private void Together(List<Tablica> t1, List<Tablica> t2)
        {
            foreach (Tablica i in t2)
            {
                t1.Add(i);
            }
        }

        private int CountOfNodes(List<Tablica> t)
        {
            int count = 0;
            foreach (Tablica i in t)
            {
                count++;
            }
            return count;
        }

        private void CutList(List<Tablica> t)
        {
            int k = t.Count / 2;

            for (int i = 0; i < k; i++)
            {
                vsp1.Add(new Tablica(t[i].Key, t[i].Value));
            }

            for (int i = k; i < t.Count; i++)
            {
                vsp2.Add(new Tablica(t[i].Key, t[i].Value));
            }
        }

        private void CopyList(List<Tablica> t)
        {
            foreach (Tablica i in t)
            {
                copy.Add(i);
            }
        }

        private void SortBubble(List<Tablica> t)
        {
            for (int j = 0; j < t.Count; j++)
            {
                for (int i = 0; i < t.Count - 1; i++)
                {
                    if (t[i].Key > t[i + 1].Key)
                    {
                        int tmp = t[i].Key;
                        string d = t[i].Value;
                        t[i].Value = t[i + 1].Value;
                        t[i].Key = t[i + 1].Key;
                        t[i + 1].Value = d;
                        t[i + 1].Key = tmp;
                    }
                }
            }
        }

        private int FindNode(List<Tablica> t, int key)
        {
            int i = 0;
            foreach (Tablica q in t)
            {
                if (t[i].Key == key)
                {
                    return i;
                }
                i++;
            }
            return -1;
        }


        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string namefile = "";
                OpenFile(ref namefile);
                ReadFile(namefile, tabl1);
                ShowGivenList1(tabl1);
            }
            catch
            {
                MessageBox.Show("Ошибка считки файла!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void загрузитьВоВторойСписокToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string namefile = "";
                OpenFile(ref namefile);
                ReadFile(namefile, tabl2);
                ShowGivenList2(tabl2);
            }
            catch
            {
                MessageBox.Show("Ошибка считки файла!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int key = Convert.ToInt32(textBox10.Text);
                string value = textBox12.Text;
                int position = Convert.ToInt32(textBox2.Text);
                int number = Convert.ToInt32(textBox4.Text);

                if (number == 1)
                {
                    AddToList(tabl1, key, value, position);

                    richTextBox1.Clear();
                    richTextBox3.Clear();
                    richTextBox6.Clear();

                    ShowGivenList1(tabl1);
                }

                if (number == 2)
                {
                    AddToList(tabl2, key, value, position);

                    richTextBox2.Clear();
                    richTextBox4.Clear();
                    richTextBox5.Clear();

                    ShowGivenList2(tabl2);
                }

                if (number != 1 && number != 2)
                {
                    MessageBox.Show("Списка с таким номером не существует!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("Невозможно совершить действие!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int number = Convert.ToInt32(textBox6.Text);
                int uzel = Convert.ToInt32(textBox8.Text);
                if (number == 1)
                {
                    InfoUzel(tabl1, uzel);
                }

                if (number == 2)
                {
                    InfoUzel(tabl2, uzel);
                }

                if (number != 1 && number != 2)
                {
                    MessageBox.Show("Списка с таким номером не существует!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("Невозможно совершить действие!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int number = Convert.ToInt32(textBox14.Text);
                int uzel = Convert.ToInt32(textBox16.Text);
                int key = Convert.ToInt32(textBox19.Text);
                string value = textBox20.Text;

                if (number == 1)
                {
                    IzmenaInfo(tabl1, uzel, key, value);

                    richTextBox1.Clear();
                    richTextBox3.Clear();
                    richTextBox6.Clear();

                    ShowGivenList1(tabl1);

                    MessageBox.Show("Измена информации в узле успешна!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                if (number == 2)
                {
                    IzmenaInfo(tabl2, uzel, key, value);

                    richTextBox2.Clear();
                    richTextBox4.Clear();
                    richTextBox5.Clear();

                    ShowGivenList2(tabl2);

                    MessageBox.Show("Измена информации в узле успешна!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                if (number != 1 && number != 2)
                {
                    MessageBox.Show("Списка с таким номером не существует!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("Невозможно совершить действие!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                int number = Convert.ToInt32(textBox22.Text);
                int uzel = Convert.ToInt32(textBox24.Text);

                if (number == 1)
                {
                    RemoveUzel(tabl1, uzel);

                    richTextBox1.Clear();
                    richTextBox3.Clear();
                    richTextBox6.Clear();

                    ShowGivenList1(tabl1);
                }

                if (number == 2)
                {
                    RemoveUzel(tabl2, uzel);

                    richTextBox2.Clear();
                    richTextBox4.Clear();
                    richTextBox5.Clear();

                    ShowGivenList2(tabl2);
                }

                if (number != 1 && number != 2)
                {
                    MessageBox.Show("Списка с таким номером не существует!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("Невозможно совершить действие!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                Together(tabl1, tabl2);
                tabl2.Clear();

                richTextBox1.Clear();
                richTextBox3.Clear();
                richTextBox6.Clear();

                richTextBox2.Clear();
                richTextBox4.Clear();
                richTextBox5.Clear();

                ShowGivenList1(tabl1);
            }
            catch
            {
                MessageBox.Show("Невозможно совершить действие!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                int number = Convert.ToInt32(textBox26.Text);
                int count;

                if (number == 1)
                {
                    count = CountOfNodes(tabl1);
                    MessageBox.Show("Список номер - " + number + Environment.NewLine + Environment.NewLine + "Колличество узлов в списке - " + count, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                if (number == 2)
                {
                    count = CountOfNodes(tabl2);
                    MessageBox.Show("Список номер - " + number + Environment.NewLine + Environment.NewLine + "Колличество узлов в списке - " + count, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                if (number != 1 && number != 2)
                {
                    MessageBox.Show("Списка с таким номером не существует!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("Невозможно совершить действие!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                int number = Convert.ToInt32(textBox28.Text);

                if (number == 1)
                {
                    CutList(tabl1);

                    tabl1.Clear();

                    richTextBox1.Clear();
                    richTextBox3.Clear();
                    richTextBox6.Clear();

                    ShowGivenList1(tabl1);

                    ShowCutList(vsp1, vsp2);
                }

                if (number == 2)
                {
                    CutList(tabl2);

                    tabl2.Clear();

                    richTextBox2.Clear();
                    richTextBox4.Clear();
                    richTextBox5.Clear();

                    ShowGivenList2(tabl2);

                    ShowCutList(vsp1, vsp2);
                }

                if (number != 1 && number != 2)
                {
                    MessageBox.Show("Списка с таким номером не существует!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("Невозможно совершить действие!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                vsp1.Clear();
                vsp2.Clear();
                richTextBox7.Clear();
                richTextBox8.Clear();
                richTextBox9.Clear();
                richTextBox10.Clear();
                richTextBox11.Clear();
                richTextBox12.Clear();
            }
            catch
            {
                MessageBox.Show("Невозможно совершить действие!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                copy.Clear();
                int number = Convert.ToInt32(textBox30.Text);
                if (number == 1)
                {
                    CopyList(tabl1);
                    MessageBox.Show("Копия была успешно сделана!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                if (number == 2)
                {
                    CopyList(tabl2);
                    MessageBox.Show("Копия была успешно сделана!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                if (number != 1 && number != 2)
                {
                    MessageBox.Show("Списка с таким номером не существует!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("Невозможно совершить действие!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void загрузитьКопиюВоВторойСписокToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Tablica i in copy)
                {
                    tabl2.Add(i);
                }

                richTextBox2.Clear();
                richTextBox4.Clear();
                richTextBox5.Clear();

                ShowGivenList2(tabl2);
            }
            catch
            {
                MessageBox.Show("Невозможно совершить действие!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void загрузитьКопиюВПервыйСписокToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Tablica i in copy)
                {
                    tabl1.Add(i);
                }

                richTextBox1.Clear();
                richTextBox3.Clear();
                richTextBox6.Clear();

                ShowGivenList1(tabl1);
            }
            catch
            {
                MessageBox.Show("Невозможно совершить действие!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                int number = Convert.ToInt32(textBox32.Text);
                if (number == 1)
                {
                    SortBubble(tabl1);

                    richTextBox1.Clear();
                    richTextBox3.Clear();
                    richTextBox6.Clear();

                    ShowGivenList1(tabl1);
                }

                if (number == 2)
                {
                    SortBubble(tabl2);

                    richTextBox2.Clear();
                    richTextBox4.Clear();
                    richTextBox5.Clear();

                    ShowGivenList2(tabl2);
                }

                if (number != 1 && number != 2)
                {
                    MessageBox.Show("Списка с таким номером не существует!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("Невозможно совершить действие!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox33_TextChanged(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                int number = Convert.ToInt32(textBox34.Text);
                int key = Convert.ToInt32(textBox36.Text);
                int c;

                if (number == 1)
                {
                    c = FindNode(tabl1, key);
                    if (c == -1)
                    {
                        MessageBox.Show("Такого ключа не существует в данном списке!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Список номер - " + number + Environment.NewLine + Environment.NewLine + "Узел номер - " + c, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                if (number == 2)
                {
                    c = FindNode(tabl2, key);
                    if (c == -1)
                    {
                        MessageBox.Show("Такого ключа не существует в данном списке!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Список номер - " + number + Environment.NewLine + Environment.NewLine + "Узел номер - " + c, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Невозможно совершить действие!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void первыйСписокToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabl1.Clear();
            richTextBox1.Clear();
            richTextBox3.Clear();
            richTextBox6.Clear();
        }

        private void второйСписокToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabl2.Clear();
            richTextBox2.Clear();
            richTextBox4.Clear();
            richTextBox5.Clear();
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox28_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox26_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox32_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox22_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox24_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox34_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox36_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox14_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox16_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox19_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox30_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
