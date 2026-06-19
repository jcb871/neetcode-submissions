public class Solution {
    public bool IsAnagram(string s, string t) {
        if(t.Length != s.Length) return false;
        Dictionary<char, int> charCounts = [];
        foreach(char c1 in s){
            charCounts[c1] = 1 + (charCounts.ContainsKey(c1) ? charCounts[c1] : 0);
        }

        foreach(char c2 in t){
            if(!charCounts.ContainsKey(c2)) return false;
            if(charCounts[c2] == 0) return false;
            charCounts[c2]--;
        }
        return true;
    }
}
