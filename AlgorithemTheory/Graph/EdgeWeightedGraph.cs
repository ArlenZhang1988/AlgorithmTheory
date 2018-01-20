using System;
using System.Collections.Generic;
using System.Text;

namespace Graph
{
    class EdgeWeightedGraph
    {
        private int _edge, _vertice;

        private List<Edge>[] adj;

        public EdgeWeightedGraph(int v)
        {
            _vertice = v;

            adj = new List<Edge>[v];

            for (int i = 0; i < _vertice; i++)
            {
                adj[i] = new List<Edge>();
            }
        }

        public void AddEdge(Edge e)
        {
            int v = e.Either(), w = e.Other(v);

            adj[v].Add(e);
            adj[w].Add(e);

            _edge++;
        }

        public List<Edge> Adj(int v)
        {
            return adj[v];
        }

        public int Edge()
        {
            return _edge;
        }

        public int Vertice()
        {
            return _vertice;
        }

        public List<Edge> Edges()
        {
            List<Edge> temp = new List<Edge>();

            for (int i = 0; i < _vertice; i++)
            {
                foreach (var e in adj[i])
                {
                    if (e.Other(i)>i)
                    {
                        temp.Add(e);
                    }
                }
            }

            return temp;
        }

    }
}
