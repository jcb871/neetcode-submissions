public class Solution {
    public int FindKthLargest(int[] nums, int k) {
        PriorityQueue<int, int> pq = new(k);

        foreach(int num in nums) {
            if(pq.Count < k) {
                pq.Enqueue(num, num);
            }
            else if(pq.Peek() < num) {
                pq.DequeueEnqueue(num, num);
            }
        }

        return pq.Peek();
    }
}
