public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        for(int i=0; i<nums.Length;i++) {
        int num1 = nums[i];
            for(int j=i+1; j<nums.Length;j++) {
                if(nums[j] + num1 == target) {
                    return new[]{i, j};
                }
            }
        }
        return new[]{-1, -1};
    }
}
