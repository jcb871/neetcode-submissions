public class Solution {
    public List<List<int>> ThreeSum(int[] nums) {
        Array.Sort(nums);
        List<List<int>> result = [];
        for(int i=0; i<nums.Length;i++){            
            int num1 = nums[i];
            if(i>0 && num1==nums[i-1]) {
                continue;
            }
            GetTwoSum(nums, i+1, num1, result);
            // List<int[]> twoSums = GetTwoSum(nums, i+1, -num1);
            // foreach(int[] twoSum in twoSums){
            //     result.Add([num1, twoSum[0], twoSum[1]]);
            // }
        }
        return result;
    }

    public void GetTwoSum(int[] nums, int start, int num1, List<List<int>> result) {
        int end = nums.Length - 1;
        while(start < end){
            int num2 = nums[start], num3 = nums[end];
            int sum = num1 + num2 + num3;
            if(sum == 0) {
                result.Add([num1, num2, num3]);
                do {
                    start++;
                }
                while(start+1 < end && nums[start] == nums[start-1]);
                do {
                    end--;
                }
                while(end-1 > start && nums[end] == nums[end+1]);
            }
            else if(sum < 0) {
                start++;
            }
            else {
                end--;
            }
        }
    }
}
