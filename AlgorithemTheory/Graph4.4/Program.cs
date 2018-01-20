using System;

namespace Graph4._4
{
    class Program
    {
        public static DirectedEdge[] TestEdgeData = new DirectedEdge[] {
                    new DirectedEdge(4,5,0.35),
                    new DirectedEdge(5,4,0.35),
                    new DirectedEdge(4,7,0.37),
                    new DirectedEdge(5,7,0.28),
                    new DirectedEdge(7,5,0.28),
                    new DirectedEdge(5,1,0.32),
                    new DirectedEdge(0,4,0.38),
                    new DirectedEdge(0,2,0.26),
                    new DirectedEdge(7,3,0.39),
                    new DirectedEdge(1,3,0.29),
                    new DirectedEdge(2,7,0.34),
                    new DirectedEdge(6,2,0.40),
                    new DirectedEdge(3,6,0.52),
                    new DirectedEdge(6,0,0.58),
                    new DirectedEdge(6,4,0.93),
};

        static void Main(string[] args)
        {
            EdgeWeightedDigraph g = new EdgeWeightedDigraph(8);

            foreach (var temp in TestEdgeData)
            {
                g.AddEdge(temp);
            }

            SP sp;

            //sp = new ShortestPath(g, 0);
            sp = new BellmanFordSP(g, 0);

            for (int i = 0; i < g.Vertice; i++)
            {
                Console.Write(0 + "to" + i + "( {0} )",sp.DisTo(i));

                if (sp.HasPath(i))
                {
                    foreach (DirectedEdge temp in sp.PathTo(i))
                    {
                        Console.Write(" " +  temp.ToString()+ "   ");
                    }

                    Console.WriteLine();
                }
            }
        }
    }
}
