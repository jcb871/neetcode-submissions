public class Solution {
    public int CharacterReplacement(string s, int k) {
        int left = 0;
        int[] counts = new int[26];
        int maxCount = 0;
        for(int right=0; right < s.Length; right++) {
            maxCount = Math.Max(maxCount, ++counts[s[right]-'A']);
            int len  = right - left + 1;
            if (len  - maxCount > k){
                char lc = s[left];
                counts[lc-'A']--;
                left++;
            }
        }

        return s.Length-left;
    }
}
