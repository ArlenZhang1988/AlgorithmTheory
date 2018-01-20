using System;
using System.Collections.Generic;
using System.Text;

namespace Sort
{
    class Quick3Way : SortBase
    {
        public override void Sort(int[] a)
        {
            Sort(a, 0, a.Length - 1);
        }

        public void Sort(int[] a,int lo,int hi)
        {
            if (hi<=lo)
            {
                return;
            }

            int lt = lo, i = lo+1, gt = hi, min;

            min = a[lo];

            while (i<=gt)
            {
                int cmp = a[i].CompareTo(min);

                if (cmp<0)
                {
                    Exchange(a, lt++, i++);
                }
                else if(cmp>0)
                {
                    Exchange(a, i, gt--);
                }
                else
                {
                    i++;
                }
            }

            Sort(a, lo, lt - 1);
            Sort(a, gt + 1, hi);
        }
    }
}
