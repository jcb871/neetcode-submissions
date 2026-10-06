public class Solution {
    private static readonly int Limit = int.MaxValue / 10;
    public int Reverse(int x) {
        int num = x / 10;
        int result = x % 10;
        while(num != 0) {
            int digit = num % 10;
            if(result > Limit || result < -Limit) return 0;
            if((digit < -8 || digit > 7) && (result == Limit || result == -Limit)) return 0;
            result *= 10;
            result += digit;            
            num /= 10;
        }

        return result;
    }
}
