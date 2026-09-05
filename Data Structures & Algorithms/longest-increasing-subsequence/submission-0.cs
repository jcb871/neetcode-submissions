public class Solution {
    public int LengthOfLIS(int[] nums) {
        int n = nums.Length;
        int[] dp = new int[n];
        int max = 0;
        for(int i=n-1; i>=0; i--) {
            int num = nums[i];
            int count = 1;
            for(int j=i+1; j<n; j++) {
                if(nums[j] <= num) continue;
                if(dp[j] + 1 > count) count = dp[j] + 1;
            }   
            if(max < count) max = count;
            dp[i] = count;
        }

        return max;
    }
}
