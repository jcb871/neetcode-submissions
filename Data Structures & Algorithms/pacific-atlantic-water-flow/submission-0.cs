public class Solution {
    public List<List<int>> PacificAtlantic(int[][] heights) {
        if(heights == null || heights.Length == 0 || heights[0].Length == 0) return [];
        int rows = heights.Length;
        int cols = heights[0].Length;

        bool[,] pacificReachable = new bool[rows, cols];
        bool[,] atlanticReachable = new bool[rows, cols];

        for(int r=0; r<rows; r++) {
            Dfs(heights, r, 0, pacificReachable, rows, cols);
        }
        for(int c=1; c<cols; c++) {
            Dfs(heights, 0, c, pacificReachable, rows, cols);
        }

        for(int r=0; r<rows; r++) {
            Dfs(heights, r, cols-1, atlanticReachable, rows, cols);
        }
        for(int c=0; c<cols-1; c++) {
            Dfs(heights, rows-1, c, atlanticReachable, rows, cols);
        }

        List<List<int>> result = new (rows * cols);
        for(int r=0; r<rows; r++) {
            for(int c=0; c<cols; c++) {
                if(pacificReachable[r, c] && atlanticReachable[r, c]) result.Add([r, c]);
            }
        }

        return result;
    }
    
    private void Dfs(int[][] heights, int row, int col, bool[,] visited, int rows, int cols, int lastHeight = int.MinValue) {
        if(row < 0 || row >= rows || col < 0 || col >= cols 
            || visited[row, col]
            || heights[row][col] < lastHeight) return;

        visited[row, col] = true;

        Dfs(heights, row-1, col, visited, rows, cols, heights[row][col]); //up
        Dfs(heights, row+1, col, visited, rows, cols, heights[row][col]); //down
        Dfs(heights, row, col-1, visited, rows, cols, heights[row][col]); //left
        Dfs(heights, row, col+1, visited, rows, cols, heights[row][col]); //right
    }
}
