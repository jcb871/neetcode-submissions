public class Solution {
    public bool CanPartition(int[] nums) {
        int n = nums.Length;
        int totalSum = nums.Sum();
        if(totalSum % 2 == 1) return false;
        int sum = totalSum / 2;
        
        bool[,] dp = new bool[n+1, sum+1];
        for(int i=0; i<=n; i++) dp[i, 0] = true;
                
        for(int i=1; i<=n; i++) {
            int num = nums[i-1];
            for(int j=1; j <= sum; j++) {
                if(j >= num) {
                    dp[i, j] = dp[i-1, j] || dp[i-1, j-num];
                }
                else {
                    dp[i, j] = dp[i-1, j];
                }
            }
        }

        return dp[n, sum];
    }

    // public bool CanPartition(int[] nums) {
    //     int n = nums.Length;
    //     int totalSum = nums.Sum();
    //     if(totalSum % 2 == 1) return false;
    //     int sum = totalSum / 2;
    //     int?[,] memo = new int?[n, sum+1];
    //     return HasSum(nums, 0, sum, memo);
    // }

    // private bool HasSum(int[] nums, int start, int sum, int?[,] memo) {
    //     if(sum == 0) return true;
    //     if(start >= nums.Length || sum < 0) return false;

    //     if(memo[start, sum].HasValue) return memo[start, sum] == 1;

    //     int num = nums[start];
    //     bool result = HasSum(nums, start+1, sum-num, memo) || HasSum(nums, start+1, sum, memo);
    //     memo[start, sum] = result ? 1 : 0;

    //     return result;
    // }
}
