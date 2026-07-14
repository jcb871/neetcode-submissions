public class Solution {
    public int Search(int[] nums, int target) {
        int l=0, r=nums.Length-1;
        while(l<=r){
            int m = l + (r-l)/2;
            int left = nums[l], mid = nums[m], right = nums[r];
            if(mid == target){
                return m;
            }
            if(left <= mid) { //left is sorted 
                if(left <= target && target <= mid) {
                    r = m-1;
                }
                else {                    
                    l = m+1;
                }
            }
            else //right is sorted
            {
                if(mid <= target && target <= right) {
                    l = m+1;
                }
                else {
                    r = m-1;                    
                }
            }
        }
        return -1;
    }
}
