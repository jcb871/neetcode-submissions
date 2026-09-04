public class Solution {
    public bool WordBreak(string s, List<string> wordDict) {
        int n = s.Length;
        if(n == 0) return true;

        HashSet<string> words = new (wordDict);
        bool[] dp = new bool[n+1];
        dp[n] = true;
        for(int i=n-1; i>=0; i--) {
            for(int j=n-1; j>=i; j--) {
                string word = s.Substring(i, j-i+1);
                if(words.Contains(word) && dp[j+1]){
                    dp[i] = true;
                    break; //Found a valid words from i to end. No need to explore further from i.
                } 
            }
        }
        return dp[0];
    }

    // public bool WordBreak(string s, List<string> wordDict) {
    //     int n = s.Length;
    //     if(n == 0) return true;

    //     HashSet<string> words = new (wordDict);
    //     bool?[] memo = new bool?[n];
    //     return WordBreak(s, start:0, words, memo);
    // }

    // private bool WordBreak(string s, int start, HashSet<string> words, bool?[] memo) 
    // {    
    //     int n = s.Length;
    //     if(start >= n) return true;        
    //     if(memo[start].HasValue) return memo[start].Value;

    //     for(int j=start; j<n; j++) {
    //         string word = s.Substring(start, j-start+1);
    //         if(words.Contains(word) && WordBreak(s, j+1, words, memo)){
    //             memo[start] = true;
    //             return true;
    //         } 
    //     }
        
    //     memo[start] = false;
    //     return false;
    // }
}
