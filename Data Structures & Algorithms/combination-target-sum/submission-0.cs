public class Solution {
    public List<List<int>> CombinationSum(int[] nums, int target) {
        List<List<int>> result = [];
        Array.Sort(nums);
        CombinationSum(nums, target, 0, [], result);
        return result;
    }

    private void CombinationSum(int[] nums, int target, int position, List<int> part, List<List<int>> result) {
        if(target == 0) {
            result.Add(part.ToList());
            return;
        }
            
        for(int i=position; i<nums.Length; i++) {
            int num = nums[i];

            if(num > target) break;

            part.Add(num);
            CombinationSum(nums, target - num, i, part, result);
            part.RemoveAt(part.Count-1);
        }
    }
}
