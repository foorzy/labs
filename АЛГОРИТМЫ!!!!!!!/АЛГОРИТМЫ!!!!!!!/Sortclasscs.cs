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
        public static bool buble(DataGridView d, int[] a)
        {
            if (a.Length == 0)
            {
                MessageBox.Show("Сначала открой файл");
                return false;
            }
            d.Rows.Add("Сортировка", "пузырьком");
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < a.Length - 1; j++)
                {
                    if (a[j] > a[j + 1])
                    {
                        int temp = a[j];
                        a[j] = a[j + 1];
                        a[j + 1] = temp;
                    }
                }
            }
            return true;
        }

        //2
        public static bool insertion(DataGridView d, int[] a)
        {
            if (a.Length == 0)
            {
                MessageBox.Show("Сначала открой файл");
                return false;
            }
            d.Rows.Add("Сортировка", "вставками");
            int i, j, value;

            for (i = 1; i < a.Length; i++)
            {
                value = a[i];
                for (j = i - 1; j >= 0 && a[j] > value; j--)
                {
                    a[j + 1] = a[j];
                }
                a[j + 1] = value;
            }
            return true;
        }


        //3
        public static bool direct_choice(DataGridView d, int[] a)
        {
            if (a.Length == 0)
            {
                MessageBox.Show("Сначала открой файл");
                return false;
            }
            d.Rows.Add("Сортировка", "выбором");
            int min, tmp;
            for (int i = 0; i < a.Length - 1; i++)
            {

                min = i;
                for (int j = i + 1; j < a.Length; j++)
                {
                    if (a[j] < a[min]) min = j;

                }
                tmp = a[i];
                a[i] = a[min];
                a[min] = tmp;
            }
            return true;
        }

        //4
        public static bool shell(DataGridView d, int[] a)
        {
            if (a.Length == 0)
            {
                MessageBox.Show("Сначала открой файл");
                return false;
            }
            d.Rows.Add("Сортировка", "Шелла");
            int step = a.Length / 2;
            while (step > 0)
            {
                for (int i = 0; i < (a.Length - step); i++)
                {
                    int j = i;
                    while (j >= 0 && a[j] > a[j + step])
                    {
                        int tmp = a[j];
                        a[j] = a[j + step];
                        a[j + step] = tmp;
                        j--;

                    }
                }
                step = step / 2;
            }
            return true;

        }

        //5
        static int partition(int[] array, int start, int end)
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
            }
            //put pivot(array[end]) between left and right subarrays
            temp = array[marker];
            array[marker] = array[end];
            array[end] = temp;
            return marker;
        }
        public static bool quicksort(int[] array, int start, int end)
        { 
            if (start >= end)
            {   // нужно чтоб рекурсия не была бесконечной,, пивот помогает!
                return true;
            }
            int pivot = partition(array, start, end);
            quicksort(array, start, pivot - 1);
            quicksort(array, pivot + 1, end);
            return true;
        }
    }
}
