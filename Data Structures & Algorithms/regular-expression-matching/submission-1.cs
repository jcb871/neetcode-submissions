public class Solution {
    public bool IsMatch(string s, string p) {
        int sn = s.Length, pn = p.Length;
        bool?[,] memo = new bool?[sn+1, pn+1];
        return IsMatch(s, p, si:0, pi:0, memo);
    }

    private bool IsMatch(string s, string p, int si, int pi, bool?[,] memo) {
        int sn = s.Length, pn = p.Length;
        if(pi == pn) return si == sn;

        if(memo[si, pi].HasValue) return memo[si, pi].Value;

        bool isFirstMatch = (si < sn) && (p[pi] == '.' || s[si] == p[pi]);

        bool isMatch = false;
        if(pi+1 < pn && p[pi+1] == '*') {
            isMatch = IsMatch(s, p, si, pi+2, memo)
                || (isFirstMatch && IsMatch(s, p, si+1, pi, memo));
        }
        else {
            isMatch = isFirstMatch && IsMatch(s, p, si+1, pi+1, memo);
        }

        memo[si, pi] = isMatch;
        
        return isMatch;
    }
}
