namespace _1.DistanceBetweenVertices
{
    class Edge
    {
        public Edge(int parent, int child)
        {
            this.Parent = parent;
            this.Child = child;
        }

        public int Parent { get; private set; }

        public int Child { get; private set; }
    }
}