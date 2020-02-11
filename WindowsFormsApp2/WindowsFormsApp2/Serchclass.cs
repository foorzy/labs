using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApp2
{
    class Serchclass
    {
        public static Student Liniersearch(List<Student> list,int key,ref int compare)
        {
            for(int i=0;i<list.Count;i++)
            {
                compare++;
                if (list[i].Number == key)
                    return list[i];
            }
            return null;
        }

        public static Student Liniersearch(List<Student> list, int key)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Number == key)
                    return list[i];
            }
            return null;
        }

        public static Student BinarySearch(Student[] a, int x,ref int compare)
        {
            // Проверить, имеет ли смыл вообще выполнять поиск:
            // - если длина массива равна нулю - искать нечего;
            // - если искомый элемент меньше первого элемента массива, значит, его в массиве нет;
            // - если искомый элемент больше последнего элемента массива, значит, его в массиве нет.
            compare += 3;
            if ((a.Length == 0) || (x < a[0].Number) || (x > a[a.Length - 1].Number))
                return null;

            // Приступить к поиску.
            // Номер первого элемента в массиве.
            int first = 0;
            // Номер элемента массива, СЛЕДУЮЩЕГО за последним
            int last = a.Length;

            // Если просматриваемый участок не пуст, first < last
            while (first < last)
            {
                int mid = first + (last - first) / 2;
                compare++;
                if (x <= a[mid].Number)
                    last = mid;
                else
                    first = mid + 1;
            }

            // Теперь last может указывать на искомый элемент массива.
            compare++;
            if (a[last].Number == x)
                return a[last];
            else
                return null;
        }

        public static Student Interpolserch(Student[] a,int key,ref int compare)
        {
            int low = 0;
            int high = a.Length - 1;
            while (low <= high)
            {
                int mid = (low + high) / 2;
                if (key < a[mid].Number)
                {
                    high = mid - 1;
                    compare++;
                }
                else if (key > a[mid].Number)
                {
                    low = mid + 1;
                    compare++;
                }
                else if (key == a[mid].Number)
                {
                    compare++;
                    return a[mid];
                }
            }
            return null;
        }

        public static int min(int x, int y)
        {
            return (x <= y) ? x : y;
        }

        public static Student fibMonaccianSearch(Student[] arr ,int x, int n, ref int compare)
        {
            /* Initialize fibonacci numbers */
            int fibMMm2 = 0; // (m-2)'th Fibonacci No.
            int fibMMm1 = 1; // (m-1)'th Fibonacci No.
            int fibM = fibMMm2 + fibMMm1; // m'th Fibonacci

            /* fibM is going to store the smallest 
            Fibonacci Number greater than or equal to n */
            while (fibM < n)
            {
                fibMMm2 = fibMMm1;
                fibMMm1 = fibM;
                fibM = fibMMm2 + fibMMm1;
            }

            // Marks the eliminated range from front
            int offset = -1;

            /* while there are elements to be inspected. 
            Note that we compare arr[fibMm2] with x. 
            When fibM becomes 1, fibMm2 becomes 0 */
            while (fibM > 1)
            {
                // Check if fibMm2 is a valid location
                int i = min(offset + fibMMm2, n - 1);

                /* If x is greater than the value at 
                index fibMm2, cut the subarray array 
                from offset to i */
                if (arr[i].Number < x)
                {
                    fibM = fibMMm1;
                    fibMMm1 = fibMMm2;
                    fibMMm2 = fibM - fibMMm1;
                    offset = i;
                    compare++;

                }

                /* If x is greater than the value at index 
                fibMm2, cut the subarray after i+1 */
                else if (arr[i].Number > x)
                {
                    fibM = fibMMm2;
                    fibMMm1 = fibMMm1 - fibMMm2;
                    fibMMm2 = fibM - fibMMm1;
                    compare++;

                }

                /* element found. return index */
                else return arr[i];
            }

            /* comparing the last element with x */
            if (fibMMm1 == 1 && arr[offset + 1].Number == x)
                return arr[offset + 1];

            /*element not found. return -1 */
            return null;
        }

        public static Student exponentialSearch(Student[] arr,
                         int n, int x, ref int compare)
        {

            // If x is present at 
            // first location itself
            if (arr[0].Number == x)
                return arr[0];
            compare++;

            // Find range for binary search 
            // by repeated doubling
            int i = 1;
            while (i < n && arr[i].Number <= x)
                i = i * 2;

            // Call binary search for
            // the found range.
            return binarySearch(arr, i / 2,
                               Math.Min(i, n), x, ref compare);
        }

        static Student binarySearch(Student[] arr, int l,
                        int r, int x, ref int compare)
        {
            if (r >= l)
            {
                int mid = l + (r - l) / 2;

                // If the element is present
                // at the middle itself
                if (arr[mid].Number == x)
                {
                    compare++;
                    return arr[mid];

                }
                // If element is smaller than
                // mid, then it can only be 
                // present n left subarray
                if (arr[mid].Number > x)
                {
                    compare++;
                    return binarySearch(arr, l, mid - 1, x, ref compare);
                }

                // Else the element can only 
                // be present in right subarray
                return binarySearch(arr, mid + 1, r, x,ref compare);
            }

            // We reach here when element
            // is not present in array
            return null;
        }
    }
}
