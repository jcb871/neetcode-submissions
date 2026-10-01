public class Solution {
    public bool IsHappy(int n) {
        HashSet<int> visitedSums = new(){ n };
        while(n != 1) {
            n = SquareSum(n);
            if(!visitedSums.Add(n)) return false;
        }
        return true;
    }

    private int SquareSum(int n) {
        int sum = 0;
        while(n > 0) {
            int digit = n % 10;
            sum += digit * digit;
            n = n/10;
        }
        return sum;
    }
}
