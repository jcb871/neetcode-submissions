public class Solution {
    public int Change(int amount, int[] coins) {
        int n = coins.Length;
        int?[,] memo = new int?[n+1, amount+1];
        Change(amount, coins, curr:n-1, memo);
        return memo[n-1, amount] ?? 0;        
    }

    private int Change(int amount, int[] coins, int curr, int?[,] memo) {
        if(amount < 0 || curr < 0) return 0;
        
        if(amount == 0){
            memo[curr, amount] = 1;
            return 1;
        }

        if(memo[curr, amount].HasValue) return memo[curr, amount].Value;

        int count = 0;
        int coin = coins[curr];
        if(amount >= coin) {
            count += Change(amount - coin, coins, curr, memo);
        }
        count += Change(amount, coins, curr-1, memo);
        memo[curr, amount] = count;
        return count;
    }
}
