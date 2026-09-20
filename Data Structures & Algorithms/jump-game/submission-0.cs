public class Solution {
    public bool CanJump(int[] nums) {
        int n = nums.Length;
        int targetIndex = n-1;
        for(int i=targetIndex-1; i>=0; i--) {
            if(i+nums[i] >= targetIndex) targetIndex = i;
        }
        return targetIndex == 0;
    }
}
