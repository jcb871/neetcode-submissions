public class Solution {
    private int _longestStart;
    private int _longest;
    public string LongestPalindrome(string s) {
        _longestStart = 0;
        _longest = 0;
        int n = s.Length;
        if(n<=1) return s;

        for(int i=0; i<n; i++) { //odd length
            IsPalindrome(s, i, i);
        }
        
        for(int i=0; i<n-1; i++) { //even length
            IsPalindrome(s, i, i+1);
        }
        return s.Substring(_longestStart, _longest);
    }

    private void IsPalindrome(string s, int start, int end) {
        if(start < 0 || end >= s.Length || s[start] != s[end]) return;
        int len = end-start + 1;
        if(_longest < len) { 
            _longest = len;
            _longestStart = start;
        }
        IsPalindrome(s, start-1, end+1);
    }
}
