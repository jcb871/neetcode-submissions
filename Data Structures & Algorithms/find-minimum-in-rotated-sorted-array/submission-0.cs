public class Solution {
    public int FindMin(int[] nums) {
        int l = 0, r= nums.Length-1;

        while(l<r) {
            int mid = l + (r-l)/2;
            int curr = nums[mid];
            int right = nums[r];
            if(curr <= right) {
                r = mid;
            }
            else {
                l = mid + 1;
            }
        }
        return nums[r];
    }
}
