public class Solution {
    public List<int> SpiralOrder(int[][] matrix) {
        int m = matrix.Length;
        if(m == 0) return [];
        int n = matrix[0].Length;

        List<int> result = new(m*n);
        int top=0, left=0, right=n-1, bottom=m-1;

        while(top <= bottom && left <= right) {
            for(int c=left; c<=right; c++) {
                result.Add(matrix[top][c]);
            }
            top++;

            for(int r=top; r<=bottom; r++) {
                result.Add(matrix[r][right]);
            }
            right--;

            if(top <= bottom) {
                for(int c=right; c>=left; c--) {
                    result.Add(matrix[bottom][c]);
                }
                bottom--;
            }

            if(left <= right) {
                for(int r=bottom; r>=top; r--) {
                    result.Add(matrix[r][left]);
                }
                left++;
            }
        }

        return result;
    }
}
