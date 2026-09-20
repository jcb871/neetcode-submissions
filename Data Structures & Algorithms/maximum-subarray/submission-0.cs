public class Solution {
    public int MaxSubArray(int[] nums) {
        int currSum = nums[0];
        int maxSum = currSum;
        int n = nums.Length;
        for(int i=1; i<n; i++) {
            int num = nums[i];
            currSum = Math.Max(currSum + num, num);
            maxSum = Math.Max(maxSum, currSum);
        }

        return maxSum;
    }
}
