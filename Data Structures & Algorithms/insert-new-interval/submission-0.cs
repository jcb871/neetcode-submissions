public class Solution {
    public int[][] Insert(int[][] intervals, int[] newInterval) {
        int n = intervals.Length;
        if(n == 0) return [newInterval];
        
        int[] prev = newInterval;
        List<int[]> result = [];
        for(int i=0; i<n; i++) {
            int[] curr = intervals[i];
            if(IsOverlapping(prev, curr)) {
                prev = Merge(prev, curr);
            }            
            else if(prev[0] < curr[0]) {
                result.Add(prev);
                prev = curr;
            }
            else {
                result.Add(curr);
            }
        }
        result.Add(prev);
        return result.ToArray();
    }

    private bool IsOverlapping(int[] i1, int[] i2) {
        int start1 = i1[0], start2 = i2[0];
        int end1 = i1[1], end2 = i2[1];
        return Math.Max(start1, start2) <= Math.Min(end1, end2);
    }

    private int[] Merge(int[] i1, int[] i2) {
        return [Math.Min(i1[0], i2[0]), Math.Max(i1[1], i2[1])];
    }    
}
