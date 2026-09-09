public class Solution {
    public int MaxProfit(int[] prices) {
        int n = prices.Length;
        if(n < 2) return 0;

        int[] empty = new int[n];
        int[] holding = new int[n];
        int[] coolOff = new int[n];
        empty[0] = 0;
        coolOff[0] = 0;
        holding[0] = -prices[0];

        for(int day=1; day<n; day++) {
            empty[day] = Math.Max(empty[day-1], coolOff[day-1]);
            holding[day] = Math.Max(holding[day-1], empty[day-1] - prices[day]);
            coolOff[day] = holding[day-1] + prices[day];
        }
        return Math.Max(empty[n-1], coolOff[n-1]);
    }

    // public int MaxProfit(int[] prices) {
    //     int n = prices.Length;
    //     if(n < 2) return 0;

    //     int[] empty = new int[n];
    //     int[] holding = new int[n];
    //     int[] coolOff = new int[n];

    //     MaxProfit(prices, day:n-1, empty, holding, coolOff);
    //     return Math.Max(empty[n-1], coolOff[n-1]);
    // }

    // private void MaxProfit(int[] prices, int day, int[] empty, int[] holding, int[] coolOff) {
    //     if(day < 0) return;

    //     if(day == 0) {
    //         empty[0] = 0;
    //         holding[0] = -prices[0];
    //         coolOff[0] = 0;
    //         return;
    //     }

    //     MaxProfit(prices, day-1, empty, holding, coolOff);

    //     empty[day] = Math.Max(empty[day-1], coolOff[day-1]);
    //     holding[day] = Math.Max(holding[day-1], empty[day-1]-prices[day]);
    //     coolOff[day] = holding[day-1] + prices[day];
    // }
}
