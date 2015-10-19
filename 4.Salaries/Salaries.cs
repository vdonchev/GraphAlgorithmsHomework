namespace _4.Salaries
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Salaries
    {
        private static char[,] graph;
        private static Dictionary<int, long> visited;

        static void Main()
        {
            int numberOfEmployees = int.Parse(Console.ReadLine());
            visited = new Dictionary<int, long>();

            graph = new char[numberOfEmployees, numberOfEmployees];
            for (int row = 0; row < numberOfEmployees; row++)
            {
                string line = Console.ReadLine();
                for (int col = 0; col < numberOfEmployees; col++)
                {
                    graph[row, col] = line[col];
                }
            }

            for (int col = 0; col < numberOfEmployees; col++)
            {
                bool isBoss = true;
                for (int row = 0; row < numberOfEmployees; row++)
                {
                    if (graph[row, col] != 'N')
                    {
                        isBoss = false;
                        break;
                    }
                }

                if (isBoss)
                {
                    CalculateSalaries(col);
                }
            }

            Console.WriteLine(visited.Sum(n => n.Value));
        }

        private static void CalculateSalaries(int node)
        {
            if (visited.ContainsKey(node))
            {
                return;
            }

            long salary = 0;
            bool hasChilds = false;
            for (int child = 0; child < graph.GetLength(0); child++)
            {
                if (graph[node, child] == 'Y')
                {
                    hasChilds = true;
                    CalculateSalaries(child);
                    salary += visited[child];
                }
            }

            if (!hasChilds)
            {
                visited.Add(node, 1);
                return;
            }

            visited.Add(node, salary);
        }
    }
}