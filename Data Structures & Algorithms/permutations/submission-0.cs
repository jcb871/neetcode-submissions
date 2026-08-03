public class Solution {
    public List<List<int>> Permute(int[] nums) {
        List<List<int>> result = [];
        Permute(nums, new bool [nums.Length], new(nums.Length), result);
        return result;
    }

    private void Permute(int[] nums, bool[] visited, List<int> current, List<List<int>> result)
     {
        if(current.Count == nums.Length) {
            result.Add(new List<int>(current));
            return;
        }
        
        for(int p=0; p<nums.Length; p++) {
            if(visited[p]) continue;
            
            int num = nums[p];
            visited[p] = true;
            current.Add(num);
            Permute(nums, visited, current, result);
            current.RemoveAt(current.Count - 1);
            visited[p] = false;
        }
     }
}
