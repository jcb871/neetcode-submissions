public class Solution {
    public int MinCostClimbingStairs(int[] cost) {
        int n = cost.Length;
        int first = cost[0];
        int second = cost[1];
        for(int i=2; i<=n; i++) {
            int currCost = (i == n)? 0 : cost[i];
            int temp = second;
            second = currCost + Math.Min(first, second);
            first = temp;
        }
        return second;
    }

    // public int MinCostClimbingStairs(int[] cost) {
    //     int n = cost.Length;
    //     int[] memo = new int[n+1];
    //     Array.Fill(memo, -1);
    //     MinCostClimbingStairs(cost, n, memo);
    //     return memo[n];
    // }

    // private int MinCostClimbingStairs(int[] cost, int curr, int[] memo) {
    //     if(curr < 2) {
    //         return 0;
    //     }
        
    //     if(memo[curr] == -1) {
    //         memo[curr] = Math.Min(cost[curr-1] + MinCostClimbingStairs(cost, curr-1, memo), cost[curr-2] + MinCostClimbingStairs(cost, curr-2, memo));
    //     }

    //     return memo[curr];
    // }
}
