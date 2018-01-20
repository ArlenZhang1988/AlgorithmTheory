using System;
using System.Collections.Generic;
using System.Text;

class BellmanFordSP
{
        private DirectedEdge[] _paths;
        private double[] _disTo;

        public void Relax(EdgeWeightedDigraph g, int v)
        {
            foreach (var temp in g.Adj(v))
            {
                int w = temp.To;

                if (_disTo[w] > _disTo[v] + temp.Weight)
                {
                    _disTo[w] = _disTo[v] + temp.Weight;
                    _paths[w] = temp;
                }
            }
        }
}
