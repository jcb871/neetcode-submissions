public class Solution {
    public int MaxAreaOfIsland(int[][] grid) {
        int maxArea = 0;
        int rowCount = grid.Length;
        if(rowCount == 0) return maxArea;
        int colCount = grid[0].Length;

        for(int r=0; r<rowCount; r++) {
            for(int c=0; c<colCount; c++) {
                if(grid[r][c] == 1) {
                    int area = Dfs(grid, r, c);
                    if(maxArea < area) maxArea = area;
                }
            }
        }
        return maxArea;
    }

    private int Dfs(int[][] grid, int row, int col) {
        if(row < 0 || row >= grid.Length || col < 0 || col >= grid[0].Length || grid[row][col] != 1)
            return 0;

        grid[row][col] = 0;

        int area = 1
        + Dfs(grid, row-1, col) //up
        + Dfs(grid, row+1, col) //down
        + Dfs(grid, row, col-1) //left
        + Dfs(grid, row, col+1); //right
        return area;
    }
}
