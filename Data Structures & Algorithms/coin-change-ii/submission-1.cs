public class Solution {
    public int Change(int amount, int[] coins) {
        int n = coins.Length;
        int[,] dp = new int[n+1, amount+1];
        for(int i=0; i<=n; i++) {
            dp[i, 0] = 1;
        }
        for(int c=1; c<=n; c++) {
            int coin = coins[c-1];
            for(int j=0; j<=amount; j++) {
                int exclude = dp[c-1, j];

                int include = 0;
                if(coin <= j) {
                    include = dp[c, j-coin];
                }

                dp[c, j] = exclude + include;
            }
        }
        return dp[n, amount];        
    }

    // public int Change1(int amount, int[] coins) {
    //     int n = coins.Length;
    //     int?[,] memo = new int?[n+1, amount+1];
    //     Change(amount, coins, curr:n-1, memo);
    //     return memo[n-1, amount] ?? 0;        
    // }

    // private int Change(int amount, int[] coins, int curr, int?[,] memo) {
    //     if(amount < 0 || curr < 0) return 0;
        
    //     if(amount == 0){
    //         memo[curr, amount] = 1;
    //         return 1;
    //     }

    //     if(memo[curr, amount].HasValue) return memo[curr, amount].Value;

    //     int count = 0;
    //     int coin = coins[curr];
    //     if(amount >= coin) {
    //         count += Change(amount - coin, coins, curr, memo);
    //     }
    //     count += Change(amount, coins, curr-1, memo);
    //     memo[curr, amount] = count;
    //     return count;
    // }
}
