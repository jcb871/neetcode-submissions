/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> neighbors;

    public Node() {
        val = 0;
        neighbors = new List<Node>();
    }

    public Node(int _val) {
        val = _val;
        neighbors = new List<Node>();
    }

    public Node(int _val, List<Node> _neighbors) {
        val = _val;
        neighbors = _neighbors;
    }
}
*/

public class Solution {
    public Node CloneGraph(Node node) {
        return (node == null) ? null : CloneGraph(node, visited: []);
    }

    private Node CloneGraph(Node original, Dictionary<Node, Node> visited) {
        if(original == null) return null;
        if(visited.TryGetValue(original, out Node copy)) return copy;

        copy = new Node(original.val);
        visited[original] = copy;
        foreach(Node node in original.neighbors) {
            Node neighbor = CloneGraph(node, visited);
            if(neighbor != null) copy.neighbors.Add(neighbor);
        }
        return copy;
    }
}
