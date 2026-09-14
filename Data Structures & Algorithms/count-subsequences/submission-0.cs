public class Solution {
    public int NumDistinct(string s, string t) {
        int sn= s.Length, tn = t.Length;
        if(sn < tn) return 0;

        long?[,] memo = new long?[sn, tn];

        return (int)NumDistinct(s, t, si:0, ti:0, memo);
    }

    private long NumDistinct(string s, string t, int si, int ti, long?[,] memo) {
        int sn = s.Length, tn = t.Length;
        if(ti == tn) {
            return 1;
        }
        if(si == sn || sn-si < tn-ti) return 0;

        if(memo[si, ti].HasValue) return memo[si, ti].Value;

        long result = 0;
        //use current char
        if(s[si] == t[ti]) {
            result += NumDistinct(s, t, si+1, ti+1, memo);
        }
        //skip current char
        result += NumDistinct(s, t, si+1, ti, memo);
        
        memo[si, ti] = result;

        return result;
    }
}
