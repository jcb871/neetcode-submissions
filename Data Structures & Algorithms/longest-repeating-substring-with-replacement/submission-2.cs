public class Solution {
    public int CharacterReplacement(string s, int k) {
        int left = 0;
        int right = 0;
        int maxLength = 0;
        int[] counts = new int[26];
        int maxCount = 0;
        while(right < s.Length) {
            int len  = right - left + 1;
            char rc = s[right];
            int count = ++counts[rc-'A'];
            if(count > maxCount) maxCount = count;
            if(len  - maxCount <= k) {
                if(maxLength < len) maxLength = len;
            }
            else{
                char lc = s[left];
                counts[lc-'A']--;
                left++;
            }
            right++;
        }

        return maxLength;
    }
}
