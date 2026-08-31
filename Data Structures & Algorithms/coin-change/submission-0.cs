public class Solution {
    public int CoinChange(int[] coins, int amount)  {
        int[] dp = new int[amount+1];
        Array.Fill(dp, int.MaxValue);
        dp[0] = 0;
        for(int i=1; i<=amount;i++) {
            foreach(int coin in coins) {
                if(coin <= i && dp[i-coin] != int.MaxValue) dp[i] = Math.Min(dp[i], dp[i-coin] + 1);
            }
        }
        return dp[amount] == int.MaxValue ? -1 : dp[amount];
    }
}