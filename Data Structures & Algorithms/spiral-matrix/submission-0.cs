public class Solution {
    public List<int> SpiralOrder(int[][] matrix) {
        int m = matrix.Length;
        if(m == 0) return [];
        int n = matrix[0].Length;

        int layers = (Math.Min(m,n)+1)/2;
        List<int> result = new(m*n);
        for(int l=0; l<layers; l++) {
            int top=l, left=l, right=n-1-l, bottom=m-1-l;
            for(int c=left; c<=right; c++) {
                result.Add(matrix[top][c]);
            }
            for(int r=top+1; r<=bottom; r++) {
                result.Add(matrix[r][right]);
            }
            if(top != bottom) {
                for(int c=right-1; c>left; c--) {
                    result.Add(matrix[bottom][c]);
                }
            }
            if(left != right) {
                for(int r=bottom; r>top; r--) {
                    result.Add(matrix[r][left]);
                }
            }
        }

        return result;
    }
}
