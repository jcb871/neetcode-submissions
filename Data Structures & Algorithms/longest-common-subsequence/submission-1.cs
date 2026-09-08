public class Solution {
    public int LongestCommonSubsequence(string text1, string text2) {
        int m=text1.Length;
        int n=text2.Length;

        int[,] dp = new int[m+1, n+1];
        for(int i=1; i<=m; i++) {
            for(int j=1; j<=n; j++) {
                if(text1[i-1] == text2[j-1]) {
                    dp[i, j] = 1 + dp[i-1, j-1];
                }
                else{
                    dp[i, j] = Math.Max(dp[i-1, j], dp[i, j-1]);
                }
            }
        }
        return dp[m, n];
    }

    // public int LongestCommonSubsequence1(string text1, string text2) {
    //     int m=text1.Length;
    //     int n=text2.Length;

    //     int?[,] memo = new int?[m+1, n+1];
    //     return LongestCommonSubsequence(text1, text2, p1:m-1, p2:n-1, memo);
    // }

    // private int LongestCommonSubsequence(string text1, string text2, int p1, int p2, int?[,] memo)
    // {
    //     if(p1 < 0 || p2 < 0) return 0;

    //     if(memo[p1+1, p2+1].HasValue) return memo[p1+1, p2+1].Value;

    //     int result;
    //     if(text1[p1] == text2[p2]) {
    //         result = 1 + LongestCommonSubsequence(text1, text2, p1-1, p2-1, memo);
    //     }
    //     else{
    //         result = Math.Max(LongestCommonSubsequence(text1, text2, p1, p2-1, memo), LongestCommonSubsequence(text1, text2, p1-1, p2, memo));
    //     }
    //     memo[p1+1, p2+1] = result;

    //     return result;
    // }
}
