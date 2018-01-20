using System;
using System.Collections.Generic;
using System.Text;

namespace Sort
{
    public abstract class MaxPQ<T>
    {
        public abstract void Insert(T v);
        public abstract T Max();
        public abstract T DeleteMax();
        public abstract bool IsEmpty();
        public abstract int Size();
        public abstract bool Less(T[] pq,int i,int j);
        public abstract void Exchange(T[] pq,int i,int j);
    }       
}
