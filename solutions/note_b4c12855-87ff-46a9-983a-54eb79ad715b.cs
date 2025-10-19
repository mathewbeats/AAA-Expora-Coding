using System;
using System.Collections.Generic;

public class BellmanFordAlgorithm
{
    private const int InfiniteDistance = int.MaxValue / 2;

    public static void Main(string[] args)
    {
        Console.WriteLine("\nBellman Ford Algorithm\n");

        var graph = new List<(int From, int To, int Weight)>
        {
            (0, 1, 4),
            (0, 2, 2),
            (1, 3, 5),
            (2, 1, 1),
            (2, 3, 8)
        };

        var distances = CalculateDistances(graph, source: 0);

        Console.WriteLine("Shortest distances from the source:");
        for (int i = 0; i < graph.Count; i++)
        {
            Console.WriteLine($"{i}: {distances[i] == InfiniteDistance ? "Infinito" : distances[i]}");
        }
    }

    private static int[] CalculateDistances(List<(int From, int To, int Weight)> edges, int source)
    {
        int n = edges.Max(edge => Math.Max(edge.From, edge.To)) + 1;
        var distances = new int[n];
        Array.Fill(distances, InfiniteDistance);
        distances[source] = 0;

        for (int i = 0; i < n - 1; i++)
        {
            foreach (var edge in edges)
            {
                if (distances[edge.From] != InfiniteDistance && 
                    distances[edge.From] + edge.Weight < distances[edge.To])
                {
                    distances[edge.To] = distances[edge.From] + edge.Weight;
                }
            }
        }

        // Optional: Detect negative cycles
        foreach (var edge in edges)
        {
            if (distances[edge.From] != InfiniteDistance && 
                distances[edge.From] + edge.Weight < distances[edge.To])
            {
                throw new Exception("Negative cycle detected");
            }
        }

        return distances;
    }
}