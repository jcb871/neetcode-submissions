public class Solution {
    private int _cheapest;
    public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k) {
        _cheapest = -1;
        List<(int d, int p)>[] adjList = new List<(int d, int p)>[n];
        for(int i=0; i<n; i++){
            adjList[i] = new List<(int d, int p)>();
        }
        foreach(int[] flight in flights) {
            adjList[flight[0]].Add((flight[1], flight[2]));
        }

        bool[] visited = new bool[n];
        Dfs(adjList, src, dst, k, visited, cost: 0);
        return _cheapest;
    }

    private void Dfs(List<(int d, int p)>[] adjList, int src, int dst, int k, bool[] visited, int cost = 0) {
        if(_cheapest != -1 && cost >= _cheapest) return;
        if(src == dst) {
            if(_cheapest == -1 || _cheapest > cost) _cheapest = cost;
        }
        
        if(k < 0 || visited[src]) return;

        visited[src] = true;
        foreach((int d, int p) in adjList[src]) {
            Dfs(adjList, d, dst, k-1, visited, cost+p);
        }
        visited[src] = false;
    }
}
