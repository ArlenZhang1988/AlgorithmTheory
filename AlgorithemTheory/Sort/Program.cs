using System;

namespace Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] a = new int[] { 2,8,9,10,3,4,6,7 };
            int[] a = new int[] { 0,6,4,2,10,1,5,32 };

            //SelectSort ss = new SelectSort();

            //ss.Sort(a);
            //ss.Print(a);

            //InsertSort insertS = new InsertSort();
            //insertS.Sort(a);
            //insertS.Print(a);

            //ShellSort shellSort = new ShellSort();
            //shellSort.Sort(a);
            //shellSort.Print(a);

            //MergeSort ms = new MergeSort();
            ////ms.Sort(a);
            //ms.SortBU(a);
            //ms.Print(a);

            //SpeedSort ss = new SpeedSort();
            ////ss.SortWithInsertSort(a,0,a.Length-1);
            //ss.Sort(a);
            //ss.Print(a);

            Quick3Way qs = new Quick3Way();
            //qs.Sort(a);
            //qs.Print(a);

            PQBaseOnHeap<int> pq = new PQBaseOnHeap<int>(20);
            pq.Sort(a);

            qs.Print(a);
        }
    }
}
