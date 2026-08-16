public class Solution {
    public bool ValidTree(int n, int[][] edges) {
       if(edges.Length != n-1) return false;

        int[] parents = new int[n];
        for(int i=0; i<n; i++) parents[i] = i;

        foreach(int[] edge in edges){
            int u = edge[0], v= edge[1];
            int rootU = Find(parents, u);
            int rootV = Find(parents, v);
            if(rootU == rootV) return false;
            parents[rootU] = rootV;
        }
        return true;
    }

    private int Find(int[] parents, int node) {
        if(parents[node] == node) return node;

        return parents[node] = Find(parents, parents[node]); //path compression
    }

    // public bool ValidTree(int n, int[][] edges) {
    //     List<int>[] graph = new List<int>[n];
    //     for(int i=0; i<n; i++) {
    //         graph[i] = [];
    //     }
    //     foreach(int [] edge in edges) {
    //         graph[edge[0]].Add(edge[1]);
    //         graph[edge[1]].Add(edge[0]);
    //     }

    //     bool[] visited = new bool[n];
    //     Queue<(int node, int parent)> q = [];
    //     q.Enqueue((0, -1));
    //     while(q.Count > 0) {
    //         int levelSize = q.Count;
    //         for(int i=0; i<levelSize; i++) {
    //             (int node, int parent) = q.Dequeue();
    //             if(node != parent && visited[node]) return false;
    //             visited[node] = true;
    //             List<int> connectedNodes = graph[node];
    //             foreach(int cn in connectedNodes) {
    //                 if(cn != parent) q.Enqueue((cn, node));
    //             }
    //         }
    //     }        
    //     return visited.All(v=> v);
    // }
}
