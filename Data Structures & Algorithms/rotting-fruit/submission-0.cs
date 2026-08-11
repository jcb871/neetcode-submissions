public class Solution {
    public const int Empty = 0;
    public const int Fresh = 1;
    public const int Rotten = 2;
    public int OrangesRotting(int[][] grid) {
        if(grid == null || grid.Length == 0) return 0;
        int rows = grid.Length;
        int cols = grid[0].Length;
        Queue<(int r, int c)> q = new();
        for(int r=0; r<rows; r++) {
            for(int c=0; c<cols; c++) {
                if(grid[r][c] == Rotten) q.Enqueue((r, c));
            }
        }

        int time = 0;
        while(q.Count > 0) {
            int levelSize = q.Count;
            for(int v=0; v<levelSize; v++) {
                (int row, int col) = q.Dequeue();
                if(SetRotten(grid, row-1, col)) q.Enqueue((row-1, col)); //up
                if(SetRotten(grid, row+1, col)) q.Enqueue((row+1, col)); //down
                if(SetRotten(grid, row, col-1)) q.Enqueue((row, col-1)); //left
                if(SetRotten(grid, row, col+1)) q.Enqueue((row, col+1)); //right
            }
            if(q.Count > 0) time++;
        }
        for(int r=0; r<rows; r++) {
            for(int c=0; c<cols; c++) {
                if(grid[r][c] == Fresh) return -1;
            }
        }
        return time;
    }

    private bool SetRotten(int[][] grid, int row, int col) {
        if(row < 0 || col < 0 
            || row >= grid.Length || col >= grid[0].Length 
            || grid[row][col] != Fresh) return false;

        grid[row][col] = Rotten;
        return true;
    }
}
