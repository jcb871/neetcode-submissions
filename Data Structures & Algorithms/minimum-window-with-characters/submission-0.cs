public class Solution {
    public string MinWindow(string s, string t) {
        Dictionary<char, int> needs = [];
        foreach(char c in t) {
            _ = needs.TryGetValue(c, out int count);
            needs[c] = count + 1;
        }

        Dictionary<char, int> haves = [];
        int left = 0;
        int need = needs.Count;
        int have = 0;
        int minLen = int.MaxValue;
        int ansStart = 0;
        for(int right = 0; right<s.Length; right++){
            char c = s[right];
            if(!needs.TryGetValue(c, out int needCount)){
                continue;
            }

            _ = haves.TryGetValue(c, out int count);
            haves[c] = ++count;

            if(needCount == count) have++;

            while(need == have) {
                int len = right - left + 1;
                if(len < minLen) { 
                    minLen = len;
                    ansStart = left;
                }
                char removed = s[left];
                left++;

                if(needs.TryGetValue(removed, out int needCountForRemoved) && needCountForRemoved > --haves[removed]) {
                    have--;
                }
            }
        }

        return minLen == int.MaxValue ? "" : s.Substring(ansStart, minLen);
    }
}
