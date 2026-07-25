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
    public int KthSmallest(TreeNode root, int k) {
        return Dfs(root, ref k) ?? -1;
    }

    private int? Dfs(TreeNode root, ref int k) {
        if(root == null) return null;

        int? left = Dfs(root.left, ref k);
        if(left.HasValue) return left;
        k--;
        return (k==0) ? root.val : Dfs(root.right, ref k);
    }
}
