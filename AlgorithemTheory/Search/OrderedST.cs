using System;
using System.Collections.Generic;
using System.Text;

namespace Search
{
    public abstract class OrderedST<Key,Value> : SymbolTable<Key,Value> where Key : IComparable
    {
        public abstract Key Min();
        public abstract Key Max();
        public abstract Key Floor(Key k);
        public abstract Key Ceiling(Key k);
        public abstract int Rank(Key k);
        public abstract Key Select(int k);
        public abstract void DeleteMin();
        public abstract void DeleteMax();
        public abstract int Size(Key lo, Key hi);
        public abstract IEnumerator<Key> Keys(Key lo, Key hi);
    }
}
