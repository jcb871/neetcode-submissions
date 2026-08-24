public class Solution {
    public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k) {
        int[] prices = new int[n];
        Array.Fill(prices, int.MaxValue);
        prices[src] = 0;

        for(int i=0; i<=k; i++) {
            int[] tempPrices = (int[])prices.Clone();

            foreach(int[] flight in flights) {
                int u = flight[0], v = flight[1], p = flight[2];
                
                if(prices[u] == int.MaxValue) continue;

                if(prices[u] + p < tempPrices[v]) tempPrices[v] = prices[u] + p;
            }
            prices = tempPrices;
        }
        return prices[dst]  == int.MaxValue ? -1 : prices[dst];
    }
}
