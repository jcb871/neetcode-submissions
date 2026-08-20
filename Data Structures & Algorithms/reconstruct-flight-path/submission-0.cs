public class Solution {
    public List<string> FindItinerary(List<List<string>> tickets) {
        List<string> result = [];
        Dictionary<string, PriorityQueue<string, string>> graph = new (StringComparer.CurrentCultureIgnoreCase);
        foreach(List<string> t in tickets) {
            string from = t[0];
            string to = t[1];
            if(!graph.TryGetValue(from, out PriorityQueue<string, string> destinations)) {
                destinations = new PriorityQueue<string, string>(StringComparer.CurrentCultureIgnoreCase);
                graph[from] = destinations;
            }   
            destinations.Enqueue(to, to);
        }
        Dfs("JFK", graph, result);
        result.Reverse();
        return result;
    }


    private void Dfs(string from, Dictionary<string, PriorityQueue<string, string>> graph, List<string> result) {
        if(!graph.TryGetValue(from, out PriorityQueue<string, string> destinations) || destinations.Count == 0) {
            result.Add(from);
            return;
        }

        while(destinations.Count > 0) {
            string to = destinations.Dequeue();
            Dfs(to, graph, result);        
        }

        result.Add(from);
    }
}
