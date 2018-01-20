using System;
using System.Collections.Generic;
using System.Text;

namespace Graph
{
    class PrimMST //Infinished version
    {
        private Edge[] _edgeTo;
        private double[] _distTo;
        private bool[] _marked;
        private List<Edge> _pq;

        public PrimMST(EdgeWeightedGraph g)
        {
            _edgeTo = new Edge[g.Vertice()];
            _distTo = new double[g.Vertice()];
            _marked = new bool[g.Vertice()];

            for (int i = 0; i < g.Vertice(); i++)
            {
                _distTo[i] = default(double);
            }

            _pq = new List<Edge>();

            _distTo[0] = 0.0;
            _pq.Add(g.Edges()[0]);

            while (_pq.Count != 0)
            {
                Visit(g, ReturnEdgeWithLowestWeight().Either());
            }
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
                int w = temp.Other(v);

                if (_marked[w])
                {
                    continue;
                }

                if (temp.Weight <_distTo[w])
                {
                    _edgeTo[w] = temp;

                    _distTo[w] = temp.Weight;

                    //if (_pq.Contains(w))
                    //{

                    //}
                }

                if (!_marked[temp.Other(v)])
                {
                    _pq.Add(temp);
                }
            }
        }

    }
}
