using System;
using System.Collections.Generic;
using System.Text;

namespace Sort
{
    class MergeSort : SortBase
    {
        public override void Sort(int[] a)
        {
            Sort(a, 0, a.Length-1);

            //Merge(a, 0, a.Length/2, a.Length-1);
        }

        void Sort(int[] a,int lo, int hi)
        {
            if (hi<=lo)
            {
                return;
            }

            int mid = lo + (hi - lo) / 2;

            Sort(a,lo,mid);
            Sort(a, mid+1, hi);
            Merge(a, lo, mid, hi);
        }

        //wrong
        public void SortBU(int[] a)
        {
            for (int i = 0; i < a.Length; i=2*i)
            {
                for (int j = 0; j < a.Length-i; j += 2*i)
                {
                    Merge(a, j, j + i - 1, Math.Min(j + 2 * i - 1, a.Length - 1));
                }
            }
        }
        //原地归并
        void Merge(int[] a,int lo,int mid,int hi)
        {
            int i = lo, j = mid+1;

            int[] aux = new int[a.Length];

            for (int k = lo; k <= hi; k++)
            {
                aux[k] = a[k];
            }

            for (int k = lo; k <= hi; k++)
            {
                if (i>mid)
                {
                    a[k] = aux[j++];
                }
                else if (j>hi)
                {
                    a[k] = aux[i++];
                }
                else if(Less(aux[j],aux[i]))
                {
                    a[k] = aux[j++];
                }
                else
                {
                    a[k] = aux[i++];
                }
            }
        }
    }
}
