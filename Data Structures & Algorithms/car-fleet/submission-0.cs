public class Solution {
    public int CarFleet(int target, int[] position, int[] speed) {
        var sortedWithIndices = position
            .Select((val, index) => (Position: val, Speed: speed[index]))
            .OrderByDescending(item => item.Position)
            .ToArray();
        int fleets = 0;
        decimal leadTime = 0;
        for(int i=0; i<sortedWithIndices.Length; i++) {
            var curr = sortedWithIndices[i];
            decimal currLeadTime = ((decimal)target-(decimal)curr.Position)/(decimal)curr.Speed;
            if(leadTime < currLeadTime) {
                leadTime = currLeadTime;
                fleets++;
            }
        }

        return fleets;
    }
}
