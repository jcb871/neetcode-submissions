public class Solution {
    public bool SearchMatrix(int[][] matrix, int target) {
        int rows = matrix.Length;
        if(rows == 0) return false;
        int cols = matrix[0].Length;
        //find row by binary search
        int mid = 0;
        int l = 0, r = rows-1;
        while(l <= r) {
            mid = l + (r-l)/2;
            int midValueStart = matrix[mid][0];
            int midValueEnd = matrix[mid][cols-1];
            if(midValueStart <= target && midValueEnd >= target) {
                break;
            }
            if(midValueStart < target && midValueEnd < target) {
                l = mid + 1;
            }
            else if(midValueStart > target && midValueEnd > target) {
                r = mid - 1;
            }
        }
        if(l > r) return false;

        //find cell by binary search        
        int row = mid;
        l = 0;
        r = cols-1;
        while (l <= r) {
            mid = l + (r-l) /2;
            int curr = matrix[row][mid];
            if(curr < target) {
                l = mid + 1;
            }
            else if (curr > target) {
                r = mid - 1;
            }
            else {
                return true;
            }
        }
        return false;
    }
}
