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
    public int MinMeetingRooms(List<Interval> intervals) {
        int n = intervals.Count;
        if(n <= 1) return n;

        intervals = intervals.OrderBy(i=>i.start).ToList(); //sort by start time

        int maxRooms = 0;
        PriorityQueue<int, int> meetings = new (n);
        foreach(Interval i in intervals) {
            while(meetings.Count > 0 && i.start >= meetings.Peek()) {
                meetings.Dequeue();
            }
            meetings.Enqueue(i.end, i.end);
            maxRooms = Math.Max(meetings.Count, maxRooms);
        }
        return maxRooms;
    }
}
