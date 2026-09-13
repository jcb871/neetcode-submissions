public class Solution {
    public int LongestIncreasingPath(int[][] matrix) {
        int rows=matrix.Length;
        if(rows == 0) return 0;
        int cols = matrix[0].Length;

        int?[,] memo = new int?[rows,cols];
        int maxLength = 0;
        for(int r=0; r<rows; r++) {
            for(int c=0; c<cols; c++) {
                maxLength = Math.Max(maxLength, Backtrack(matrix, r, c, memo));
            }
        }

        return maxLength;
    }

    private int Backtrack(int[][] matrix, int r, int c, int?[,] memo) {
        int rows=matrix.Length;
        int cols = matrix[0].Length;
        if(r<0 || c<0 || r >= rows || c >= cols) return 0;

        if(memo[r, c].HasValue) return memo[r,c].Value;

        int maxLength = 1;
        int curr = matrix[r][c];
        if(r > 0 && curr < matrix[r-1][c]) { //up
            maxLength = Math.Max(1 + Backtrack(matrix, r-1, c, memo), maxLength);
        }
        if(c > 0 && curr < matrix[r][c-1]) { //left
            maxLength = Math.Max(1 + Backtrack(matrix, r, c-1, memo), maxLength);
        }
        if(r+1 < rows && curr < matrix[r+1][c]) { //down
            maxLength = Math.Max(1 + Backtrack(matrix, r+1, c, memo), maxLength);
        }
        if(c+1 < cols && curr < matrix[r][c+1]) { //right
            maxLength = Math.Max(1 + Backtrack(matrix, r, c+1, memo), maxLength);
        }

        memo[r, c] = maxLength;
        return maxLength;
    }
}
