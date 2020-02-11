using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;

namespace АЛГОРИТМЫ_______
{
    public partial class Mainform : Form
    {
       
        public static Dictionary<int, string> people = new Dictionary<int, string>();
       
        public static List<int> keys = new List<int>();

        
        static bool sort=false; 

        
        public static int ans=-1;

       
        public static int res_sort;
        public static int res_search;

        
        static Diagram d = new Diagram();

       
        Series[] series= { d.chartSort.Series.Add("Пузырек"), d.chartSort.Series.Add("Вставки"),
            d.chartSort.Series.Add("Выбор"), d.chartSort.Series.Add("Шелла"), d.chartSort.Series.Add("Хоара")
        };

        
        Series[] series2 = { d.chartSeacrh.Series.Add("Линейный"), d.chartSeacrh.Series.Add("Сверхбыстрый"),
            d.chartSeacrh.Series.Add("Последовательный"),d.chartSeacrh.Series.Add("Бинарный"),d.chartSeacrh.Series.Add("Интерполяционный")
        };

        
        static bool flag = true;

        public Mainform()
        {
            InitializeComponent();
        }

        //загрузка формы
        private void Mainform_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Программа загружает из файла список писателей. Отсортируй их по их рейтингу!");
        }

        //открыть файл|заново
        private void btnOpen_Click(object sender, EventArgs e)
        {
            sort = false;
            flag = true;
            if (btnOpen.Text == "Заново")
            {
                Del(keys, people);
            }
            string[] strarr = System.IO.File.ReadAllLines("mur.txt");
            dataGridView1.Rows.Add("Rating of writers");
            for (int i = 0, j = 0; i < strarr.Length; j++)
            {               
                keys.Add(Convert.ToInt32(strarr[i]));             
                people.Add(keys[j], strarr[i + 1]);             
                dataGridView1.Rows.Add(keys[j], people[keys[j]]);
                i += 2;
            }          
            btnOpen.Text="Заново";                    
        }
       
        //добавить в табличку
        static void AddToTable(List<int> keys, Dictionary<int, string> people, DataGridView d)
        {
            foreach(var p in keys)
            {
                d.Rows.Add(p, people[p]);
            }           
        }

        //показать ответ поиска
        static void answer(int ans, Dictionary<int, string> people, List<int> keys)
        {
            if (ans != -1 && sort ==false )
            {
                MessageBox.Show(people[keys[ans]] +"\nОтсортируй писателей и увидишь картинку" );               
            }

            if(ans==-1) MessageBox.Show("Такого номера нет");
            if (ans != -1 && sort == true && flag==true)
            {
               Famous_people f = new Famous_people();
                f.Show();
            }
            if (ans != -1 && sort == true && flag==false)
            {
                MessageBox.Show(people[keys[ans]]);
            }
        }

        //удаление всех элементов
        public static void Del(List<int> keys, Dictionary<int, string> people)
        {          
            int l = keys.Count;
            for (int i=0; i < keys.Count; i++)
            {               
                people.Remove(keys[i]);
                
            }
            for (int i = 0; i < l; i++)
            {             
                keys.Remove(keys[0]);
            }
        }
        
        //кнопка сортировки
        private void buttonSort_Click(object sender, EventArgs e)
        {
            if (radioButtonBuble.Checked)
            {
                sort = Sortclasscs.buble(dataGridView1, keys,ref res_sort);
                AddToTable(keys, people, dataGridView1);
                series[0].Points.Add(res_sort);                             
            }
            if (radioButtonInsert.Checked)
            {
                sort = Sortclasscs.insertion(dataGridView1, keys, ref res_sort);
                AddToTable(keys, people, dataGridView1);        
                series[1].Points.Add(res_sort);
            }
            if (radioButtonChoice.Checked)
            {
                sort = Sortclasscs.direct_choice(dataGridView1, keys,ref res_sort);
                AddToTable(keys, people, dataGridView1);
                series[2].Points.Add(res_sort);
            }
            if (radioButtonShell.Checked)
            {
                sort = Sortclasscs.shell(dataGridView1, keys, ref res_sort);
                AddToTable(keys, people, dataGridView1);
                series[3].Points.Add(res_sort);
            }
            if (radioButtonHoar.Checked)
            {
                if (keys.Count == 0)
                {
                    MessageBox.Show("Сначала открой файл");
                    return;
                }
                dataGridView1.Rows.Add("Сортировка", "Хоара(быстрая)");
                res_sort = 0;
                sort = Sortclasscs.quicksort(keys, 0, keys.Count - 1, ref res_sort);
                AddToTable(keys, people, dataGridView1);
                series[4].Points.Add(res_sort);
            }
        }

        //конпка поиска
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            int point;
            if (textBoxNum.Text != "")
            {
                point = Convert.ToInt32(textBoxNum.Text);
                if (radioButtonLinear.Checked)
                {
                    ans = SearchClass.Lenear(keys, point,ref res_search);
                    answer(ans, people, keys);                  
                    if(res_search!=0)series2[0].Points.Add(res_search);
                }
                if (radioButtonBI.Checked)
                {
                     ans = SearchClass.bisearch(keys, point, sort, ref res_search);
                   if(sort == true) answer(ans, people, keys);
                    if (res_search != 0) series2[3].Points.Add(res_search);
                }
                if (radioButtonQSearch.Checked)
                {
                     ans = SearchClass.sortedsearch(keys, point, sort, ref res_search);
                    if (sort == true)  answer(ans, people, keys);
                    if (res_search != 0) series2[2].Points.Add(res_search);
                }
                if (radioButtonInerpol.Checked)
                {
                     ans = SearchClass.interpolationSearch(keys, point, sort, ref res_search);
                    if (sort == true) answer(ans, people, keys);
                    if (res_search != 0) series2[4].Points.Add(res_search);
                }
                if (radioButtonFast.Checked)
                {
                     ans = SearchClass.fastsearch(keys, point, ref res_search);
                    answer(ans, people, keys);
                    if (res_search != 0) series2[1].Points.Add(res_search);
                }
            }
        }

        //для другой формы
        public static int answers()
        {
            return ans;
        }

        //кнопка удаления элемента из словаря
        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (textBoxDel.Text != "")
            {
                int del = Convert.ToInt32(textBoxDel.Text);
                people.Remove(del);
                keys.Remove(del);
            }
            
        }

        //кнопка добавления элемента в словарь
        private void buttonNewPerson_Click(object sender, EventArgs e)
        {
            MessageBox.Show("После добавления своего автора просмотр других невозможен (без изображения)");
            NewPerson np = new NewPerson();
            np.Show();
            flag = false;
        }

        //кнопка статистики1
        private void buttonDiagr1_Click(object sender, EventArgs e)
        {
            d.Show();
        }

        //кнопка статистики2
        private void btnStat_Click(object sender, EventArgs e)
        {
            d.Show();
        }

       
        //кнопка сохранения
        private void buttonSave_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter(@"result.txt", false);
            if (keys != null)
            {
                foreach (var p in keys)
                {
                    sw.Write((Convert.ToString(p))+ " ");
                    sw.Write(people[p]);
                    sw.WriteLine("");
                }
            }
           
            sw.Close();

        }

        //для проверки цифр
        private void textBoxNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        //для проверки цифр
        private void textBoxDel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }

}

