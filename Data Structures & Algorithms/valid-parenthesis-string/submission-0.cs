public class Solution {
    public bool CheckValidString(string s) {
        int minBalance = 0;
        int maxBalance = 0;
        foreach(char c in s) {
            if(c == '(') {
                minBalance++;
                maxBalance++;
            }
            if(c == ')') {
                minBalance--;
                maxBalance--;
            }
            if(c == '*') {                
                minBalance--;
                maxBalance++;
            }
            if(maxBalance < 0) return false;
            if(minBalance < 0) minBalance = 0;
        }

        return minBalance == 0;
    }
}
