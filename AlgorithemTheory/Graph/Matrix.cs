using System;
using System.Collections.Generic;
using System.Text;

namespace Graph
{
    class Matrix : Graph
    {
        private int _edge, _vertice;

        private List<int>[] adj;

        public Matrix(int v)
        {
            _vertice = v;

            adj = new List<int>[v];

            for (int i = 0; i < _vertice; i++)
            {
                adj[i] = new List<int>();
            }
        }

        public override void AddEdge(int v, int w)
        {
            adj[v].Add(w);
            adj[w].Add(v);

            _edge++;
        }

        public override List<int> Adj(int v)
        {
            return adj[v];
        }

        public override int Edge()
        {
            return _edge;
        }

        public override int Vertice()
        {
            return _vertice;
        }
    }
}
