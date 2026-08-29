public class Solution {
    public int CountSubstrings(string s) {
        int n = s.Length;
        if(n <= 1) return s.Length;

        int count = 0;
        for(int i=0; i<n; i++) {
            count += IsPalindrome(s, i, i);
            count += IsPalindrome(s, i, i+1);
        }

        return count;
    }

    private int IsPalindrome(string s, int start, int end) {
        int count = 0;

        while(start >= 0 && end < s.Length && s[start] == s[end]) {
            count++;
            start--;
            end++;
        }

        return count;
    }
}
