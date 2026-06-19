public class Solution {
    public int[] TopKFrequent(int[] nums, int k) {
        Dictionary<int, int> counts = [];
        foreach(int num in nums){
            if(!counts.ContainsKey(num)) counts[num] = 0;
            counts[num]++;
        }
        return counts
            .OrderByDescending(kv=>kv.Value)
            .Take(k)
            .Select(kv =>kv.Key)
            .ToArray();
    }
}
