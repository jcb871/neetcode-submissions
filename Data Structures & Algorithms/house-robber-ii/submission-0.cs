public class Solution {
    public int Rob(int[] nums) {
        int n = nums.Length;
        if(n <= 1) return nums.FirstOrDefault();

        return Math.Max(Rob(nums, 0, n-1), Rob(nums, 1, n));
    }

    private int Rob(int[] nums, int start, int end) {
        if(end-start <= 1)  return nums[start];

        int prev2 = nums[start];
        int prev1 = Math.Max(nums[start], nums[start+1]);

        for(int i=start+2; i<end; i++) {
            int temp = prev1;
            prev1= Math.Max(prev1, nums[i] + prev2);
            prev2 = temp;
        }
        return prev1;
    }
}
