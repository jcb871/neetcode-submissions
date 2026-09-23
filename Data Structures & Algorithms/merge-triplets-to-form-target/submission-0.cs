public class Solution {
    public bool MergeTriplets(int[][] triplets, int[] target) {
        int tn = triplets.Length;
        bool[] found = new bool[3];
        for(int t=0; t<tn; t++) {
            int[] triplet = triplets[t];
            bool canUse = triplet[0] <= target[0] && triplet[1] <= target[1] && triplet[2] <= target[2];
            for(int p=0; canUse && p<3; p++) {
                found[p] |= (triplet[p] == target[p]);
            }
        }
        return found[0] && found[1] && found[2];
    }
}
