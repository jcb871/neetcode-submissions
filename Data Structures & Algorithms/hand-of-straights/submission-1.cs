public class Solution {
    public bool IsNStraightHand(int[] hand, int groupSize) {
        if(hand.Length % groupSize != 0) return false;

        Dictionary<int, int> counts = new();
        foreach(int h in hand) {
            counts[h] = counts.GetValueOrDefault(h) + 1;
        }

        int[] sortedKeys = counts.Keys.ToArray();
        Array.Sort(sortedKeys);

        foreach(int start in sortedKeys) {
            int cardCount = counts[start];

            if(cardCount == 0) continue;

            for(int i=0; i<groupSize; i++) {
                int currentCard = start + i;

                if(counts.GetValueOrDefault(currentCard) < cardCount) return false;

                counts[currentCard] -= cardCount;
            }
        }

        return true;
    }
}
