public class Solution {
    public int MinCostClimbingStairs(int[] cost) {
        int n = cost.Length;
        if(n < 2) return 0;

        int prev2 = cost[0];
        int prev1 = cost[1];
        
        for(int i=2; i<n; i++) {
            int temp = prev1;
            prev1 = cost[i] + Math.Min(prev2, prev1);
            prev2 = temp;
        }
        
        return Math.Min(prev2, prev1);
    }
}
