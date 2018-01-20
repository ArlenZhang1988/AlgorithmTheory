using System;
using System.Collections.Generic;
using System.Text;

namespace Search
{
    class RBTree<Key, Value> : SymbolTable<Key, Value> where Key : IComparable where Value : IComparable
    {
        public static bool RED = true;
        public static bool BLACK = false;

        private class Node
        {
            Value _v;
            Key _k;
            bool _color;
            Node _left, _right;
            private int _number;

            public Node Left { get { return _left; } set { _left = value; } }
            public Node Right { get { return _right; } set { _right = value; } }
            public Key Key { get { return _k; } set { _k = value; } }
            public Value Value { get { return _v; } set { _v = value; } }
            public bool Color { get { return _color; } set { _color = value; } }
            public int Number { get { return _number; } set { _number = value; } }

            public Node(Key k, Value v, bool color,int n)
            {
                _k = k;
                _v = v;
                _color = color;
                _number = n;
            }

            public static bool IsRed(Node x)
            {
                if (x == null)
                {
                    return false;
                }

                return x._color == RED;
            }
        }

        private Node _root;

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
            _root = Put(_root, k, v);
            _root.Color = BLACK;
        }

        private Node Put(Node x, Key k, Value v)
        {
            if (x == null)
            {
                return new Node(k, v, RED, 1);
            }

            int cmp = k.CompareTo(x.Key);

            if (cmp<0)
            {
                x.Left = Put(x.Left, k, v);
            }
            else if (cmp>0)
            {
                x.Right = Put(x.Right, k, v);
            }
            else
            {
                x.Value = v;
            }

            if (Node.IsRed(x.Right) && !Node.IsRed(x.Left))
            {
                x = RotateLeft(x);
            }   

            if (Node.IsRed(x.Left) && !Node.IsRed(x.Right))
            {
                x = RotateRight(x);
            }

            if (Node.IsRed(x.Left) && Node.IsRed(x.Right))
            {
                FlipColor(x);
            }

            x.Number = Size(x.Left) + Size(x.Right) + 1;
            return x;
        }

        public override int Size()
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

        public override Value Get(Key k)
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

        private Node RotateLeft(Node h)
        {
            Node x = h.Right;
            h.Right = x.Left;
            x.Left = h;
            x.Color = h.Color;
            h.Color = RED;
            x.Number = h.Number;
            h.Number = 1 + Size(h.Left) + Size(h.Right);

            return x;
        }

        private Node RotateRight(Node h)
        {
            Node x = h.Left;
            h.Left = x.Right;
            x.Right = h;
            x.Color = h.Color;
            x.Number = h.Number;
            h.Number = 1 + Size(h.Left) + Size(h.Right);

            return x;
        }

        private void FlipColor(Node x)
        {
            x.Color = RED;
            x.Left.Color = BLACK;
            x.Right.Color = BLACK;
        }

        public override void Delete(Key k)
        {
            throw new NotImplementedException();
        }

        public override bool Contains(Key k)
        {
            throw new NotImplementedException();
        }
    }
}
