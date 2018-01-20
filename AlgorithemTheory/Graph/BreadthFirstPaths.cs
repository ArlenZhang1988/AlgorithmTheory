using System;
using System.Collections.Generic;
using System.Text;

namespace Graph
{
    class BreadthFirstPaths : FindPath
    {
        private bool[] _marked;
        private int[] _edgeTo;
        private int _s;

        public BreadthFirstPaths(Graph g, int s)
        {
            _marked = new bool[g.Vertice()];
            _edgeTo = new int[g.Vertice()];

            _s = s;

            Dfs(g,s);
        }

        private void Dfs(Graph g,int s)
        {
            Queue<int> queue = new Queue<int>();

            _marked[s] = true;

            queue.Enqueue(s);

            while (queue.Count!=0)
            {
                int v = queue.Dequeue();

                foreach (var temp in g.Adj(v))
                {
                    if (!_marked[temp])
                    {
                        queue.Enqueue(temp);
                        _marked[temp] = true;
                        _edgeTo[temp] = v;
                    }
                }
            }

        }

        public override bool HasPathTo(int v)
        {
            return _marked[v];
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

            list.Reverse();

            return list;
        }
    }
}
