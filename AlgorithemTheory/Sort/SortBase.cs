using System;
using System.Collections.Generic;
using System.Text;

namespace Sort
{
    public abstract class SortBase
    {
        public abstract void Sort(int[] a);

        public bool Less(int i, int j)
        {
            if (i<j)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsSorted(int[] a)
        {
            for (int i = 0; i < a.Length-1; i++)
            {
                if (Less(a[i],a[i-1]))
                {
                    return false;
                }
            }

            return true;
        }

        public void Print(int[] a)
        {
            foreach (var temp in a)
            {
                Console.WriteLine(temp + " ");
            }
        }

        public void Exchange(int[] a,int i,int j)
        {
            int temp = a[i];
            a[i] = a[j];
            a[j] = temp;
        }

    }
}
