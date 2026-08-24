public class Solution {
    public int ClimbStairs(int n) {   
        if(n <2) return n;  
        long first = 1;
        long second = 2;
        for(int i=3; i<= n; i++) {
            long temp = second;
            second = first + second;
            first = temp;
        }

        return (int)second;
    }
}
