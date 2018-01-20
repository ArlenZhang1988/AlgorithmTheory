using System;
using System.Collections.Generic;
using System.Text;

namespace Sort
{
    class InsertSort : SortBase
    {
        public override void Sort(int[] a)
        {
            Sort(a, 0, a.Length - 1);
        }

        public void Sort(int[] a,int lo,int hi)
        {
            for (int i = lo; i <=hi; i++)
            {
                for (int j = i; j > 0 && Less(a[j], a[j - 1]); j--)
                {
                    Exchange(a, j, j - 1);
                }
            }
        }
    }
}