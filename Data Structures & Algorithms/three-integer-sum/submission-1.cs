public class Solution {
    public List<List<int>> ThreeSum(int[] nums) {
        Array.Sort(nums);
        List<List<int>> result = [];
        for(int i=0; i<nums.Length;i++){            
            int num1 = nums[i];
            if(i>0 && num1==nums[i-1]) {
                continue;
            }
            List<int[]> twoSums = GetTwoSum(nums, i+1, -num1);
            foreach(int[] twoSum in twoSums){
                result.Add([num1, twoSum[0], twoSum[1]]);
            }
        }
        return result;
    }

    public List<int[]> GetTwoSum(int[] nums, int start, int target) {
        int end = nums.Length - 1;
        Dictionary<string, int[]> result = [];
        while(start < end){
            int num2 = nums[start], num3 = nums[end];
            int sum = num2 + num3;
            if(sum == target) {
                result[num2 + ","+ num3] = [num2, num3];
                start++;
                end--;
            }
            else if(sum < target) {
                start++;
            }
            else {
                end--;
            }
        }
        return result.Values.ToList();
    }
}
