public class Solution {
    public int MinEatingSpeed(int[] piles, int h) {
        int l = 1, r = piles.Max();
        while(l <= r) {
            int mid = l + (r-l) / 2;
            long reqTime = 0;
            foreach(int pile in piles) {
                reqTime += (pile / mid) + (pile % mid == 0? 0 : 1);
            }
            if(reqTime > h) {
                l = mid + 1;
            }
            else if(reqTime <= h) {
                r = mid - 1;
            }
        }
        return l;
    }
}
