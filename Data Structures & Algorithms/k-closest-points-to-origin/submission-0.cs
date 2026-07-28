public class Solution {
    public int[][] KClosest(int[][] points, int k) {
        PriorityQueue<int[], int> pq = new(k);
        int n = points.Length;
        foreach(int[] point in points) {
            int dist = point[0]*point[0] + point[1]*point[1];
            
            if(pq.Count < k) {
                pq.Enqueue(point, -dist);
            }
            else if(pq.TryPeek(out _, out int xDist) && -xDist > dist) {
                pq.DequeueEnqueue(point, -dist);
            }
        }

        int p = 0;
        int[][] result = new int[pq.Count][];
        while(pq.Count > 0) {
            result[p++] = pq.Dequeue();
        }
        return result;
    }
}
