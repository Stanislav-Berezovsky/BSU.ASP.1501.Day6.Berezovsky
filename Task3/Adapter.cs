using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class Adapter<T>:IComparer<T>
    {
        Comparison<T> _compare;

        public Adapter(Comparison<T> compare )
        {
            _compare = compare;
        }

        public int Compare(T x, T y)
        {
            return _compare(x, y);
        }
    }
}
