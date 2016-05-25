using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EPAM_Test
{
    //Можно сортировать через лямбда-выражение, Linq, стандартные сортировки (array.Sort(), list.Sort() и тд).
    class Program
    {
        static void Main(string[] args)
        {
            int n = 10;
            int[] arrayForSort = new int[n];
            Random rand = new Random();
            for (int i = 0; i < n; i++)
            {
                arrayForSort[i] = rand.Next(100);
            }
            Print(arrayForSort);
        }
        static void Print(int[] arrayForSort)
        {
            Console.WriteLine("Неотсортированный массив: "+ String.Join(" ", arrayForSort));
            QuickSort(arrayForSort, 0, arrayForSort.Length - 1);
            Console.WriteLine("Отсортированный массив: "+String.Join(" ", arrayForSort));
        }

        static void QuickSort(int[] arrayForSort,int l, int r)
        {
            int temp;
            int x = arrayForSort[l + (r - l) / 2];
           
            int i = l;
            int j = r;
            while (i <= j)
            {
                while (arrayForSort[i] < x) i++;
                while (arrayForSort[j] > x) j--;
                if (i <= j)
                {
                    temp = arrayForSort[i];
                    arrayForSort[i] = arrayForSort[j];
                    arrayForSort[j] = temp;
                    i++;
                    j--;
                }
            }
            if (i < r)
                QuickSort(arrayForSort, i, r);

            if (l < j)
                QuickSort(arrayForSort, l, j);
        }

    }
}
