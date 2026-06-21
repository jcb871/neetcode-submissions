public class Solution {
    public int[] TopKFrequent(int[] nums, int k) {
        Dictionary<int, int> counts = [];
        foreach(int num in nums){
            if(!counts.ContainsKey(num)) counts[num] = 0;
            counts[num]++;
        }
        List<int>[] countByFrequency = new List<int>[2002];
        foreach(var kv in counts){
            if(countByFrequency[kv.Value] == null){
               countByFrequency[kv.Value]  = new List<int>();
            }
            countByFrequency[kv.Value].Add(kv.Key);
        }
        List<int> result = [];
        for(int i=countByFrequency.Length-1; i>0 && result.Count < k; i--){
            if(countByFrequency[i] == null || countByFrequency[i].Count == 0) continue;            
            result.AddRange(countByFrequency[i]);
        }
        return result.ToArray();
        // return counts
        //     .OrderByDescending(kv=>kv.Value)
        //     .Take(k)
        //     .Select(kv =>kv.Key)
        //     .ToArray();
    }
}
