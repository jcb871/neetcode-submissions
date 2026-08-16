public class Solution {
    public int CountComponents(int n, int[][] edges) {
        int[] parents = new int[n];
        for(int i=0; i<n; i++) {
            parents[i] = i;
        }

        int result = n;
        foreach(int[] edge in edges) {
            int u = edge[0], v = edge[1];
            int rootU = Find(parents, u);
            int rootV = Find(parents, v);
            if(rootU != rootV) {
                parents[rootU] = rootV;
                result--;
            }
        }

        return result;
    }

    private int Find(int[] parents, int node) {
        if(parents[node] == node) return node;

        parents[node] = Find(parents, parents[node]); //path compression
        return parents[node];
    }
}
