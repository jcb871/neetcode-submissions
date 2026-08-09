public class Solution {
    public int NumIslands(char[][] grid) {
        int islands = 0;
        int rows = grid.Length;
        if(rows == 0) return islands;
        int cols = grid[0].Length;

        for(int r=0; r<rows; r++) {
            for(int c=0; c<cols; c++) {
                if(Dfs(grid, r, c, rows, cols)) islands++;
            }
        }
        return islands;
    }

    private bool Dfs(char[][] grid, int row, int col, int rowCount, int colCount) {
        if(row < 0 || row >= rowCount || col < 0 || col >= colCount || grid[row][col] == '0') return false;

        grid[row][col] = '0';
        Dfs(grid, row-1, col, rowCount, colCount); //up
        Dfs(grid, row+1, col, rowCount, colCount); //down
        Dfs(grid, row, col-1, rowCount, colCount); //left
        Dfs(grid, row, col+1, rowCount, colCount); //right
        return true;
    }
}
