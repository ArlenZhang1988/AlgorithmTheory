using System;
using System.Collections.Generic;

namespace Graph
{
    class Program
    {
        static void Main(string[] args)
        {
            // Matrix m = new Matrix(10);
            //Digraph m = new Digraph(5);

            //m.AddEdge(0, 1);
            //m.AddEdge(1, 2);
            //m.AddEdge(2, 3);
            //m.AddEdge(3, 4);
            //m.AddEdge(1, 3);

            //DepthFirstPaths dp = new DepthFirstPaths(m, 6);
            //List<int> temp = dp.PathTo(9);

            //BreadthFirstPaths bp = new BreadthFirstPaths(m, 0);
            //List<int> temp = bp.PathTo(5);

            //DirectedCycle dc = new DirectedCycle(m);
            //List<int> temp = dc.Cycle();

            //Topological tp = new Topological(m);
            //List<int> temp = tp.Order();

            //if (temp!=null)
            //{
            //    foreach (var j in temp)
            //    {
            //        Console.Write(j + " ");
            //    }
            //}

            //Console.WriteLine(m.ToString());

            TestWeightedGraph();
        }

        public static void TestWeightedGraph()
        {
            EdgeWeightedGraph ewg = new EdgeWeightedGraph(10);
            ewg.AddEdge(new Edge(0, 2, 10));
        }
    }
}