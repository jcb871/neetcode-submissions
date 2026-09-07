public class Solution {
    public int UniquePaths(int m, int n) {
        int[] dp = new int[n+1];
        for(int c=1; c<=n; c++) dp[c] = 1;
        for(int r=2;r<=m; r++) {
            for(int c=2; c<=n; c++) {
                dp[c] = dp[c] + dp[c-1];
            }
        }
        return dp[n];
    }

    // public int UniquePaths2(int m, int n) {
    //     int[,] dp = new int[m+1,n+1];
    //     for(int r=1; r<=m; r++) dp[r,1] = 1;
    //     for(int c=1; c<=n; c++) dp[1, c] = 1;
    //     for(int r=2;r<=m; r++) {
    //         for(int c=2; c<=n; c++) {
    //             dp[r, c] = dp[r-1, c] + dp[r, c-1];
    //         }
    //     }
    //     return dp[m, n];
    // }

    // public int UniquePaths1(int m, int n) {
    //     int?[,] memo = new int?[m+1,n+1];
    //     int paths = CountPaths(m, n, memo);
    //     return memo[m, n].Value;
    // }

    // private int CountPaths(int m, int n, int?[,] memo) {
    //     if(m<=0 || n<= 0) return 0;

    //     if(m == 1 || n == 1) return 1;

    //     if(memo[m, n].HasValue) return memo[m, n].Value;

    //     memo[m, n] = CountPaths(m-1, n, memo) + CountPaths(m, n-1, memo);
        
    //     return memo[m, n].Value;
    // }
}
