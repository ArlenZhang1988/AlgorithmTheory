using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

    class ShortestPath : SP
    {
        public static double INFINITE = 9999999;

        private int _s;

        private DirectedEdge[] _paths;
        private double[] _disTo;
        private Dictionary<int, double> _pq;

        public ShortestPath(EdgeWeightedDigraph g, int s)
        {
            _s = s;

            _disTo = new double[g.Vertice];

            for (int i = 0; i < _disTo.Length; i++)
            {
                if (s == i)
                {
                    _disTo[s] = 0;
                }
                else
                {
                    _disTo[i] = INFINITE;
                }
            }

            _paths = new DirectedEdge[g.Vertice];

            _pq = new Dictionary<int, double>();

            _pq.Add(s, 0.0);

            while (_pq.Count != 0)
            {
                Relax(g, GetTheKeyWithLowestWeight());
            }
        }

        private int GetTheKeyWithLowestWeight()
        {
            int temp = _s;
            double tempMin = INFINITE;

            foreach (var tempValue in _pq.Values)
            {
                if (tempMin > tempValue)
                {
                    tempMin = tempValue;
                    temp = _pq.Where(x => x.Value == tempValue).Select(pair => pair.Key).ToArray()[0];
                }
            }

            _pq.Remove(temp);

            return temp;
        }

        public override double DisTo(int v)
        {
            return _disTo[v];
        }

        public override bool HasPath(int v)
        {
            if (_disTo[v] != INFINITE)
            {
                return true;
            }

            return false;
        }

        public override List<DirectedEdge> PathTo(int v)
        {
            if (!HasPath(v))
            {
                return null;
            }

            //int temp = _s;

            List<DirectedEdge> tempList = new List<DirectedEdge>();

            //while (temp!=v)
            //{
            //    tempList.Add(_paths[temp]);

            //    temp = _paths[temp].To;
            //}

            for (DirectedEdge e = _paths[v]; e != null; e = _paths[e.From])
            {
                tempList.Add(e);
            }

            tempList.Reverse();

            return tempList;
        }

        private void Relax(DirectedEdge e)
        {
            int v = e.From, w = e.To;

            if (_disTo[v] + e.Weight < _disTo[w])
            {
                _disTo[w] = _disTo[v] + e.Weight;
                _paths[w] = e;
            }
        }

        public void Relax(EdgeWeightedDigraph g, int v)
        {
            foreach (var temp in g.Adj(v))
            {
                int w = temp.To;

                if (_disTo[w] > _disTo[v] + temp.Weight)
                {
                    _disTo[w] = _disTo[v] + temp.Weight;
                    _paths[w] = temp;

                    if (_pq.ContainsKey(w))
                    {
                        _pq[w] = _disTo[w];
                    }
                    else
                    {
                        _pq.Add(w, _disTo[w]);
                    }
                }
            }
        }
    }
