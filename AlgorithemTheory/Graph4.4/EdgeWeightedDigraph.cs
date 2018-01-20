using System;
using System.Collections.Generic;
using System.Text;

class EdgeWeightedDigraph
{
    private int _vertice;
    private List<DirectedEdge>[] _adj;

    public int Vertice { get { return _vertice; } }

    public EdgeWeightedDigraph(int v)
    {
        _vertice = v;

        _adj = new List<DirectedEdge>[v];

        for (int i = 0; i < _adj.Length; i++)
        {
            _adj[i] = new List<DirectedEdge>();
        }
    }

    public void AddEdge(DirectedEdge e)
    {
        _adj[e.From].Add(e);
    }

    public List<DirectedEdge> Adj(int v)
    {
        return _adj[v];
    }

    public List<DirectedEdge> Edges()
    {
        List<DirectedEdge> tempList = new List<DirectedEdge>();

        for (int i = 0; i < _adj.Length; i++)
        {
            foreach (var temp in _adj[i])
            {
                tempList.Add(temp);
            }
        }

        return _adj[0];
    }
}
