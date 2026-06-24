public class Solution {
    public int MaxProfit(int[] prices) {
        int len = prices.Length;
        int maxProfit = 0;
        if(len < 2) return maxProfit;

        int[] best = new int[len];
        int bestPrice = 0;
        for(int i=len-1;i>=0;i--){
            best[i] = bestPrice = Math.Max(prices[i], bestPrice);
        }

        for(int i=0; i<len-1; i++) {
            int profit = best[i+1] - prices[i];
            if(profit > maxProfit) maxProfit = profit;
        }

        return maxProfit;
    }
}
