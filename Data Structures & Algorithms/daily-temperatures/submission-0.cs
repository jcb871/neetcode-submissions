public class Solution {
    public int[] DailyTemperatures(int[] temperatures) {
        if(temperatures.Length == 0) return temperatures;
        Stack<int> opts = [];
        int[] ans = new int[temperatures.Length];
        for(int i=ans.Length-1; i>=0; i--) {
            int currT = temperatures[i];
            while(opts.Count > 0 && temperatures[opts.Peek()] <= currT) {
                opts.Pop();
            }
            ans[i] = opts.Count ==0? 0 : opts.Peek() - i;
            opts.Push(i);
        }
        return ans;
    }
}
