using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace АЛГОРИТМЫ_______
{
    class SearchClass
    {
        //1
        public static int Lenear(int[] a, int key)
        {
            for (int i = 0; i < a.Length; i++) // просматриваем все элементы в цикле
            {
                if (a[i] == key)      // если находим элемент со значением key,
                    return i;     // возвращаем его индекс
            }
            return -1;  // возвращаем -1 - элемент не найден
        }

        //2
        public static int bisearch(int[] a, int key, bool sort)
        {
            if (sort == false)
            {
                MessageBox.Show("Отсортируй массив");
                return -1;
            }
            int left = 0; // задаем левую и правую границы поиска
            int right = a.Length - 1;
            int search = -1; // найденный индекс элемента равен -1 (элемент не найден)
            while (left <= right) // пока левая граница не "перескочит" правую
            {
                int mid = (left + right) / 2; // ищем середину отрезка
                if (key == a[mid])
                {  // если ключевое поле равно искомому
                    search = mid;     // мы нашли требуемый элемент,
                    break;            // выходим из цикла
                }
                if (key < a[mid])     // если искомое ключевое поле меньше найденной середины
                    right = mid - 1;  // смещаем правую границу, продолжим поиск в левой части
                else                  // иначе
                    left = mid + 1;   // смещаем левую границу, продолжим поиск в правой части
            }
            return search;
        }

        //3
        public static int sortedsearch(int[] a, int key, bool sort)
        {
            if (sort == false)
            {
                MessageBox.Show("Отсортируй массив");
                return -1;
            }          
            for (int i=0; i<a.Length;i++)
            {
                if (key <= a[i])
                {
                    if (key == a[i])
                    {
                         return i;
                    }
                    else  return -1;
                }
            }
            return -1;
            
        }

        //4
        public static int interpolationSearch(int[] a, int key, bool sort)
        {
            if (sort == false)
            {
                MessageBox.Show("Отсортируй массив");
                return -1;
            }
            // Возвращает индекс элемента со значением toFind или -1, если такого элемента не существует
            int mid;
            int low = 0;
            int high = a.Length - 1;

            while (a[low] < key && a[high] > key)
            {
                mid = low + ((key - a[low]) * (high - low)) / (a[high] - a[low]);
                if (a[mid] < key)
                    low = mid + 1;
                else if (a[mid] > key)
                    high = mid - 1;
                else
                    return mid;
            }
            if (a[low] == key)
                return low;
            else if (a[high] == key)
                return high;
            else
                return -1; // Not found
        }

        //5
        public static int fastsearch(int[] a, int key)
        {
            for (int i = 0; i < a.Length; i++) 
            {
                for (i = 0; i < a.Length; i++)
                {
                    if (a[i] == key)      
                        return i;     
                }
            }
            return -1; 
        }
    }
}
