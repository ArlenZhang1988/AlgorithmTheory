using System;
using System.Collections.Generic;
using System.Text;

namespace Graph
{
    public abstract class FindPath
    {
        public abstract bool HasPathTo(int v);
        public abstract List<int> PathTo(int v);
    }
}
