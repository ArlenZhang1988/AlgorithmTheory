using System;
using System.Collections.Generic;
using System.Text;

namespace Graph
{
    public class Edge : IComparable
    {
        private int _v, _w;
        private double _weight;

        public int V { get { return _v; } }
        public int W { get { return _w; } }
        public double Weight { get { return _weight; } }

        public Edge(int v, int w, double weight)
        {
            _v = v;
            _w = w;
            _weight = weight;
        }

        public int Either()
        {
            return _v;
        }

        public int Other(int v)
        {
            if (v == _v)
            {
                return _w;
            }
            else if(v == _w)
            {
                return _v;
            }

            return -1;
        }


        public int CompareTo(object obj)
        {
            Edge tempE = (Edge)obj;

            if (_weight < tempE.Weight)
            {
                return -1;
            }
            else if (_weight > tempE.Weight)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public override string ToString()
        {
            return _v + "-" + _w + " : " + _weight;
        }
    }
}
