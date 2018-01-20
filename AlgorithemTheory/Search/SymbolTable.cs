using System;
using System.Collections.Generic;
using System.Text;

namespace Search
{
    public abstract class SymbolTable<Key,Value>
    {
        public SymbolTable()
        { }

        public abstract void Put(Key k, Value v);
        public abstract Value Get(Key k);
        public abstract void Delete(Key k);
        public abstract bool Contains(Key k);
        public abstract bool IsEmpty();
        public abstract int Size();
        public abstract IEnumerator<Key> Keys();
    }
}
