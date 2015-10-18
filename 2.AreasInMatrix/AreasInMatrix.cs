namespace _2.AreasInMatrix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class AreasInMatrix
    {
        private static string[] graph;
        private static bool[,] visited;
        private static Dictionary<char, int> results;
        private static int numsOfRows;
        private static int numOfCols;

        private static void Main(string[] args)
        {
            GetInput();

            visited = new bool[numsOfRows, numOfCols];
            results = new Dictionary<char, int>();

            for (int row = 0; row < numsOfRows; row++)
            {
                for (int col = 0; col < numOfCols; col++)
                {
                    if (!visited[row, col])
                    {
                        char currentLetter = graph[row][col];
                        if (!results.ContainsKey(currentLetter))
                        {
                            results.Add(currentLetter, 0);
                        }

                        results[currentLetter]++;

                        ExploreArea(row, col, currentLetter);
                    }
                }
            }

            Print();
        }

        static void ExploreArea(int row, int col, char letter)
        {
            visited[row, col] = true;

            if (IsValidCell(row + 1, col, letter))
                ExploreArea(row + 1, col, letter);
            if (IsValidCell(row - 1, col, letter))
                ExploreArea(row - 1, col, letter);
            if (IsValidCell(row, col + 1, letter))
                ExploreArea(row, col + 1, letter);
            if (IsValidCell(row, col - 1, letter))
                ExploreArea(row, col - 1, letter);
        }

        private static bool IsValidCell(int row, int col, char letter)
        {
            return (row >= 0 && col >= 0 && row < numsOfRows && col < numOfCols && letter == graph[row][col] && !visited[row, col]);
        }

        private static void Print()
        {
            Console.WriteLine("Areas: {0}", results.Sum(i => i.Value));
            foreach (var result in results)
            {
                Console.WriteLine("Letter '{0}' -> {1}", result.Key, result.Value);
            }
        }

        private static void GetInput()
        {
            string num = Console.ReadLine();
            numsOfRows = int.Parse(num.Substring(num.Length - 1, 1));

            graph = new string[numsOfRows];
            for (int i = 0; i < numsOfRows; i++)
            {
                graph[i] = Console.ReadLine();
            }

            numOfCols = graph[0].Length;
        }
    }
}