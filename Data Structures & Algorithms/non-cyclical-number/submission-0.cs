public class Solution {
    public bool IsHappy(int n) {
        HashSet<int> visitedSums = new(){ n };
        do {
            n = SquareSum(n);
            if(n != 1 && visitedSums.Contains(n)) return false;
            visitedSums.Add(n);
        }
        while(n != 1);
        return n == 1;
    }

    private int SquareSum(int n) {
        int sum = 0;
        while(n >= 10) {
            int remainder = n % 10;
            sum += remainder * remainder;
            n = n/10;
        }
        sum += n * n;
        return sum;
    }
}
