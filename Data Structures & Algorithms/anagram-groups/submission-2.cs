public class Solution {
    public List<List<string>> GroupAnagrams(string[] strs) {
        Dictionary<string, List<string>> anagramSubList = [];
        foreach(string str in strs){
            int[] counts = new int[26];
            foreach(char c in str) {
                if(c < 'a' || c > 'z') throw new Exception("Invalid character");
                int charIndex = c - 'a';
                counts[charIndex]++;
            }
            string id = string.Join(",", counts);
            if(!anagramSubList.TryGetValue(id, out List<string> subList)){
                subList = [];
                anagramSubList[id] = subList;
            }
            subList.Add(str);
        }
        return anagramSubList.Values.ToList();
    }
}
