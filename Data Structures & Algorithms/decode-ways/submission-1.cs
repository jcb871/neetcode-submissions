public class Solution {
    public int NumDecodings(string s) {
        int n = s.Length;
        int[] dp = new int[n+1];
        dp[n] = 1;    
        for(int i=n-1; i>=0; i--) {
            if(s[i] == '0') continue;
            
            dp[i] += 1 * dp[i+1];
            if(i+1 < n && int.Parse(s.Substring(i ,2)) <= 26) {
                dp[i] += 1 * dp[i+2];
            }
        }
        return dp[0];
    }
 
    // private int _numDecodings;
    // public int NumDecodings(string s) {
    //     _numDecodings = 0;
    //     NumDecodings(s, 0);
    //     return _numDecodings;
    // }

    // private void NumDecodings(string s, int start) {
    //     if(start>=s.Length)  {
    //         _numDecodings++;
    //         return;
    //     }

    //     if(s[start] == '0') return;
        
    //     NumDecodings(s, start+1);

    //     if(start+1 < s.Length && int.Parse(s.Substring(start ,2)) <= 26) {
    //         NumDecodings(s, start+2);
    //     }
    // }
}
