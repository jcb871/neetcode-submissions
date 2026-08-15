public class Solution {
    public const int VisitingState = 1;
    public const int VisitedState = 2;
    public int[] FindOrder(int numCourses, int[][] prerequisites) {
        List<int>[] graph = new List<int>[numCourses];
        for(int i=0;i<numCourses;i++) {
            graph[i] = [];
        }
        for(int i=0; i<prerequisites.Length; i++) {
            int[] pre = prerequisites[i];
            graph[pre[0]].Add(pre[1]);
        }
        
        int[] visits = new int[numCourses];
        List<int> courseOrder = new (numCourses);    
        for(int i=0; i<numCourses; i++) {
            if(!Dfs(graph, i, visits, courseOrder)) return [];
        }
        return courseOrder.ToArray();
    }

    private bool Dfs(List<int>[] graph, int course, int[] visits, List<int> courseOrder) {
        if(visits[course] == VisitingState) return false;
        if(visits[course] == VisitedState) return true;

        visits[course] = VisitingState;
        List<int> pre = graph[course];
        foreach(int p in pre) {
            if(!Dfs(graph, p, visits, courseOrder)) return false;
        }
        visits[course] = VisitedState;
        courseOrder.Add(course);
        return true;
    }
}
