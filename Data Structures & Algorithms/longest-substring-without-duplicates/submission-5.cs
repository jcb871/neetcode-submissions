public class Solution {
    public int LengthOfLongestSubstring(string s) {
        int maxLen = 0;
        int startIndex = 0;
        int?[] found = new int?[256];
        for(int i=0; i<s.Length; i++) {
            int c = (int)s[i];
            int? prevIndex = found[c];
            if(prevIndex >= startIndex) {
                startIndex = prevIndex.Value + 1;
            }
            int currLen = i - startIndex + 1;
            if(currLen > maxLen) maxLen = currLen;
            found[c] = i;
        }

        return maxLen;
    }
}
