using System;
using System.Collections.Generic;
using System.Text;

namespace Graph
{
    class DirectedCycle
    {
        private bool[] _marked,_onList;
        private int[] _edgeTo;
        private List<int> _cycle;

        public DirectedCycle(Digraph g)
        {
            _onList = new bool[g.Vertice()];
            _marked = new bool[g.Vertice()];
            _edgeTo = new int[g.Vertice()];

            for (int i = 0; i < g.Vertice(); i++)
            {
                if (!_marked[i])
                {
                    Search(g, i);
                }
            }
        }

        public void Search(Digraph g, int s)
        {
            _onList[s] = true;
            _marked[s] = true;

            foreach (var temp in g.Adj(s))
            {
                if (HasCycle())
                {
                    return;
                }
                else if (!_marked[temp])
                {
                    _edgeTo[temp] = s;
                    Search(g, temp);
                }
                else if (_onList[temp])
                {
                    _cycle = new List<int>();

                    for (int i = s; i != temp; i = _edgeTo[i])
                    {
                        _cycle.Add(i);
                    }

                    _cycle.Add(temp);
                    _cycle.Add(s);
                }
            }

            _onList[s] = false;
        }

        public bool HasCycle()
        {
            return _cycle != null;
        }

        public List<int> Cycle()
        {
            if (_cycle==null)
            {
                return null;
            }

            _cycle.Reverse();

            return _cycle;
        }
    }
}
