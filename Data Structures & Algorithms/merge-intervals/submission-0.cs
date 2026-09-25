public class Solution {
    public int[][] Merge(int[][] intervals) {
        int n = intervals.Length;
        if(n <= 0) return intervals;
        Array.Sort(intervals, (a,b)=>a[0].CompareTo(b[0]));
        List<int[]> result = new(n);
        int[] prev = intervals[0];
        for(int i=1; i<n; i++) {
            int[] curr = intervals[i];
            if(AreOverlapping(prev, curr)) {
                prev = [prev[0], Math.Max(prev[1], curr[1])];
            }
            else {
                result.Add(prev);
                prev = curr;
            }
        }
        result.Add(prev);
        return result.ToArray();
    }

    private bool AreOverlapping(int[] prev, int[] curr) 
        => prev[1] >= curr[0];
}
