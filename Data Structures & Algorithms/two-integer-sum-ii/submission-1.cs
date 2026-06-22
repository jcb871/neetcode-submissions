public class Solution {
    public int[] TwoSum(int[] numbers, int target) {
        int start = 0, end = numbers.Length-1;
        while(start<end){
            int n1 = numbers[start];
            int n2 = numbers[end];            
            if(n1 + n2 == target) {
                return [start+1, end+1];
            }
            if(n1 + n2 > target) {
                end--;
            }
            else{
                start++;
            }
        }
        return null;
    }
    
    public int[] TwoSum1(int[] numbers, int target) {
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
