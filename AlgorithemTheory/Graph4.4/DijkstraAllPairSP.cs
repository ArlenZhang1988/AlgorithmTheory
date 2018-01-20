using System;
using System.Collections.Generic;
using System.Text;

class DijkstraAllPairSP
{
    private ShortestPath[] all;

    public DijkstraAllPairSP(EdgeWeightedDigraph g)
    {
        all = new ShortestPath[g.Vertice];

        for (int i = 0; i < g.Vertice; i++)
        {
            all[i] = new ShortestPath(g,i);
        }
    }

    public List<DirectedEdge> PathTo(int s, int t)
    {
        return all[s].PathTo(t);
    }

    public double DisTo(int s, int t)
    {
        return all[s].DisTo(t);
    }
}
