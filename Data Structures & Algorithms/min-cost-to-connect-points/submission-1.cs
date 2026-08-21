public class Solution {
    private class Edge {
        public int U {get; set; }
        public int V {get; set; }
        public int Dist {get; set; }

        public Edge(int u, int v, int dist = 0) {
            U= u;
            V = v;
            Dist = dist;
        }
    }

    public int MinCostConnectPoints(int[][] points) {
        int n= points.Length;
        if(n < 2) return 0;
        List<Edge> edges = new (n * (n-1) / 2);
        int[] parents = new int[n];
        for(int i=0; i<n-1; i++) {
            int[] p1 = points[i];
            int x1 = p1[0];
            int y1 = p1[1];
            parents[i] = i;
            for(int j=i+1; j<n; j++) {
                int[] p2 = points[j];
                int x2 = p2[0];
                int y2 = p2[1];
                int mDist = Math.Abs(x1-x2) + Math.Abs(y1-y2);
                edges.Add(new Edge(i, j, mDist));
            }
        }
        parents[n-1] = n-1;

        edges = edges.OrderBy(e=>e.Dist).ToList();

        int minDist = 0;
        int edgeCount = 0;
        foreach(Edge edge in edges) {
            var rootU = Find(parents, edge.U);
            var rootV = Find(parents, edge.V);
            if(rootU != rootV) {
                minDist += edge.Dist;
                parents[rootU] = rootV;
                edgeCount++;
                if(edgeCount == n-1) break;
            }
        }
        return minDist;
    }

    private int Find(int[] parents, int point) {
        if(parents[point] == point) return point;

        return parents[point] = Find(parents, parents[point]);
    }
}
