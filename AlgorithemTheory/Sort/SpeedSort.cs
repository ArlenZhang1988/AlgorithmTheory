using System;
using System.Collections.Generic;
using System.Text;

namespace Sort
{
    class SpeedSort : SortBase
    {
        int m = 3;

        public override void Sort(int[] a)
        {
            Sort(a,0,a.Length-1);
        }

        public void Sort(int[] a, int lo, int hi)
        {
            if (hi<=lo)
            {
                return;
            }

            int j = Partition(a, lo, hi);
            Sort(a, lo, j - 1);
            Sort(a, j+1, hi);
        }

        public void SortWithInsertSort(int[] a, int lo, int hi)
        {
            if (hi <= lo+m)
            {
                InsertSort IS = new InsertSort();
                IS.Sort(a, lo, hi);
                return;
            }

            int j = Partition(a, lo, hi);
            Sort(a, lo, j - 1);
            Sort(a, j + 1, hi);
        }

        private int Partition(int[] a,int lo,int hi)
        {
            int i, j;

            i = lo;
            j = hi + 1;

            while (true)
            {
                while (Less (a[++i],a[lo]))
                {
                    if (i==hi)
                    {
                        break;
                    }
                }

                while (Less(a[lo],a[--j]))
                {
                    if (j==lo)
                    {
                        break;
                    }
                }

                if (i>=j)
                {
                    break;
                }

                Exchange(a, i, j);
            }

            Exchange(a, lo, j);

            return j;
        }
    }
}
