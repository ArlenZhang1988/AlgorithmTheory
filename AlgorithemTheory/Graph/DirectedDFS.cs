using System;
using System.Collections.Generic;
using System.Text;

namespace Graph
{
    class DirectedDFS
    {
        private bool[] _marks;

        public DirectedDFS(Digraph g, int s)
        {
            _marks = new bool[g.Vertice()];
            Search(g, s);
        }

        public DirectedDFS(Digraph g, List<int> l)
        {
            _marks = new bool[g.Vertice()];

            foreach (var temp in l)
            {
                if (!_marks[temp])
                {
                    Search(g, temp);
                }
            }
        }

        public void Search(Graph g, int s)
        {
            _marks[s] = true;

            foreach (var temp in g.Adj(s))
            {
                if (!_marks[s])
                {
                    Search(g, temp);
                }
            }
        }

        public bool Marked(int v)
        {
            return _marks[v];
        }
    }
}
