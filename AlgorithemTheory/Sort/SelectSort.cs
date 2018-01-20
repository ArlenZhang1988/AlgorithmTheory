using System;
using System.Collections.Generic;
using System.Text;

namespace Sort
{
    class SelectSort : SortBase
    {
        public override void Sort(int[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                int minID = i;

                for (int j = i+1; j < a.Length-i; j++)
                {
                    if (Less(a[j],a[minID]))
                    {
                        minID = j;
                    }
                }

                Exchange(a, i, minID);
            }
        }
    }
}