using System;
using System.Collections.Generic;
using System.Text;

namespace Graph
{
    class DepthFirstPaths : FindPath
    {
        private bool[] _marks;
        private int[] _edgeTo;
        private int _s;

        public DepthFirstPaths(Graph g,int s)
        {
            _marks = new bool[g.Vertice()];
            _edgeTo = new int[g.Vertice()];

            _s = s;
            Dfs(g, s);
        }

        public void Dfs(Graph g, int s)
        {
            _marks[s] = true;

            foreach (var temp in g.Adj(s))
            {
                if (!_marks[temp])
                {
                    _edgeTo[temp] = s;
                    Dfs(g, temp);
                }
            }
        }

        public override bool HasPathTo(int v)
        {
            return _marks[v];
        }

        public override List<int> PathTo(int v)
        {
            if (!HasPathTo(v))
            {
                return null;
            }

            List<int> list = new List<int>();

            for (int i = v; i != _s; i = _edgeTo[i])
            {
                list.Add(i);
            }

            return list;
        }
    }
}
