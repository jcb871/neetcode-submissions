public class Solution {
    public int LengthOfLongestSubstring(string s) {
        int maxLen = 0;
        Dictionary<char, int> found = [];
        int currLen = 0;
        int startIndex = 0;
        for(int i=0; i<s.Length; i++) {
            char c = s[i];
            if(found.TryGetValue(c, out int prevIndex) && prevIndex >= startIndex) {
                startIndex = prevIndex + 1;
                currLen = i - startIndex + 1;
            }
            else {
                currLen++;
            }
            if(currLen > maxLen) maxLen = currLen;
            found[c] = i;
        }

        return maxLen;
    }
}
