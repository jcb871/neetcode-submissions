public class Solution {
    public int MinCostConnectPoints(int[][] points) {
        int n= points.Length;
        if(n < 2) return 0;

        int[] minDist = new int[n];
        bool[] visited = new bool[n];
        Array.Fill(minDist, int.MaxValue);
        
        minDist[0] = 0;
        int totalCost = 0;

        for(int i=0; i<n; i++) {
            int curr = -1;
            int currentMin = int.MaxValue;
            for(int j=0; j<n; j++) {
                if(!visited[j] && minDist[j] < currentMin) {
                    currentMin = minDist[j];
                    curr = j;
                }
            }

            visited[curr] = true;
            totalCost += currentMin;

            for(int j=0; j<n; j++) {
                if(!visited[j]) {
                    int dist = Math.Abs(points[curr][0] - points[j][0]) +  Math.Abs(points[curr][1] - points[j][1]);
                    if(dist < minDist[j]) minDist[j] = dist;
                }
            }            
        }

        return totalCost;
    }

    // private class Edge {
    //     public int U {get; set; }
    //     public int V {get; set; }
    //     public int Dist {get; set; }

    //     public Edge(int u, int v, int dist = 0) {
    //         U= u;
    //         V = v;
    //         Dist = dist;
    //     }
    // }

    // public int MinCostConnectPoints(int[][] points) {
    //     int n= points.Length;
    //     if(n < 2) return 0;
    //     List<Edge> edges = new (n * (n-1) / 2);
    //     int[] parents = new int[n];
    //     for(int i=0; i<n-1; i++) {
    //         int[] p1 = points[i];
    //         int x1 = p1[0];
    //         int y1 = p1[1];
    //         parents[i] = i;
    //         for(int j=i+1; j<n; j++) {
    //             int[] p2 = points[j];
    //             int x2 = p2[0];
    //             int y2 = p2[1];
    //             int mDist = Math.Abs(x1-x2) + Math.Abs(y1-y2);
    //             edges.Add(new Edge(i, j, mDist));
    //         }
    //     }
    //     parents[n-1] = n-1;

    //     edges = edges.OrderBy(e=>e.Dist).ToList();

    //     int minDist = 0;
    //     int edgeCount = 0;
    //     foreach(Edge edge in edges) {
    //         var rootU = Find(parents, edge.U);
    //         var rootV = Find(parents, edge.V);
    //         if(rootU != rootV) {
    //             minDist += edge.Dist;
    //             parents[rootU] = rootV;
    //             edgeCount++;
    //             if(edgeCount == n-1) break;
    //         }
    //     }
    //     return minDist;
    // }

    // private int Find(int[] parents, int point) {
    //     if(parents[point] == point) return point;

    //     return parents[point] = Find(parents, parents[point]);
    // }
}
