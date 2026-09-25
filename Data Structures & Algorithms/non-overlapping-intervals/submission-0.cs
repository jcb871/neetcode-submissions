public class Solution {
    public int EraseOverlapIntervals(int[][] intervals) {
        int n= intervals.Length;
        int result = 0;
        if(n <= 1) return result;

        Array.Sort(intervals, (a, b) => a[1].CompareTo(b[1]));
        int? prevEnd = null;
        foreach(int[] curr in intervals) {
            if(prevEnd == null || curr[0] >= prevEnd) {
                prevEnd = curr[1];
            }
            else { //overlaps - remove this interval
                result++;
            }
        }
        return result;
    }
}
