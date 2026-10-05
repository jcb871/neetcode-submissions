public class Solution {
    public int HammingWeight(uint n) {
        int count = 0;
        while(n > 0) {
            n &= (n-1); //clears rightmost 1-bit
            count++;
        }
        return count;
    }

    public int HammingWeight1(uint n) {
        int count = 0;
        while(n > 0) {
            if((n & 1) != 0) count++;
            n >>= 1; //shift rightmost bit right
        }
        return count;
    }
}
