using System;
using System.Collections.Generic;
using System.Text;

namespace Search
{
    class BinarySearchST<Key, Value> : OrderedST<Key,Value> where Key : IComparable where Value : IComparable
    {
        private Key[] _keys;
        private Value[] _values;

        int _capacity;

        public BinarySearchST(int capacity)
        {
            _capacity = capacity;

            _keys = new Key[capacity];
            _values = new Value[capacity];
        }

        public override bool Contains(Key k)
        {
            throw new NotImplementedException();
        }

        public override void Delete(Key k)
        {
            throw new NotImplementedException();
        }

        public override Value Get(Key k)
        {
            if (IsEmpty())
            {
                return default(Value);
            }

            int i = Rank(k);

            if (i<_capacity&& _keys[i].CompareTo(k) == 0)
            {
                return _values[i];
            }
            else
            {
                return default(Value);
            }
        }

        public override bool IsEmpty()
        {
            throw new NotImplementedException();
        }

        public override IEnumerator<Key> Keys()
        {
            throw new NotImplementedException();
        }

        public override void Put(Key k, Value v)
        {
            int i = Rank(k);

            if (i<_capacity && _keys[i].CompareTo(k) == 0)
            {
                _values[i] = v;
                return;
            }

            for (int j = _capacity; j < i; j--)
            {
                _keys[j] = _keys[j - 1];
                _values[j] = _values[j - 1];
             }

            _keys[i] = k;
            _values[i] = v;
            _capacity++;
        }

        public override int Size()
        {
            return _capacity;
        }

        public override Key Min()
        {
            return _keys[0];
        }

        public override Key Max()
        {
            return _keys[_capacity - 1];
        }

        public override Key Floor(Key k)
        {
            throw new NotImplementedException();
        }

        public override Key Ceiling(Key k)
        {
            int i = Rank(k);
            return _keys[i];
        }

        public override Key Select(int k)
        {
            return _keys[k];
        }

        public override void DeleteMin()
        {
            throw new NotImplementedException();
        }

        public override void DeleteMax()
        {
            throw new NotImplementedException();
        }

        public override int Size(Key lo, Key hi)
        {
            throw new NotImplementedException();
        }

        public override IEnumerator<Key> Keys(Key lo, Key hi)
        {
            Queue<Key> q = new Queue<Key>();

            for (int i = Rank(lo); i < Rank(hi); i++)
            {
                q.Enqueue(_keys[i]);
            }

            if (Contains(hi))
            {
                q.Enqueue(_keys[Rank(hi)]);
            }

            return q.GetEnumerator();
        }

        public override int Rank(Key k)
        {
            throw new NotImplementedException();
        }
    }
}
