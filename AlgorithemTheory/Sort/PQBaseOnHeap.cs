using System;
using System.Collections.Generic;
using System.Text;

namespace Sort
{
    class PQBaseOnHeap<T> : MaxPQ<T> where T : IComparable
    {
        private T[] pq;
        private int index;

        public PQBaseOnHeap(int maxIndex)
        {
            index = 1;

            pq = new T[maxIndex + 1];
        }

        public void Sort(T[] a)
        {
            int n = a.Length-1;

            for (int k = n/2; k >=1 ; k--)
            {
                Sink(a, k,n);
            }

            while (n>1)
            {
                Exchange(a, 1, n);
                Sink(a, 1,n-1);
                n--;
            }
        }

        public override T DeleteMax()
        {
            T temp = pq[1];

            Exchange(pq, 1, index--);

            pq[index + 1] = default(T); //不理解

            Sink(1);

            return temp;
        }

        public override void Exchange(T[] pq, int i, int j)
        {
            T temp = pq[i];
            pq[i] = pq[j];
            pq[j] = temp;
        }

        public override void Insert(T v)
        {
            pq[index] = v;

            Swin(index);

            index++;
        }

        public override bool IsEmpty()
        {
            if (index==1)
            {
                return true;
            }

            return false;
        }

        public override bool Less(T[] pq, int i, int j)
        {
            if (pq[i].CompareTo (pq[j]) < 0)
            {
                return true;
            }

            return false;
        }

        public override T Max()
        {
            return pq[1];
        }

        public override int Size()
        {
            throw new NotImplementedException();
        }

        private void Swin(int k)
        {
            while (k>1 && Less(pq,k/2,k)) // k/2代表父节点
            {
                Exchange(pq, k / 2, k);
                k = k / 2;
            }
        }

        private void Sink(int k) //理解部分
        {
            while (2*k <= index)
            {
                int j = 2 * k;

                if (j<index && Less(pq,j,j+1))
                {
                    j++;
                }

                if (!Less(pq,k,j))
                {
                    break;
                }

                Exchange(pq, k, j);
                k = j;
            }
        }

        private void Sink(T[] a,int k,int n) //理解部分
        {
            while (2 * k <= n)
            {
                int j = 2 * k;

                if (j < n && Less(a, j, j + 1))
                {
                    j++;
                }

                if (!Less(a, k, j))
                {
                    break;
                }

                Exchange(a, k, j);
                k = j;
            }
        }
    }
}
