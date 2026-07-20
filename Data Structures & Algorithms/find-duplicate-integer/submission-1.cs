public class Solution {
    public int FindDuplicate(int[] nums) {
        int left=1, right = nums.Length;

        while(left < right) {
            int mid = left + (right - left) /2;

            int countLeft = nums.Count(n=> n <= mid);
            if(countLeft > mid) {
                right = mid;
            }
            else {
                left = mid+1;
            }
        }

        return left;
    }

    // public int FindDuplicate(int[] nums) {
    //     int slow = nums[0], fast = nums[0];
    //     fast = nums[fast];
    //     while(slow != fast) {
    //         slow = nums[slow];
    //         fast = nums[fast];
    //         fast = nums[fast];
    //     }
    //     slow = 0;
    //     while(slow != fast) {
    //         slow = nums[slow];
    //         fast = nums[fast];
    //     }
        
    //     return slow;
    // }
}
