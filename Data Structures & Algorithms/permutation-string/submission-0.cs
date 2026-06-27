public class Solution {
    public bool CheckInclusion(string s1, string s2) {
        if(s1.Length > s2.Length) return false;

        int[] s1Counts = new int[26];
        foreach(char c in s1){
            s1Counts[c - 'a']++;
        }

        int left = 0; 
        int[] s2Counts = new int[26];
        for(int right=0; right < s2.Length; right++) {
            char c = s2[right];
            s2Counts[c-'a']++;
            if(right < s1.Length-1) {
                continue;
            }
            if(s1Counts.SequenceEqual(s2Counts)) return true;
            char l = s2[left];
            s2Counts[l-'a']--;
            left++;
        }
        return false;
    }
}
