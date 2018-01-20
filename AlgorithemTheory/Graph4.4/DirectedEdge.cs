using System;
using System.Collections.Generic;
using System.Text;

public class DirectedEdge
{
    int _v, _w;
    double _weight;

    public int From { get { return _v; } }
    public int To { get { return _w; } }
    public double Weight { get { return _weight; } }

    public DirectedEdge(int v, int w, double weight)
    {
        _v = v;
        _w = w;
        _weight = weight;
    }

    public override string ToString()
    {
        return _v + "-" + _w + ":" + _weight;
    }
}
