public class Solution {
    public bool IsInterleave(string s1, string s2, string s3) {
        int m=s1.Length, n=s2.Length;
        if(s3.Length != m + n) return false;
        bool?[,] memo = new bool?[m+1, n+1];
        return IsInterleave(s1, s2, s3, currS1:0, currS2: 0, memo);
    }

    private bool IsInterleave(string s1, string s2, string s3, int currS1, int currS2, bool?[,] memo) {
        int m=s1.Length, n=s2.Length;
        if(currS1 == m && currS2 == n) return true;

        if(memo[currS1, currS2].HasValue) return memo[currS1, currS2].Value;

        bool result = false;
        int currS3 = currS1 + currS2;
        if(currS1<m && s3[currS3] == s1[currS1]) {
            result = result || IsInterleave(s1, s2, s3, currS1+1, currS2, memo);
        }
        if(currS2 < n && s3[currS3] == s2[currS2]) {
            result = result || IsInterleave(s1, s2, s3, currS1, currS2+1, memo);
        }
        memo[currS1, currS2] = result;
        return result;
    }
}
