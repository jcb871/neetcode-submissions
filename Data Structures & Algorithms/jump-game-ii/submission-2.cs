public class Solution {
    public int Jump(int[] nums) {
        int n = nums.Length;
        int jumps = 0, l = 0, r = 0;
        while(r < n-1) {
            int farthest = 0;
            for(int i=l; i<=r; i++) {
                int reach = l + nums[l];
                farthest = Math.Max(farthest, reach);
                l++;
            }
            l = r+1;
            r = farthest;
            jumps++;
        }
        return jumps;
    }
}
