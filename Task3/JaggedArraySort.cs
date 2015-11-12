using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public static class JaggedArraySort
    {
        


        public static void InterfaceToDelegate(int[][] array, IComparer<int[]> comparator)
        {
            if (array == null)
                throw new ArgumentNullException("Empty array");
            if (comparator == null)
                throw new ArgumentNullException("Comparator is null");
           
           Sort(array, comparator.Compare);
        }



        public static void DelegateToInterface(int[][] array, Comparison<int[]> comparator)
        {
            if (array == null)
                throw new ArgumentNullException("Empty array");
            if (comparator == null)
                throw new ArgumentNullException("Comparator is null");
           
           // Sort(array, Comparer<int[]>.Create(comparator));
            Sort(array, new Adapter<int[]>(comparator));
        }



        private static void Sort(int[][] array, Comparison<int[]> comparator)
        {
            for (int i = array.Length - 1; i >= 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (comparator(array[j], array[j + 1]) == 1)
                    {
                        SwapArray(ref array[j], ref array[j + 1]);
                    }
                }
            }
        }

        private static void Sort(int[][] array, IComparer<int[]> comparer)
        {
            for (int i = array.Length - 1; i >= 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (comparer.Compare(array[j], array[j + 1]) == 1)
                    {
                        SwapArray(ref array[j], ref array[j+1]);
                    }
                }
            }
        }



        private static void SwapArray(ref int[] a, ref int[] b)
        {
            int[] swapArray = a;
            a = b;
            b = swapArray;
        }



    }
}
