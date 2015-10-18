namespace _1.DistanceBetweenVertices
{
    using System;
    using System.Collections.Generic;

    public static class DistanceBetweenVertices
    {
        static private Dictionary<int, List<int>> graph;
        static private List<Edge> edges;

        static void Main(string[] args)
        {
            edges = new List<Edge>()
            {
                new Edge(11, 7), //3
                new Edge(11, 21), //3
                new Edge(21, 4), //-1
                new Edge(19, 14), //2
                new Edge(1, 4), //2
                new Edge(1, 11), //-1
                new Edge(31, 21), //-1
                new Edge(11, 14), //4
                new Edge(1, 1), //0
            };

            graph = new Dictionary<int, List<int>>()
            {
                {11, new List<int>() {4} },
                {4, new List<int>() {12, 1} },
                {1, new List<int>() {12, 21, 7} },
                {7, new List<int>() {21} },
                {12, new List<int>() {4, 19} },
                {19, new List<int>() {1, 21} },
                {21, new List<int>() {14, 31} },
                {14, new List<int>() {14}},
                {31, new List<int>() {} },
            };

            foreach (var node in edges)
            {
                int steps = FindDistance(node.Parent, node.Child);

                if (steps >= 0)
                {
                    Console.WriteLine(
                        "The the shortest distance between {0} - {1} vertices is {2} steps",
                        node.Parent,
                        node.Child,
                        steps);
                }
                else
                {
                    Console.WriteLine(
                        "There is no path connecting {0} - {1} vertices",
                        node.Parent,
                        node.Child);
                }
            }
        }

        private static int FindDistance(int parent, int child)
        {
            var queue = new Queue<Node>();
            var visitedNodes = new HashSet<int>();

            queue.Enqueue(new Node() { Name = parent, Distance = 0 });
            visitedNodes.Add(parent);

            while (queue.Count > 0)
            {
                Node currentNode = queue.Dequeue();
                if (currentNode.Name == child)
                {
                    return currentNode.Distance;
                }

                foreach (var node in graph[currentNode.Name])
                {
                    if (!visitedNodes.Contains(node))
                    {
                        queue.Enqueue(new Node() { Name = node, Distance = currentNode.Distance + 1 });
                        visitedNodes.Add(node);
                    }
                }
            }

            return -1;
        }
    }
}