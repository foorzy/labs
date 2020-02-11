using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace АЛГОРИТМЫ_______
{
    public partial class Mainform : Form
    {
        Dictionary<int, string> people = new Dictionary<int, string>();
        int[] keys = new int[0];
        static bool sort=false; 
        public static int ans=-1;

        public Mainform()
        {
            InitializeComponent();
        }

        //
        private void Mainform_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Программа загружает из файла список писателей. Отсортируй их по их рейтингу!");
        }

        //
        private void btnOpen_Click(object sender, EventArgs e)
        {
            if(btnOpen.Text == "Заново")
            {
                Del(keys, people);
            }
            string[] strarr = System.IO.File.ReadAllLines("mur.txt");
            keys = new int[strarr.Length / 2];
            dataGridView1.Rows.Add("Rating of writers");
            for (int i = 0, j = 0; i < strarr.Length; j++)
            {
                keys[j] = Convert.ToInt32(strarr[i]);
                people.Add(keys[j], strarr[i + 1]);
                dataGridView1.Rows.Add(keys[j], people[keys[j]]);
                i += 2;
            }          
            btnOpen.Text="Заново";                    
        }
       
        //
        static void AddToTable(int[] keys, Dictionary<int, string> people, DataGridView d)
        {
            foreach(var p in keys)
            {
                d.Rows.Add(p, people[p]);
            }           
        }

        //
        static void answer(int ans, Dictionary<int, string> people, int[] keys)
        {
            if (ans != -1 && sort ==false )
            {
                MessageBox.Show(people[keys[ans]] +"\nОтсортируй писателей и увидишь картинку" );               
            }
            if(ans==-1) MessageBox.Show("Такого номера нет");
            if (ans != -1 && sort == true)
            {
               Famous_people f = new Famous_people();
                f.Show();
            }
        }

       
        public static void Del(int[] keys, Dictionary<int, string> people)
        {
            for (int i = 0; i < keys.Length; i++)
            {
                people.Remove(keys[i]);
            }
        }
        
        //
        private void buttonSort_Click(object sender, EventArgs e)
        {
            if (radioButtonBuble.Checked)
            {
                sort = Sortclasscs.buble(dataGridView1, keys);
                AddToTable(keys, people, dataGridView1);
            }
            if (radioButtonInsert.Checked)
            {
                sort = Sortclasscs.insertion(dataGridView1, keys);
                AddToTable(keys, people, dataGridView1);
            }
            if (radioButtonChoice.Checked)
            {
                sort = Sortclasscs.direct_choice(dataGridView1, keys);
                AddToTable(keys, people, dataGridView1);
            }
            if (radioButtonShell.Checked)
            {
                sort = Sortclasscs.shell(dataGridView1, keys);
                AddToTable(keys, people, dataGridView1);
            }
            if (radioButtonHoar.Checked)
            {
                if (keys.Length == 0)
                {
                    MessageBox.Show("Сначала открой файл");
                    return;
                }
                dataGridView1.Rows.Add("Сортировка", "Хоара(быстрая)");
                sort = Sortclasscs.quicksort(keys, 0, keys.Length - 1);
                AddToTable(keys, people, dataGridView1);
            }
        }

        //
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            int point;
            if (textBoxNum.Text != "")
            {
                point = Convert.ToInt32(textBoxNum.Text);
                if (radioButtonLinear.Checked)
                {
                    ans = SearchClass.Lenear(keys, point);
                    answer(ans, people, keys);
                }
                if (radioButtonBI.Checked)
                {
                     ans = SearchClass.bisearch(keys, point, sort);
                   if(sort == true) answer(ans, people, keys);
                }
                if (radioButtonQSearch.Checked)
                {
                     ans = SearchClass.sortedsearch(keys, point, sort);
                    if (sort == true)  answer(ans, people, keys);
                }
                if (radioButtonInerpol.Checked)
                {
                     ans = SearchClass.interpolationSearch(keys, point, sort);
                    if (sort == true) answer(ans, people, keys);
                }
                if (radioButtonFast.Checked)
                {
                     ans = SearchClass.fastsearch(keys, point);
                    answer(ans, people, keys);
                }
            }
        }

        //
        public static int answers()
        {
            return ans;
        }
      
    }

}

