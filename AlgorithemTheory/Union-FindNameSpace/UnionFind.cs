using System;
using System.Collections.Generic;
using System.Text;

namespace Union_FindNameSpace
{
    class UnionFind
    {
        int[] tArray;
        int[] weight;

        int count;

        public UnionFind(int n)
        {
            tArray = new int[n];

            for (int i = 0; i < n; i++)
            {
                tArray[i] = i;
            }

            weight = new int[n];

            for (int i = 0; i < n; i++)
            {
                weight[i] = 1;
            }

            count = n;
        }

        public void QuickFindUnion(int p, int q)
        {
            int pID = QuickFind(p);
            int qID = QuickFind(q);

            if (pID == qID)
            {
                return;
            }

            for (int i = 0; i < tArray.Length; i++)
            {
                if (tArray[i] == pID)
                {
                    tArray[i] = qID;
                }
            }

            count--;

            //N
        }

        public void QuickUnion(int p, int q)
        {
            if (!Connnected(p, q))
            {
                tArray[p] = QuickUnionFind(q);

                count--;
            }

            //1
        }

        public void UnionWithWeight(int p, int q)
        {
            if (!Connnected(p, q))
            {
                if (weight[p] <= weight[q])
                {
                    tArray[p] = FindWithWeight(q);
                    weight[q] += weight[p];
                }
                else
                {
                    tArray[q] = FindWithWeight(p);
                    weight[p] += weight[q];
                }

            }

            count--;

            //logN
        }

        public void UnionWithWeightPathCompression(int p, int q)
        {
            if (Connnected(p, q))
            {
                if (weight[p] <= weight[q])
                {
                    tArray[p] = FindWithWeightPathCompression(q);
                    weight[q] += weight[p];
                }
                else
                {
                    tArray[q] = FindWithWeightPathCompression(p);
                    weight[p] += weight[q];
                }

            }

            count--;

            //logN
        }

        int QuickFind(int p)
        {
            return tArray[p];

            //1
        }

        int QuickUnionFind(int p)
        {
            while (p != tArray[p])
            {
                p = tArray[p];
            }

            return p;

            //n
        }

        int FindWithWeight(int p)
        {
            while (p != tArray[p])
            {
                p = tArray[p];
            }

            return p;

            //logN
        }

        int FindWithWeightPathCompression(int p)
        {
            while (p != tArray[p])
            {
                tArray[p] = tArray[tArray[p]];
                p = tArray[p];
            }

            return p;

            //logN
        }

        public bool Connnected(int p, int q)
        {
            if (FindWithWeightPathCompression(p) != FindWithWeightPathCompression(q))
            {
                return true;
            }

            return false;
        }

        public int Count()
        {
            return count;
        }

        public void Print()
        {
            foreach (var temp in tArray)
            {
                Console.Write(temp + " ");
            }
        }
    }
}