using System;
using System.Collections.Generic;
using System.Text;

public abstract class SP
{
    public abstract double DisTo(int v);
    public abstract bool HasPath(int v);
    public abstract List<DirectedEdge> PathTo(int v);
}
