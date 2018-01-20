using System;
using System.Collections.Generic;
using System.Text;

namespace Graph
{
    public abstract class MST
    {
        public abstract List<Edge> Edges();

        public abstract double Weight();
    }
}
