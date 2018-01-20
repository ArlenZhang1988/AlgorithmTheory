using System;
using System.Collections.Generic;
using System.Text;

namespace Graph
{
    public class DepthFirstSearch : GraphSearch
    {
        protected bool[] _marks;
        protected int count;

        public DepthFirstSearch(Graph g,int s)
        {
            _marks = new bool[g.Vertice()];
            Search(g, s);
        }

        public override int Count()
        {
            return count;
        }

        public override bool Marked(int v)
        {
            return _marks[v];
        }

        public override void Search(Graph g, int s)
        {
            _marks[s] = true;
            count++;

            foreach (var temp in g.Adj(s))
            {
                if (!_marks[temp])
                {
                    Search(g,temp);
                }
            }
        }
    }
}
