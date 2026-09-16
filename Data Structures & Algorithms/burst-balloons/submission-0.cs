public class Solution {
    public int MaxCoins(int[] nums) {
        int n = nums.Length;
        int[] safeNums = [1, ..nums, 1];
        int?[,] memo = new int?[n+2, n+2];
        return MaxCoins(safeNums, i:0, j:safeNums.Length-1, memo);
    }

    private int MaxCoins(int[] safeNums, int i, int j, int?[,] memo) {

        if(memo[i, j].HasValue) return memo[i, j].Value;

        int maxCoins = 0;
        for(int k=i+1; k<j; k++) {
            int leftMax= MaxCoins(safeNums, i, k, memo);
            int rightMax= MaxCoins(safeNums, k, j, memo);
            int coins = safeNums[i] * safeNums[k] * safeNums[j];
            maxCoins = Math.Max(coins + leftMax + rightMax, maxCoins);
        }
        
        memo[i, j] = maxCoins;

        return maxCoins;
    }
}
