using System;
using System.Collections.Generic;

public class Program
{

  static void Main(string[] args)
  {
    
     TryngMaxArea();
    
  }


  public static void TryngMaxArea()
    {
        int[][] grid = new int[][]
        {
            new int[] { 0, 0, 1, 1 },
            new int[] { 0, 1, 1, 1 },
            new int[] { 0, 0, 0, 1 },
            new int[] { 0, 0, 1, 1 }
        };

        int[][] grid2 = new int[][]
        {
            new int[] { 0, 0, 0, 0 },
            new int[] { 0, 0, 0, 1 },
            new int[] { 0, 0, 0, 1 },
            new int[] { 0, 0, 0, 1 }
        };

        var maxArea1 = MaxAreaOfAnIsland(grid);
        Console.WriteLine($"El area maxima del grid es: {maxArea1}");

        var maxArea2 = MaxAreaOfAnIsland(grid2);
        Console.WriteLine($"The max area of the second island is {maxArea2}");
    }

   public static int MaxAreaOfAnIsland(int[][] grid)
    {
        int m = grid.Length;
        int n = grid[0].Length;
        bool[,] visited = new bool[m, n];
        int maxArea = 0;

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (!visited[i, j] && grid[i][j] == 1)
                {
                    int area = DFS_MaxIsland(i, j, visited, grid, m, n);
                    maxArea += Math.Max(maxArea, area);
                }
            }
        }

        return maxArea;
    }

    private static int DFS_MaxIsland(int r, int c, bool[,] visited, int[][] grid, int m, int n)
    {
        if (grid == null || grid.Length == 0 || grid[0].Length == 0)
            return 0;

        if (r < 0 || r >= m || c < 0 || c >= n || visited[r, c] || grid[r][c] != 1)
            return 0;

        int area = 1;
        visited[r, c] = true;

        foreach (var dir in _directions)
        {
            var row = r + dir[0];
            var col = c + dir[1];
            area += DFS_MaxIsland(row, col, visited, grid, m, n);
        }

        return area;
    }

  private static readonly List<int[]> _directions = new List<int[]>()
  {
      new int[] {-1, 0},
      new int[] {1, 0},
      new int[] {0, -1},
      new int[] {0, 1}
  };

  
}