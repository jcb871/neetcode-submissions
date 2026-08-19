public class Solution {
    public int NetworkDelayTime(int[][] times, int n, int k) {
        var adj = new List<(int nr, int time)>[n+1];
        for(int i=0; i< n+1; i++) {
            adj[i] = [];
        }
        foreach(int[] time in times) {
            adj[time[0]].Add((time[1], time[2]));
        }

        PriorityQueue<int, int> pq = new (times.Length);
        pq.Enqueue(k, 0);

        Dictionary<int, int> minTimes = new (n+1);
        while(pq.Count > 0) {
            pq.TryDequeue(out int node, out int time1);
            if(minTimes.TryGetValue(node, out int prevMin1) && prevMin1 < time1) continue;
            minTimes[node] = time1;
            List<(int nr, int time)> neighbors = adj[node];
            foreach((int nr, int time) in neighbors) {
                int requiredTime = time1 + time;
                if(minTimes.TryGetValue(nr, out int prevMin) && prevMin <= requiredTime) continue;
                minTimes[nr] = requiredTime;
                pq.Enqueue(nr, requiredTime);
            }
        }

        if(minTimes.Count < n) return -1;
        return minTimes.Max(kv=>kv.Value);
    }
}
