public class Solution {
    public int MinDistance(string word1, string word2) {
        int n1=word1.Length, n2=word2.Length;
        int?[,] memo = new int?[n1, n2];
        return MinDist(word1, word2, i1:0, i2:0, memo);
    }


    private int MinDist(string w1, string w2, int i1, int i2, int?[,] memo) {
        int n1=w1.Length, n2=w2.Length;
        if(i1 >= n1) return n2-i2;
        if(i2 >= n2) return n1-i1;
        
        if(memo[i1, i2].HasValue) return memo[i1, i2].Value;

        int dist = int.MaxValue;
        int costFromNext = MinDist(w1, w2, i1+1, i2+1, memo);
        dist = Math.Min(dist, 1 + costFromNext); //replace
        if(w1[i1] == w2[i2]) dist = Math.Min(dist, costFromNext); //no-op
        dist = Math.Min(dist, 1 + MinDist(w1, w2, i1+1, i2, memo)); //delete
        dist = Math.Min(dist, 1 + MinDist(w1, w2, i1, i2+1, memo)); //insert

        memo[i1, i2] = dist;
        return dist;
    }
}
