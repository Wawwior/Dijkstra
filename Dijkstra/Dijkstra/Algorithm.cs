using System;
using System.Collections.Generic;
using System.Text;

namespace Dijkstra.Dijkstra
{
    public class Algorithm
    {
        private readonly Graph _graph;

        public Algorithm(Graph graph)
        {
            _graph = graph;
        }

        public List<Node> FindPaths(string start)
        {
            _graph.GetNode(start).Distance = 0;

            bool running = true;

            while (running)
            {
                _graph.Nodes.Sort(Comparer<Node>.Create((n, n1) => n.Distance - n1.Distance));
                foreach (Node n in _graph.Nodes)
                {
                    if (n.Distance != -1 && !n.Iterated)
                    {
                        foreach (string s in _graph.Connections.Keys)
                        {
                            if (s.StartsWith(n.Name))
                            {
                                Node current = _graph.GetNode(s.Substring(1, 1));
                                if (current.Distance > _graph.GetNode(n.Name).Distance + _graph.Connections[s] || current.Distance == -1)
                                {
                                    _graph.GetNode(s.Substring(1, 1)).Distance = _graph.GetNode(n.Name).Distance + _graph.Connections[s];
                                    _graph.GetNode(s.Substring(1, 1)).Previous = n.Name;
                                    _graph.GetNode(s.Substring(1, 1)).Iterated = false;
                                }
                            }
                        }
                        n.Iterated = true;
                    }
                }

                running = false;
                foreach (Node n in _graph.Nodes)
                {
                    if (n.Distance == -1)
                    {
                        running = true;
                        break;
                    }
                }
            }
            
            
            _graph.Nodes.Sort(Comparer<Node>.Create((n, n1) => n.Name.ToCharArray()[0] - n1.Name.ToCharArray()[0]));
            
            return _graph.Nodes;
        }

        public string FindPath(string start, string end)
        {
            StringBuilder path = new StringBuilder();
            path.Append(end);
            List<Node> nodes = FindPaths(start);
            Node node = _graph.GetNode(end);
            int distance = node.Distance;

            while (!node.Previous.Equals(""))
            {
                path.Append(node.Previous);
                node = _graph.GetNode(node.Previous);
            }

            if (!path.ToString().StartsWith(end) || !path.ToString().EndsWith(start))
            {
                return "No Path found!";
            }

            char[] chars = path.ToString().ToCharArray();
            Array.Reverse(chars);

            return new string(chars) + " : " + distance;
        }
    }
}