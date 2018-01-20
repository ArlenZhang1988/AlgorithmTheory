using System;
using System.Collections.Generic;
using System.Text;

namespace Search
{
    class BinarySearchTree<Key, Value> where Key : IComparable where Value : IComparable
    {
        public class Node
        {
            private Node _left, _right;
            private int _number;
            private Key _k;
            private Value _v;

            public Node Left { get { return _left; } set { _left = value; } }
            public Node Right { get { return _right; } set { _right = value; } }
            public int Number { get { return _number; } set { _number = value; } }
            public Key Key { get { return _k; } set { _k = value; } }
            public Value Value { get { return _v; } set { _v = value; } }

            public Node(Key k, Value v, int number)
            {
                _k = k;
                _v = v;
                _number = number;
            }
        }

        private Node _root;

        public int Size()
        {
            return Size(_root);
        }

        private int Size(Node x)
        {
            if (x == null)
            {
                return 0;
            }
            else
            {
                return x.Number;
            }
        }

        public Value Get(Key k)
        {
            return Get(_root, k);
        }

        private Value Get(Node x, Key k)
        {
            if (x == null)
            {
                return default(Value);
            }

            int cmp = k.CompareTo(x.Key);

            if (cmp < 0)
            {
                return Get(x.Left, k);
            }
            else if (cmp > 0)
            {
                return Get(x.Right, k);
            }
            else
            {
                return x.Value;
            }
        }

        public void Put(Key k, Value v)
        {
            _root = Put(_root, k, v);
        }

        private Node Put(Node x, Key k, Value v)
        {
            if (x == null)
            {
                return new Node(k, v, 1);
            }

            int cmp = k.CompareTo(x.Key);

            if (cmp < 0)
            {
                x.Left = Put(x.Left, k, v);
            }
            else if (cmp > 0)
            {
                x.Right = Put(x.Right, k, v);
            }
            else
            {
                x.Value = v;
            }

            x.Number = Size(x.Left) + Size(x.Right) + 1;
            return x;
        }

        public Key Min()
        {
            return Min(_root).Key;
        }

        private Node Min(Node x)
        {
            if (x.Left == null)
            {
                return x;
            }
            else
            {
                return x.Left;
            }
        }

        public Key Max()
        {
            return Max(_root).Key;
        }

        private Node Max(Node x)
        {
            if (x.Right == null)
            {
                return x;
            }
            else
            {
                return x.Right;
            }
        }

        public Key Floor(Key k)
        {
            Node x = Floor(_root, k);

            if (x == null)
            {
                return default(Key);
            }

            return x.Key;
        }

        private Node Floor(Node x, Key k)
        {
            if (x == null)
            {
                return null;
            }

            int cmp = k.CompareTo(x.Key);

            if (cmp == 0)
            {
                return x;
            }
            else if (cmp < 0)
            {
                return Floor(x.Left, k);
            }

            Node t = Floor(x.Right, k);

            if (t != null)
            {
                return t;
            }
            else return x;
        }

        public Key Ceiling(Key k)
        {
            Node x = Ceiling(_root, k);

            if (x == null)
            {
                return default(Key);
            }

            return x.Key;
        }

        private Node Ceiling(Node x, Key k)
        {
            if (x == null)
            {
                return null;
            }

            int cmp = k.CompareTo(x.Key);

            if (cmp == 0)
            {
                return x;
            }
            else if (cmp > 0)
            {
                return Ceiling(x.Right, k);
            }

            Node t = Ceiling(x.Left, k);

            if (t != null)
            {
                return t;
            }
            else return x;
        }

        public Key Select(int k)
        {
            return Select(_root, k).Key;
        }

        private Node Select(Node x, int k)
        {
            if (x == null)
            {
                return null;
            }

            int t = Size(x.Left);
            if (t > k)
            {
                return Select(x.Left, k);
            }
            else if (t < k)
            {
                return Select(x.Right, k - t - 1);
            }
            else
            {
                return x;
            }
        }

        public int Rank(Key k)
        {
            return Rank(_root, k);
        }

        private int Rank(Node x, Key k)
        {
            if (x == null)
            {
                return 0;
            }

            int cmp = k.CompareTo(x.Key);

            if (cmp < 0)
            {
                return Rank(x.Left, k);
            }
            else if (cmp > 0)
            {
                return 1 + Size(x.Left) + Rank(x.Right, k);
            }
            else
            {
                return Size(x.Left);
            }
        }

        public void DeleteMin()
        {
            _root = DeleteMin(_root);
        }

        private Node DeleteMin(Node x)
        {
            if (x.Left == null)
            {
                return x.Right;
            }
            x.Left = DeleteMin(x.Left);
            x.Number = Size(x.Left) + Size(x.Right) + 1;
            return x;
        }

        public void Delete(Key k)
        {
            _root = Delete(_root, k);
        }

        private Node Delete(Node x, Key k)
        {
            if (x == null)
            {
                return null;
            }

            int cmp = k.CompareTo(x.Key);

            if (cmp < 0)
            {
                x.Left = Delete(x.Left, k);
            }
            else if (cmp > 0)
            {
                x.Right = Delete(x.Right, k);
            }
            else
            {
                if (x.Right == null)
                {
                    return x.Left;
                }

                if (x.Left == null)
                {
                    return x.Right;
                }

                Node t = x;
                x = Min(t.Right);
                x.Right = DeleteMin(t.Right);
                x.Left = t.Left;
            }

            x.Number = Size(x.Left) + Size(x.Right) + 1;
            return x;
        }

        public void Print()
        {
            Console.WriteLine(_root);
        }

        private void Print(Node x)
        {
            if (x==null)
            {
                return;
            }

            Print(x.Left);
            Console.WriteLine(x.Key);
            Print(x.Right);
        }

        public IEnumerable<Key> Keys()
        {
            return Keys(Min(), Max());
        }

        private IEnumerable<Key> Keys(Key lo, Key hi)
        {
            Queue<Key> queue = new Queue<Key>();
            Keys(_root, queue, lo, hi);
            return queue;
        }

        private void Keys(Node x,Queue<Key> queue,Key lo,Key hi)
        {
            if (x == null)
            {
                return;
            }

            int cmpLo = lo.CompareTo(x.Key);
            int cmpHi = hi.CompareTo(x.Key);
            if (cmpLo < 0)
            {
                Keys(x.Left, queue, lo, hi);
            }

            if (cmpLo<=0 && cmpHi>=0)
            {
                queue.Enqueue(x.Key);
            }

            if (cmpHi>0)
            {
                Keys(x.Right, queue, lo, hi);
            }
        }

    }
}
