public class Solution {
    public const int VisitingState = 1;
    public const int VisitedState = 2;
    public bool CanFinish(int numCourses, int[][] prerequisites) {
        Dictionary<int, int> states = [];
        Dictionary<int, List<int>> vertices = new(prerequisites.Length);
        foreach(int[] req in prerequisites) {
            if(!vertices.TryGetValue(req[0], out List<int> dep)) {
                dep = new List<int>();
                vertices[req[0]] = dep;
            }
            dep.Add(req[1]);
        }
        for(int c=0; c<numCourses; c++) {
            if(!Dfs(vertices, c, states)) return false;
        }
        return true;
    }

    private bool Dfs(Dictionary<int, List<int>> vertices, int course, Dictionary<int, int> states) {
        if(states.TryGetValue(course, out int state)) {
            if(state == VisitedState) return true;
            if(state == VisitingState) return false;
        }

        states[course] = VisitingState;

        vertices.TryGetValue(course, out List<int> prerequisites);
        prerequisites ??= [];
        foreach(var dep in prerequisites) {
            if(!Dfs(vertices, dep, states)) return false;
        }
        states[course] = VisitedState;

        return true;
    }
}
