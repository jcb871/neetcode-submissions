public class Solution {
    private class Edge {
        public int X1 {get; set; }
        public int Y1 {get; set; }
        public int X2 {get; set; }
        public int Y2 {get; set; }
        public int Dist {get; set; }

        public Edge(int x1, int y1, int x2, int y2, int dist = 0) {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
            Dist = dist;
        }
    }

    public int MinCostConnectPoints(int[][] points) {
        int n= points.Length;
        if(n < 2) return 0;
        List<Edge> edges = new (n * (n-1) / 2);
        Dictionary<(int x, int y), (int x, int y)> parents = new (n);
        for(int i=0; i<n-1; i++) {
            int[] p1 = points[i];
            int x1 = p1[0];
            int y1 = p1[1];
            parents[(x1, y1)] = (x1, y1);
            for(int j=i+1; j<n; j++) {
                int[] p2 = points[j];
                int x2 = p2[0];
                int y2 = p2[1];
                int mDist = Math.Abs(x1-x2) + Math.Abs(y1-y2);
                edges.Add(new Edge(x1, y1, x2, y2, mDist));
            }
        }
        parents[(points[n-1][0], points[n-1][1])] = (points[n-1][0], points[n-1][1]);

        edges = edges.OrderBy(e=>e.Dist).ToList();

        int minDist = 0;
        int edgeCount = 0;
        foreach(Edge edge in edges) {
            var rootU = Find(parents, (edge.X1, edge.Y1));
            var rootV = Find(parents, (edge.X2, edge.Y2));
            if(rootU != rootV) {
                minDist += edge.Dist;
                parents[rootU] = rootV;
                edgeCount++;
                if(edgeCount == n-1) break;
            }
        }
        return minDist;
    }

    private (int x, int y) Find(Dictionary<(int x, int y), (int x, int y)> parents, (int x, int y) point) {
        if(parents.TryGetValue(point, out (int x, int y) parent) && parent == point) return point;

        parent = Find(parents, parent);
        parents[point] = parent;
        return parent;
    }
}
