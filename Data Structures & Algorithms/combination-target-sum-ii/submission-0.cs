public class Solution {
    public List<List<int>> CombinationSum2(int[] candidates, int target) {
        Array.Sort(candidates);
        List<List<int>> result = [];
        CombinationSum2(candidates, target, position: 0, [], result);
        return result;
    }

    private void CombinationSum2(int[] candidates, int target, int position, List<int> part, List<List<int>> result)
    {
        if(target == 0){
            result.Add(new List<int>(part));
            return;
        }

        for(int p=position; p < candidates.Length; p++) {
            int candidate = candidates[p];

            if(candidate > target) break;

            if(p > position && candidate == candidates[p-1]) continue;

            part.Add(candidate);
            CombinationSum2(candidates, target - candidate, p+1, part, result);
            part.RemoveAt(part.Count-1);
        }
    }
            
}
