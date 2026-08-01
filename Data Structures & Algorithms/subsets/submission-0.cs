public class Solution {
    public List<List<int>> Subsets(int[] nums) {
        List<List<int>> result = [];
        Subsets(nums, 0, result, new List<int>());
        return result;
    }

    private void Subsets(int[] nums, int startIndex, List<List<int>> result, List<int> curr) {
        result.Add(curr.ToList());
        
        for(int i=startIndex; i<nums.Length; i++) {
            int num = nums[i];
            curr.Add(num);
            Subsets(nums, i+1, result, curr);
            curr.Remove(num);
        }
    }
}
