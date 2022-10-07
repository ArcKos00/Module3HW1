using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class MyComparer<T> : IComparer<T>
        where T : IComparable<T>
    {
        public int Compare(T? x, T? y)
        {
            if (x != null && y != null)
            {
                return x.CompareTo(y);
            }
            else
            {
                return -1;
            }
        }
    }
}
