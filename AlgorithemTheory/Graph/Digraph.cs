using System;
using System.Collections.Generic;
using System.Text;

namespace Graph
{
    class Digraph : DigraphBase
    {
        private int _edge, _vertice;
        private List<int>[] _adj;

        public Digraph(int v)
        {
            _adj = new List<int>[v];

            _vertice = v;
            _edge = 0;

            for (int i = 0; i < _adj.Length; i++)
            {
                _adj[i] = new List<int>();
            }
        }

        public override void AddEdge(int v, int w)
        {
            _adj[v].Add(w);

            _edge++;
        }

        public override List<int> Adj(int v)
        {
            return _adj[v];
        }

        public override int Edge()
        {
            return _edge;
        }

        public override DigraphBase Reverse()
        {
            Digraph t = new Digraph(_vertice);

            for (int v = 0; v < _vertice; v++)
            {
                foreach (var temp in Adj(v))
                {
                    t.AddEdge(temp, v);
                }
            }

            return t;
        }

        public override int Vertice()
        {
            return _vertice;
        }
    }
}
