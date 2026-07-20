public class Solution {
    public int FindDuplicate(int[] nums) {
        int slow = nums[0], fast = nums[0];
        fast = nums[fast];
        while(slow != fast) {
            slow = nums[slow];
            fast = nums[fast];
            fast = nums[fast];
        }
        slow = 0;
        while(slow != fast) {
            slow = nums[slow];
            fast = nums[fast];
        }
        
        return slow;
    }
}
