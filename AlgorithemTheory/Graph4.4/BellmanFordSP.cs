using System;
using System.Collections.Generic;
using System.Text;

class BellmanFordSP : SP
{
        private DirectedEdge[] _paths;
        private double[] _disTo;
    private bool[] _onQ;
    private Queue<int> _q;
    private int _cost=0;
    private List<DirectedEdge> _cycle;

    public BellmanFordSP(EdgeWeightedDigraph g,int s)
    {
        _disTo = new double[g.Vertice];
        _onQ = new bool[g.Vertice];
        _q = new Queue<int>();
        _paths = new DirectedEdge[g.Vertice];
        //_cycle = new List<DirectedEdge>();

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

        _q.Enqueue(s);
        _onQ[s] = true;

        while (_q.Count!=0 )
        {
            int v = _q.Dequeue();
            _onQ[v] = true;
            Relax(g,v);
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

                if (!_onQ[w])
                {
                    _q.Enqueue(w);
                    _onQ[w] = true;
                }

                }

            //if (_cost++%g.Vertice==0)
            //{
            //    FindNegativeCycle();
            //}
            }
        }

    public override double DisTo(int v)
    {
        return _disTo[v];
    }

    public override bool HasPath(int v)
    {
        if (_disTo[v] != ShortestPath.INFINITE)
        {
            return true;
        }

        return false;
    }

    public override List<DirectedEdge> PathTo(int v)
    {
        if (!HasPath(v))
        {
            return null;
        }

        List<DirectedEdge> tempList = new List<DirectedEdge>();

        //while (temp!=v)
        //{
        //    tempList.Add(_paths[temp]);

        //    temp = _paths[temp].To;
        //}

        for (DirectedEdge e = _paths[v]; e != null; e = _paths[e.From])
        {
            tempList.Add(e);
        }

        tempList.Reverse();

        return tempList;
    }

   // public void FindNegativeCycle()
   // {
   //     int v = _paths.Length;
   //     EdgeWeightedDigraph spt;
   //     spt = new EdgeWeightedDigraph(v);

   //     for (int i = 0; i < v; i++)
   //     {
   //         if (_paths[v] !=null)
   //         {
   //             spt.AddEdge(_paths[v]);
   //         }
   //     }

   //     EdgeWeightedCycleFinder cf = new EdgeWeightedCycleFinder(spt);

   //     _cycle = cf.Cycle();
   //}

   // public bool HasNegativeCycle()
   // {
   //     return _cycle != null;
   // }

   // public List<DirectedEdge> NegativeCycle()
   // {
   //     return _cycle;
   // }
}
