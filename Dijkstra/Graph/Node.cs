namespace Dijkstra.Graph
{
    public class Node
    {
        public Node(string name)
        {
            Name = name;
        }

        public string Name { get; }
        public int Distance { get; set; } = -1;
        public string Previous { get; set; } = "";
        public bool Iterated { get; set; } = false;

        public override string ToString()
        {
            return "Node{" +
                   "name=" + Name +
                   ", distance=" + Distance +
                   ", previous='" + Previous + '\'' +
                   '}';
        }
    }
}