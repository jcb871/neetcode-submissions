public class Solution {
    public void islandsAndTreasure(int[][] grid) {
        if(grid == null || grid.Length == 0) return;

        int rows = grid.Length;
        int cols = grid[0].Length;
        Queue<(int r, int c)> q = new (rows * cols);
        for(int r=0; r<rows; r++) {
            for(int c=0; c<cols; c++) {
                if(grid[r][c] == 0) q.Enqueue((r, c));
            }
        }

        int dist = 0;
        while(q.Count > 0) {
            dist++;
            int levelSize = q.Count;
            for(int n=0; n<levelSize; n++) {
                (int row, int col) = q.Dequeue();
                if(SetDist(grid, row-1, col, dist)) q.Enqueue((row-1, col)); //up
                if(SetDist(grid, row+1, col, dist)) q.Enqueue((row+1, col)); //down
                if(SetDist(grid, row, col-1, dist)) q.Enqueue((row, col-1)); //left
                if(SetDist(grid, row, col+1, dist)) q.Enqueue((row, col+1)); //right
            }
        }
    }

    private bool SetDist(int[][] grid, int row, int col, int dist) {
        if(row < 0 || col < 0 || row >= grid.Length || col >= grid[0].Length 
            || grid[row][col] <= dist) return false;

        grid[row][col] = dist;
        return true;
    }
}
