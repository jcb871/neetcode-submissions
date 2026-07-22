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
    private int _maxDiameter;
    public int DiameterOfBinaryTree(TreeNode root) {
        if(root == null) return 0;

        _maxDiameter = 0;
        Dfs(root);

        return _maxDiameter;
    }

    private int Dfs(TreeNode root) {
        if(root == null) return 0;

        int depthLeft = Dfs(root.left);
        int depthRight = Dfs(root.right);

        int maxDiameter = depthLeft + depthRight;
        if(_maxDiameter < maxDiameter) _maxDiameter = maxDiameter;

        return Math.Max(depthLeft, depthRight) + 1;
    }
}
