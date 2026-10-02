public class Solution {
    public double MyPow(double x, int n) {
        if(n == 0) return 1;
        if(n == int.MinValue) {
            n++;
            return 1 / (x * MyPow(x, -n));
        }
        if(n < 0) return 1 / MyPow(x, -n);

        double half = MyPow(x, n/2);
        return half * half * ((n % 2 == 0)?  1 : x);
    }
}
