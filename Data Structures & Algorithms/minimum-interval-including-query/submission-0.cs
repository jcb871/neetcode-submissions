public class Solution {
    public int[] MinInterval(int[][] intervals, int[] queries) {
        int n = intervals.Length;
        int m = queries.Length;
        Array.Sort(intervals, (a, b)=>a[0].CompareTo(b[0]));

        var sortedQueries = queries
            .Select((q, i) => (q, i))
            .OrderBy(p=>p.Item1)
            .ToArray();

        PriorityQueue<(int, int), int> pq = new(n);
        int iStart = 0;
        int[] result = new int[m];
        foreach((int q, int index) in sortedQueries) {
            while(iStart < n && intervals[iStart][0] <= q) {
                int[] interval = intervals[iStart];
                pq.Enqueue((interval[0], interval[1]), interval[1]-interval[0]+1);
                iStart++;
            }

            while(pq.Count>0 && pq.Peek().Item2 < q) {
                pq.Dequeue();
            }
            
            if(!pq.TryPeek(out _, out int len)) len = -1;
            result[index] = len;
        }

        return result;
    }
}
