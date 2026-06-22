public class Solution {
    public int[] TwoSum(int[] numbers, int target) {
        Dictionary<int, int> numIndex = [];
        for(int i=0; i<numbers.Length; i++){
            if(numIndex.TryGetValue(target-numbers[i], out int firstIndex)){
                return [firstIndex+1, i+1];
            }
            numIndex[numbers[i]] = i;
        }
        return null;
    }
}
