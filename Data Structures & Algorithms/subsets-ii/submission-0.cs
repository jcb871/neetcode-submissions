public class Solution {
    public List<List<int>> SubsetsWithDup(int[] nums) {
        Array.Sort(nums);
        List<List<int>> result = [];
        Backtrack(nums, position:0, [], result);
        return result;
    }

    private void Backtrack(int[] nums, int position, List<int> current, List<List<int>> result) {
        result.Add(new List<int>(current));

        for(int p=position; p<nums.Length; p++) {
            int num = nums[p];
            if(p > position && nums[p-1] == num) continue;
            current.Add(num);
            Backtrack(nums, p+1, current, result);
            current.RemoveAt(current.Count - 1);
        }
    }
}
