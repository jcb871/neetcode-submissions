public class Solution {
    public int[] FindRedundantConnection(int[][] edges) {
        int n = edges.Length;
        int[] parents = new int[n+1];
        for(int i=1; i<=n; i++) {
            parents[i] = i;
        }

        foreach(int[] edge in edges) {
            int rootU = Find(parents, edge[0]);
            int rootV = Find(parents, edge[1]);
            if(rootU == rootV) return edge;
            parents[rootU] = rootV; //union
        }

        return null;
    }

    private int Find(int[] parents, int node) {
        if(parents[node] == node) return node;

        return parents[node] = Find(parents, parents[node]); //path compression
    }
}
