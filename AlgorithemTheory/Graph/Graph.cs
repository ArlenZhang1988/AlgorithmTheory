using System;
using System.Collections.Generic;
using System.Text;

namespace Graph
{
    public abstract class Graph
    {
        public abstract int Vertice();
        public abstract int Edge();
        public abstract void AddEdge(int v, int w);
        public abstract List<int> Adj(int v);

        public static int Degree(Graph g,int v)
        {
            int degree = 0;

            foreach (var temp in g.Adj(v))
            {
                degree++;
            }

            return degree;
        }

        public static int MaxDegree(Graph g)
        {
            int max = 0;

            for (int v = 0; v < g.Vertice(); v++)
            {
                if (Degree(g,v) > max)
                {
                    max = Degree(g, v);
                }
            }

            return max;
        }

        public static double AveDegree(Graph g)
        {
            return 2 * g.Edge() / g.Vertice();
        }

        public static int NumberOfSelfLoops(Graph g)
        {
            int count = 0;

            for (int v = 0; v < g.Vertice(); v++)
            {
                foreach (var temp in g.Adj(v))
                {
                    if (v == temp)
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        public override string ToString()
        {
            string s = Vertice() + " Vertices, " + Edge() + " Edges.\n";

            for (int v = 0; v < Vertice(); v++)
            {
                s += v + ": ";

                foreach (var temp in Adj(v))
                {
                    s += temp + " ";
                }

                s += "\n";
            }

            return s;
        }
    }
}
