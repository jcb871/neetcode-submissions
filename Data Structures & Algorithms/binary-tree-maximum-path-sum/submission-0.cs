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
    private int _max;
    public int MaxPathSum(TreeNode root) {
        _max = int.MinValue;
        _ = Dfs(root);
        return _max;
    }

    private int Dfs(TreeNode root) {
        if(root == null) return 0;

        int leftMax = Math.Max(0, Dfs(root.left));
        int rightMax = Math.Max(0, Dfs(root.right));
        
        int maxThroughRoot = root.val + leftMax + rightMax;
        if(_max < maxThroughRoot) _max = maxThroughRoot;

        return root.val + Math.Max(leftMax, rightMax);
    }
}
