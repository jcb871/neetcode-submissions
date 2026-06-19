public class Solution {
    public bool IsAnagram(string s, string t) {
        if(t.Length != s.Length) return false;
        Dictionary<char, int> charCounts = [];
        foreach(char c1 in s){
            if(!charCounts.ContainsKey(c1)){
                charCounts[c1] = 0;    
            }
            charCounts[c1]++;
        }

        foreach(char c2 in t){
            if(!charCounts.TryGetValue(c2, out int charCount) || charCount == 0) return false;
            charCounts[c2]--;
        }
        return true;
    }
}
