using System;

namespace Dijkstra
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            long time = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            Console.WriteLine(string.Join(Environment.NewLine, new Dijkstra.Dijkstra(Example()).FindPaths("A")));
            Console.WriteLine(new Dijkstra.Dijkstra(Example()).FindPath("A", "G"));
            Console.WriteLine(DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond - time);
            Console.ReadKey();
        }

        private static Graph.Graph Example()
        {
            Graph.Graph graph = new Graph.Graph();
            graph.AddNode("A");
            graph.AddNode("B");
            graph.AddNode("C");
            graph.AddNode("D");
            graph.AddNode("E");
            graph.AddNode("F");
            graph.AddNode("G");
            graph.AddNode("H");
            graph.AddConnection("AB", 1);
            graph.AddConnection("AC", 1);
            graph.AddConnection("AH", 2);
            graph.AddConnection("BE", 1);
            graph.AddConnection("CD", 7);
            graph.AddConnection("CF", 6);
            graph.AddConnection("DG", 3);
            graph.AddConnection("EG", 4);
            graph.AddConnection("FG", 2);
            graph.AddConnection("FH", 5);
            return graph;
        }
    }
}