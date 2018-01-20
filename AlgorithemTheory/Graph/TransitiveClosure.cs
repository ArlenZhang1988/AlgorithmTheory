using System;
using System.Collections.Generic;
using System.Text;

namespace Graph
{
    class TransitiveClosure
    {
        private DirectedDFS[] all;

        public TransitiveClosure(Digraph g)
        {
            all = new DirectedDFS[g.Vertice()];

            for (int i = 0; i < g.Vertice(); i++)
            {
                all[i] = new DirectedDFS(g, i);
            }
        }

        public bool Reachable(int v, int w)
        {
            return all[v].Marked(w);
        }
    }
}
