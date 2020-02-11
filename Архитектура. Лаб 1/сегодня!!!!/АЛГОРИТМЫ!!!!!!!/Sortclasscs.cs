using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace АЛГОРИТМЫ_______
{
    class Sortclasscs
    {
        //1
        public static bool buble(DataGridView d, List<int> a, ref int res)
        {
            res = 0;
            if (a.Count == 0)
            {
                MessageBox.Show("Сначала открой файл");
                return false;
            }
            d.Rows.Add("Сортировка", "пузырьком");
            for (int i = 0; i < a.Count; i++)
            {
                
                for (int j = 0; j < a.Count - 1; j++)
                {
                    if (a[j] > a[j + 1])
                    {
                        int temp = a[j];
                        a[j] = a[j + 1];
                        a[j + 1] = temp;
                    }
                    res++;
                }
            }
            return true;
        }

        //2
        public static bool insertion(DataGridView d, List<int> a, ref int res)
        {
            res = 0;
            if (a.Count == 0)
            {
                MessageBox.Show("Сначала открой файл");
                return false;
            }
            d.Rows.Add("Сортировка", "вставками");
            int i, j, value;

            for (i = 1; i < a.Count; i++)
            {
                
                value = a[i];
                for (j = i - 1; j >= 0 && a[j] > value; j--)
                {
                    a[j + 1] = a[j];
                    res++;
                }
                a[j + 1] = value;
                
            }
            return true;
        }


        //3
        public static bool direct_choice(DataGridView d, List<int> a, ref int res)
        {
            res = 0;
            if (a.Count == 0)
            {
                MessageBox.Show("Сначала открой файл");
                return false;
            }
            d.Rows.Add("Сортировка", "выбором");
            int min, tmp;
            for (int i = 0; i < a.Count - 1; i++)
            {

                min = i;
                for (int j = i + 1; j < a.Count; j++)
                {
                    if (a[j] < a[min]) min = j;
                    res++;
                }
                tmp = a[i];
                a[i] = a[min];
                a[min] = tmp;
            }
            return true;
        }

        //4
        public static bool shell(DataGridView d, List<int> a, ref int res)
        {
            res = 0;
            if (a.Count == 0)
            {
                MessageBox.Show("Сначала открой файл");
                return false;
            }
            d.Rows.Add("Сортировка", "Шелла");
            int step = a.Count / 2;
            while (step > 0)
            {
                for (int i = 0; i < (a.Count - step); i++)
                {
                    int j = i;
                    while (j >= 0 && a[j] > a[j + step])
                    {
                        int tmp = a[j];
                        a[j] = a[j + step];
                        a[j + step] = tmp;
                        j--;
                        res++;
                    }
                }
                step = step / 2;
            }
            return true;

        }

        //5
        static int partition(List<int> array, int start, int end,ref int res)
        {
            int temp;//swap helper
            int marker = start;//divides left and right subarrays
            for (int i = start; i < end; i++)
            {
                if (array[i] < array[end]) //array[end] is pivot
                {
                    temp = array[marker]; // swap
                    array[marker] = array[i];
                    array[i] = temp;
                    marker += 1;
                }
                res++;
            }
            //put pivot(array[end]) between left and right subarrays
            temp = array[marker];
            array[marker] = array[end];
            array[end] = temp;
            return marker;
        }
        public static bool quicksort(List<int> array, int start, int end, ref int res)
        {
           
            if (start >= end)
            {   // нужно чтоб рекурсия не была бесконечной,, пивот помогает!
                return true;
            }
            int pivot = partition(array, start, end,ref res);
            quicksort(array, start, pivot - 1,ref res);
            quicksort(array, pivot + 1, end,ref res);
            return true;
        }
    }
}
