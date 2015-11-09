using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class CompareByNegativeSum : IComparer<int[]>
    {
        public int Compare(int[] a, int[] b)
        {
            if (a == null && b == null)
                return 0;
            if (a == null)
                return 1;
            if (b == null)
                return -1;
            int aSum = a.Sum();
            int bSum = b.Sum();
            if (aSum < bSum)
                return 1;
            if (aSum == bSum)
                return 0;
            return -1;
        }
    }
}
