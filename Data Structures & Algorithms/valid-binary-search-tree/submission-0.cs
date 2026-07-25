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
    public bool IsValidBST(TreeNode root) {
        if(root == null) return true;
        return Dfs(root, int.MinValue, int.MaxValue);
    }

    private bool Dfs(TreeNode node, long min, long max) {
        if(node == null) return true;

        if(node.val <= min) return false;
        if(node.val >= max) return false;
     
        return Dfs(node.left, min, node.val) &&  Dfs(node.right, node.val, max);
    }
}
