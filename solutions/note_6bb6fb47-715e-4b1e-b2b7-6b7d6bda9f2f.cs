using System;
using System.Collections.Generic;

public class Program
{
    static void Main(string[] args)
    {
        var edges = new List<(int from, int to, int weight)>
        {
            (0, 1, 3),
            (0, 2, 5),
            (1, 2, -2),
            (1, 3, 4),
            (2, 3, 1)
        }; 

        int n = 4;
        int source = 0;

        try
        {
            var result = Solution.BellmanFordAlgorithm(n, edges, source);
            for (int i = 0; i < n; i++)
                Console.WriteLine($"dist[{i}] = {(result[i] >= Solution.INF ? "INF" : result[i].ToString())}");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}

public static class Solution
{
    public const int INF = int.MaxValue / 2;

    public static int[] BellmanFordAlgorithm(int n, List<(int from, int to, int weight)> edges, int source)
    {
        int[] distances = new int[n];
        Array.Fill(distances, INF);
        distances[source] = 0;

        for (int i = 0; i < n - 1; i++)
        {
            bool updated = false;
            foreach (var (from, to, weight) in edges)
            {
                if (distances[from] != INF && distances[from] + weight < distances[to])
                {
                    distances[to] = distances[from] + weight;
                    updated = true;
                }
            }
            if (!updated) break;
        }

        foreach (var (from, to, weight) in edges)
        {
            if (distances[from] != INF && distances[from] + weight < distances[to])
                throw new InvalidOperationException("Negative cycle detected");
        }

        return distances; 
    }
}
