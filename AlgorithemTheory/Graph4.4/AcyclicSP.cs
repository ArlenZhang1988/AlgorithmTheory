using System;
using System.Collections.Generic;
using System.Text;
using Graph4;

class AcyclicSP
{
    private DirectedEdge[] _paths;
    private double[] _disTo;

    public AcyclicSP(EdgeWeightedDigraph g,int s)
    {
        _disTo = new double[g.Vertice];
        _paths = new DirectedEdge[g.Vertice];

        for (int i = 0; i < _disTo.Length; i++)
        {
            if (s == i)
            {
                _disTo[s] = 0;
            }
            else
            {
                _disTo[i] = ShortestPath.INFINITE;
            }
        }


    }

    public void Relax(EdgeWeightedDigraph g, int v)
    {
        foreach (var temp in g.Adj(v))
        {
            int w = temp.To;

            if (_disTo[w] > _disTo[v] + temp.Weight)
            {
                _disTo[w] = _disTo[v] + temp.Weight;
                _paths[w] = temp;

                if (_pq.ContainsKey(w))
                {
                    _pq[w] = _disTo[w];
                }
                else
                {
                    _pq.Add(w, _disTo[w]);
                }
            }
        }
    }
}