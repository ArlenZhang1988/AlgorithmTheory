using System;

namespace Union_FindNameSpace
{
    class Program
    {
        static void Main(string[] args)
        {
            UnionFind uf = new UnionFind(50);

            uf.UnionWithWeightPathCompression(1,2);
            uf.UnionWithWeightPathCompression(3, 4);

            uf.Print();
        }
    }
}
