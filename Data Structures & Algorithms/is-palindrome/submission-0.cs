public class Solution {
    public bool IsPalindrome(string s) {
        int start = 0, end = s.Length-1;
        while(start <end){
            char cLeft = s[start];
            if(!char.IsLetterOrDigit(cLeft)) {
                start++;
                continue;
            }
            char cRight = s[end];
            if(!char.IsLetterOrDigit(cRight)) {
                end--;
                continue;
            }
            if(char.ToUpperInvariant(cLeft) != char.ToUpperInvariant(cRight)) return false;

            start++;
            end--;
        }
        return true;
    }
}
