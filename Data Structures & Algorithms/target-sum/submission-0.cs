public class Solution {
    public int FindTargetSumWays(int[] nums, int target) {
        Dictionary<(int, int), int> ways = new();
        return FindWays(nums, target, curr:0, ways);
    }

    private int FindWays(int[] nums, int target, int curr, Dictionary<(int, int), int> ways) {
        if(target == 0 && curr == nums.Length) {
            return 1;
        }

        if(curr >= nums.Length) return 0;

        int currWays = 0;
        if(ways.TryGetValue((curr, target), out currWays)) return currWays;

        currWays = FindWays(nums, target-nums[curr], curr+1, ways);
        currWays += FindWays(nums, target+nums[curr], curr+1, ways);

        ways[(curr, target)] = currWays;
        return currWays;
    }
}
