/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */

public class Codec {

    // Encodes a tree to a single string.
    public string Serialize(TreeNode root) {
        if(root == null) return string.Empty;

        Queue<TreeNode> q = [];
        List<int?> nodes = [];
        q.Enqueue(root);
        while(q.Count > 0) {
            int nodeCount =  q.Count;
            for(int i=0; i<nodeCount; i++) {
                TreeNode node = q.Dequeue();
                nodes.Add(node?.val);
                if(node == null) continue;
                q.Enqueue(node.left);
                q.Enqueue(node.right);
            }            
        }

        return string.Join(",", nodes);
    }

    // Decodes your encoded data to tree.
    public TreeNode Deserialize(string data) {
        if(string.IsNullOrWhiteSpace(data)) return null;

        string[] nodes = data.Split(",");

        Queue<TreeNode> q = [];
        int index = 0;
        TreeNode root = new(Convert.ToInt32(nodes[index]));
        q.Enqueue(root);

        while(q.Count > 0){
            TreeNode node = q.Dequeue();
            string leftNodeString = nodes[++index];
            if(int.TryParse(leftNodeString, out int leftVal)) {
                node.left = new(leftVal);
                q.Enqueue(node.left);
            }
            string rightNodeString = nodes[++index];
            if(int.TryParse(rightNodeString, out int rightVal)) {
                node.right = new(rightVal);
                q.Enqueue(node.right);
            }
        }

        return root;
    }
}
