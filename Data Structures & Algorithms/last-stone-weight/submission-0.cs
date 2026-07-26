public class Solution {
    public int LastStoneWeight(int[] stones) {
        PriorityQueue<int, int> q = new (stones.Length);
        foreach(int w in stones) q.Enqueue(w, -w); //max heap

        while(q.Count > 1) {
            int x = (-1) * q.Dequeue();
            int y = (-1) * q.Dequeue();
            int newW = Math.Abs(x - y);
            q.Enqueue(newW, -newW);
        }

        return q.Count == 0 ? 0 : q.Dequeue();
    }
}
