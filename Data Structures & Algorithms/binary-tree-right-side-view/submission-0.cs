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

public class Solution {
    public List<int> RightSideView(TreeNode root) {
        List<int> result = [];
        if(root == null) return result;

        Queue<TreeNode> nodes = [];
        nodes.Enqueue(root);

        while(nodes.Count > 0) {
            int levelNodesCount = nodes.Count;
            result.Add(0);
            for(int n=0; n<levelNodesCount;n++) {
                TreeNode node = nodes.Dequeue();
                result[result.Count-1] = node.val;

                if(node.left != null) nodes.Enqueue(node.left);
                if(node.right != null) nodes.Enqueue(node.right);
            }
        }
        return result;
    }
}
