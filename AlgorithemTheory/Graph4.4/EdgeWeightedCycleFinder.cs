using System;
using System.Collections.Generic;
using System.Text;

class EdgeWeightedCycleFinder
{
        private bool[] _marked, _onList;
        private DirectedEdge[] _edgeTo;
        private List<DirectedEdge> _cycle;

        public EdgeWeightedCycleFinder(EdgeWeightedDigraph g)
        {
            _onList = new bool[g.Vertice];
            _marked = new bool[g.Vertice];
            _edgeTo = new DirectedEdge[g.Vertice];

        List<DirectedEdge> tempList= g.Edges();
        DirectedEdge[] tempArray = tempList.ToArray();

            for (int i = 0; i < tempArray.Length; i++)
            {
                if (!_marked[i])
                {
                    Search(g, tempArray[i]);
                }
            }
        }

        public void Search(EdgeWeightedDigraph g, DirectedEdge s)
        {
            _onList[s.To] = true;
            _marked[s.To] = true;

            foreach (var temp in g.Adj(s.To))
            {
                if (HasCycle())
                {
                    return;
                }
                else if (!_marked[temp.From])
                {
                    _edgeTo[temp.From] = s;
                    Search(g, temp);
                }
                else if (_onList[temp.From])
                {
                    _cycle = new List<DirectedEdge>();

                    for (int i = s.From; i != temp.From; i = _edgeTo[i].From)
                    {
                        _cycle.Add(_edgeTo[i]);
                    }

                    _cycle.Add(temp);
                    _cycle.Add(s);
                }
            }

            _onList[s.From] = false;
        }

        public bool HasCycle()
        {
            return _cycle != null;
        }

        public List<DirectedEdge> Cycle()
        {
            if (_cycle == null)
            {
                return null;
            }

            _cycle.Reverse();

            return _cycle;
        }
    }
