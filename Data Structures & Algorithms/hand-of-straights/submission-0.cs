public class Solution {
    public bool IsNStraightHand(int[] hand, int groupSize) {
        if(hand.Length % groupSize != 0) return false;

        Dictionary<int, int> counts = new();
        foreach(int h in hand) {
            _ = counts.TryGetValue(h, out int count);
            counts[h] = count+1;
        }

        int[] uniqueHands = hand.Distinct()
            .OrderBy(x=>x)
            .ToArray();

        int groupCount = groupSize;
        int startIndex = 0;
        int curr = uniqueHands[startIndex];
        while(counts.Any()) {
            if(!counts.TryGetValue(curr, out int count)) return false;

            if(count == 1){
                counts.Remove(curr);
            }
            else {
                counts[curr] = count - 1;
            }
            groupCount--;

            if(groupCount == 0 && counts.Count > 0) {
                groupCount = groupSize;
                curr = uniqueHands[startIndex];
                while(!counts.ContainsKey(curr)) {
                    curr = uniqueHands[++startIndex];
                }
            }
            else {
                curr++;
            }
        }
        return groupCount == 0;
    }
}
