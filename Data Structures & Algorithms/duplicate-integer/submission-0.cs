public class Solution {
    public bool hasDuplicate(int[] nums) {
        HashSet<int> existing = [];
        foreach(int num in nums){
            if(existing.Contains(num)) return true;
            existing.Add(num);
        }
        return false;
    }
}