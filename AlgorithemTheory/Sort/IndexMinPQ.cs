using System;
using System.Collections.Generic;
using System.Text;

namespace Sort
{
    public class IndexMinPQ<T> where T:IComparable // 不理解
    {
        T[] pq;

        public IndexMinPQ(int maxIndex)
        {
            pq = new T[maxIndex + 1];
        }

        public void Insert(int i, T item)
        {
            pq[i] = item;
        }

        public void Change(int i,T item)
        {
            pq[i] = item;
        }
    }
}
