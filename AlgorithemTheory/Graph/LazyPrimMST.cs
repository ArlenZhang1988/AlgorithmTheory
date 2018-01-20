using System;
using System.Collections.Generic;
using System.Text;

namespace Graph
{
    class LazyPrimMST : MST
    {
        private bool[] _marked;
        private List<Edge> _pq;
        private List<Edge> _mst;

        public LazyPrimMST(EdgeWeightedGraph g)
        {
            _mst = new List<Edge>();
            _pq = new List<Edge>();
            _marked = new bool[g.Vertice()];

            Visit(g, 0);

            while (_pq.Count!=0)
            {
                Edge e = ReturnEdgeWithLowestWeight();

                int v = e.Either(), w = e.Other(v);

                if (_marked[v] && _marked[w])
                {
                    continue;
                }

                _mst.Add(e);

                if (!_marked[v])
                {
                    Visit(g, v);
                }

                if (!_marked[w])
                {
                    Visit(g, w);
                }
            }

            _mst.Reverse();
        }

        private Edge ReturnEdgeWithLowestWeight()
        {
            Edge[] tempArray = _pq.ToArray();

            Edge minWeightedEdge = tempArray[0];

            for (int i = 0; i < tempArray.Length; i++)
            {
                if (minWeightedEdge.CompareTo(tempArray[i]) > 0)
                {
                    minWeightedEdge = tempArray[i];
                }
            }

            _pq.Remove(minWeightedEdge);

            return minWeightedEdge;
        }

        private void Visit(EdgeWeightedGraph g, int v)
        {
            _marked[v] = true;
            foreach (var temp in g.Adj(v))
            {
                if (!_marked[temp.Other(v)])
                {
                    _pq.Add(temp);
                }
            }
        }

        public override List<Edge> Edges()
        {
            return _mst;
        }

        public override double Weight()
        {
            throw new NotImplementedException();
        }
    }
}
