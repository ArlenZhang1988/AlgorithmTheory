using System;
using System.Collections.Generic;
using System.Text;  

namespace Graph
{
    class KruskaMST //unacheivable in c# may need to find a new way.
    {
        private List<Edge> _mst;

        public KruskaMST(EdgeWeightedGraph g)
        {
            _mst = new List<Edge>();
            List<Edge> pq = new List<Edge>();
        }
    }
}
