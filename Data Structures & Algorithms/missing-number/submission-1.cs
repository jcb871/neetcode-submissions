public class Solution {
    public int MissingNumber(int[] nums) {
        int n = nums.Length;
        int expectedSum = n * (n+1) / 2;
        int sum = nums[0];
        foreach(int num in nums) {
            expectedSum -= num;
        }
        return expectedSum;
    }
}
