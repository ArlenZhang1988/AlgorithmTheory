using System;
using System.Collections.Generic;
using System.Text;

namespace Search
{
    class NodeSymolTable<Key, Value> : OrderedST<Key, Value> where Key : IComparable where Value:IComparable
    {
        Node<Key, Value> firstNode,lastNode;

        int size;

        public NodeSymolTable()
        {
            size = 0;
        }

        public override Key Ceiling(Key k)
        {
            throw new NotImplementedException();
        }

        public override bool Contains(Key k)
        {
            if (Get(k).CompareTo( default(Value))>=0)
            {
                return true;
            }

            return false;
        }

        public override void Delete(Key k)
        {
            Node<Key, Value> tempNode,tempNode2;

            tempNode = firstNode;
            tempNode2 = tempNode;

            while (tempNode != null)
            {
                if (tempNode.KeyPro.CompareTo(k) == 0)
                {
                    tempNode2.NextNode = tempNode.NextNode;
                }

                tempNode2 = tempNode;
                tempNode = tempNode.NextNode;
            }

            size--;
        }

        public override void DeleteMax()
        {
            Delete(Max());
        }

        public override void DeleteMin()
        {
            Delete(Min());
        }

        public override Key Floor(Key k)
        {
            throw new NotImplementedException();
        }

        public override Value Get(Key k)
        {
            Node<Key, Value> tempNode;

            tempNode = firstNode;

            for (Node<Key,Value> i = firstNode;  i!=null; i=i.NextNode)
            {
                if (k.Equals(i.KeyPro))
                {
                    return i.ValuePro;
                }
            }

            return default(Value);

            //while (tempNode!=null)
            //{
            //    if (tempNode.KeyPro.CompareTo(k) == 0)
            //    {
            //        return tempNode.ValuePro;
            //    }

            //    tempNode = tempNode.NextNode;
            //}

            //return default(Value);
        }

        public override bool IsEmpty()
        {
            if (Size()==0)
            {
                return true;
            }

            return false;
        }

        public override IEnumerator<Key> Keys(Key lo, Key hi)
        {
            throw new NotImplementedException();
        }

        public override IEnumerator<Key> Keys()
        {
            return Keys(Min(), Max());
        }

        public override Key Max()
        {
            return Select(size-1);
        }

        public override Key Min()
        {
            return Select(0);
        }

        public override void Put(Key k, Value v)
        {
            //book
            for (Node<Key, Value> i = firstNode; i != null; i = i.NextNode)
            {
                if (k.Equals(i.KeyPro))
                {
                    i.ValuePro = v;
                    return;
                }
            }

            firstNode.NextNode = firstNode;
            firstNode = new Node<Key, Value>(k, v);

            //My way
            //if (size == 0)
            //{
            //    firstNode = new Node<Key, Value>(k, v);
            //    lastNode = firstNode.NextNode;

            //    size++;

            //    return;
            //}

            //if (!Contains(k))
            //{
            //    lastNode = new Node<Key, Value>(k, v);
            //    lastNode = lastNode.NextNode;

            //    size++;
            //}
        }

        public override int Rank(Key k)
        {
            throw new NotImplementedException();
        }

        public override Key Select(int k)
        {
            throw new NotImplementedException();
        }

        public override int Size(Key lo, Key hi)
        {
            if (hi.CompareTo(lo) < 0)
            {
                return 0;
            }
            else if (Contains(hi))
            {
                return Rank(hi) - Rank(lo) + 1;
            }
            else
            {
                return Rank(hi) - Rank(lo);
            }
        }

        public override int Size()
        {
            return size;
        }
    }
}
