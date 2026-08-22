public class Solution {
    public int SwimInWater(int[][] grid) {
        int n = grid.Length;
        int left = 0, right = (n * n) - 1;
        while(left <= right) {
            int mid = left + (right-left) / 2;
            bool[,] visited = new bool[n, n]; 
            bool canReach = Dfs(grid, level: mid, visited);
            if(canReach) {
                right = mid - 1;
            }
            else{
                left = mid + 1;
            }
        }
        return left;
    }

    private bool Dfs(int[][] grid, int level, bool[,] visited, int r = 0, int c = 0) {
        int n = grid.Length;
        if(r < 0 || c < 0 || r >= n || c >= n || visited[r, c] || grid[r][c] > level) return false;

        if(r == n-1 && c == n-1) return true;
        
        visited[r, c] = true;

        //explore up, left, down, and right positions
        bool canReach = Dfs(grid, level, visited, r-1, c) 
            || Dfs(grid, level, visited,  r, c-1) 
            || Dfs(grid, level, visited, r+1, c) 
            || Dfs(grid, level, visited, r, c+1);
        
        return canReach;
    }
}
