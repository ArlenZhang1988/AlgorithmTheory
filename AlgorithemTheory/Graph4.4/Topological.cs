using System;
using System.Collections.Generic;
using System.Text;
using Graph;

namespace Graph
{
    class Topological
    {
        private List<int> order;

        public Topological(Graph.Digraph g)
        {
            DirectedCycle dc = new DirectedCycle(g);

            if (!dc.HasCycle())
            {
                order = new List<int>();

                DepthFirstOrder dfo = new DepthFirstOrder(g);

                for (int i = 0; i < dfo.ReversePost.Count; i++)
                {
                    order.Add( dfo.ReversePost.Pop());
                }
            }
        }

        public bool IsDag()
        {
            return order != null;
        }

        public List<int> Order()
        {
            return order;
        }
    }
}
