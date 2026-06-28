public class Solution {
    public int[] MaxSlidingWindow(int[] nums, int k) {
        if(k<1 || nums == null || nums.Length < k) return null;

        int[] ans = new int[nums.Length - k + 1];
        LinkedList<int> maxQ = new();

        for(int i=0; i<nums.Length; i++) {
            int num = nums[i];

            if(maxQ.Count > 0 && maxQ.First.Value < (i-k+1)) {
                maxQ.RemoveFirst();
            }

            while(maxQ.Count != 0 && nums[maxQ.Last.Value] <  num) {
                maxQ.RemoveLast();
            }
            maxQ.AddLast(i);
            
            if(i >= k -1) {
                ans[i-k+1] = nums[maxQ.First.Value];
            }
        }

        return ans;
    }
}
