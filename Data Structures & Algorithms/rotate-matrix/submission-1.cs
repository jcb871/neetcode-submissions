public class Solution {
    public void Rotate(int[][] matrix) {
        int n = matrix.Length;
        if(n == 1) return;
        int layers = n/2;
        for(int l=0; l<layers; l++) {            
            int top = l, left=l, right = n-1-l, bottom = n-1-l;
            for(int i=0; i<right-left; i++) {
                int temp = matrix[top][left+i];
                matrix[top][left+i] = matrix[bottom-i][left]; //left edge to top edge

                matrix[bottom-i][left] = matrix[bottom][right-i]; //bottom edge to left edge

                matrix[bottom][right-i] = matrix[top+i][right]; //right edge to bottom edge

                matrix[top+i][right] = temp; //top left edge to top right edge                
            }
        }
    }
}
