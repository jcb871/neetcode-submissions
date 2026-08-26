public class Solution {
    public int Rob(int[] nums) {
        int n = nums.Length;
        if(n <= 1) return nums.FirstOrDefault(); 
        int prev2 = nums[0];
        int prev1 = Math.Max(prev2, nums[1]);

        for(int i=2; i<n; i++) {
            int temp = prev1;
            prev1 = Math.Max(prev1, prev2 + nums[i]);
            prev2 = temp;
        }

        return prev1;
    }
}
