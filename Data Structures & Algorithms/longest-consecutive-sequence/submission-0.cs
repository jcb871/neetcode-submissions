public class Solution {
    public int LongestConsecutive(int[] nums) {
        if(nums.Length == 0) return 0;
        HashSet<int> allNums = nums.ToHashSet();
        int maxLength = 1;
        foreach(int num in nums){
            if(allNums.Contains(num-1)) continue;
            int length = 1;
            int curr = num;
            while(allNums.Contains(curr+1)){
                length++;
                curr += 1;
            }
            
            if(length > maxLength) maxLength = length;
        }
        return maxLength;
    }

    // private int GetMaxLen(HashSet<int> nums, Dictionary<int, int> visited, int current) {
    //     if(visited.TryGetValue(current, out int length)) return length;

    //     // int belowLen = 0;
    //     // if(nums.Contains(current-1)) {
    //     //     belowLen = GetMaxLen(nums, visited, current-1);
    //     // }

    //     int aboveLen = 0;
    //     if(nums.Contains(current+1)) {
    //         aboveLen = GetMaxLen(nums, visited, current+1);
    //     }

    //     visited[current] = 1 + aboveLen;
    //     return visited[current];
    // }
}
