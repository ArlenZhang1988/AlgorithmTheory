using System;
using System.Collections.Generic;
using System.Text;

namespace Graph
{
    public abstract class GraphSearch
    {
        public abstract void Search(Graph g, int s);
        public abstract bool Marked(int v);
        public abstract int Count();
    }
}
