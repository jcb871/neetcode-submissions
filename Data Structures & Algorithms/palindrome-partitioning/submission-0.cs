public class Solution {
    public List<List<string>> Partition(string s) {
        List<List<string>> result = [];
        Partition(s, 0, [], result);
        return result;
    }

    private void Partition(string s, int start, List<string> curr, List<List<string>> result) {
        if(start >= s.Length) {
            result.Add(new(curr));
            return;
        }

        for(int p=start; p<s.Length; p++) {
            if(!IsPalindrome(s, start, p)) continue;
            curr.Add(s.Substring(start, (p-start+1)));
            Partition(s, p+1, curr, result);
            curr.RemoveAt(curr.Count-1);
        }
    }

    private bool IsPalindrome(string s, int start, int end) {
        while(start <= end) {
            if(s[start] != s[end]) return false;
            start++;
            end--;
        }
        return true;
    }
}
