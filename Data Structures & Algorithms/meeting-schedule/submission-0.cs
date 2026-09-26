/**
 * Definition of Interval:
 * public class Interval {
 *     public int start, end;
 *     public Interval(int start, int end) {
 *         this.start = start;
 *         this.end = end;
 *     }
 * }
 */

public class Solution {
    public bool CanAttendMeetings(List<Interval> intervals) {
        int n = intervals.Count;
        intervals = intervals.OrderBy(i=>i.start).ToList();
        for(int i=1; i<n; i++) {
            if(AreOverlapping(intervals[i-1], intervals[i])) return false;
        }

        return true;
    }

    private bool AreOverlapping(Interval prev, Interval curr) 
        => prev.end > curr.start;
}
