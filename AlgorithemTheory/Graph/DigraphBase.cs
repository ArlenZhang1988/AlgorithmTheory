using System;
using System.Collections.Generic;
using System.Text;

namespace Graph
{
    public abstract class DigraphBase : Graph
    {
        public abstract DigraphBase Reverse();
    }
}
