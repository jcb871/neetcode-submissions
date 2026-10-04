public class CountSquares {

    Dictionary<(int x, int y), int> _counts;
    Dictionary<int, HashSet<int>> _points;

    public CountSquares() {
        _counts = new();
        _points = new();
    }
    
    public void Add(int[] point) {
        int x = point[0], y = point[1];
        if(!_counts.TryGetValue((x, y), out int count)) {
            count = 0;
        }
        _counts[(x, y)] = count+1;
        if(!_points.TryGetValue(x, out HashSet<int> ySet)) {
            ySet = new HashSet<int>();
            _points[x] = ySet;
        }
        ySet.Add(y);
    }
    
    public int Count(int[] point) {
        int qx = point[0], qy = point[1];
        if(!_points.TryGetValue(qx, out HashSet<int> pySet))  return 0;
        int px = qx;
        int totalCount = 0;
        foreach(int py in pySet) {
            if(qy == py) continue;
            int side = Math.Abs(py - qy);
            int count = _counts[(px, py)];
            count *= _counts.GetValueOrDefault((qx-side, qy));
            count *= _counts.GetValueOrDefault((px-side, py));
            totalCount += count;
            count = _counts[(px, py)];
            count *= _counts.GetValueOrDefault((qx+side, qy));
            count *= _counts.GetValueOrDefault((px+side, py));
            totalCount += count;
        }

        return totalCount;
    }
}
