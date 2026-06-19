public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        Dictionary<int, int> sumPair = [];
        for(int i=0; i<nums.Length; i++) {
            int num = nums[i];
            if(sumPair.TryGetValue(target-num, out int index1)){
                return [index1, i];
            }
            sumPair.Add(num, i);
        }
        return new[]{-1, -1};
    }
}
