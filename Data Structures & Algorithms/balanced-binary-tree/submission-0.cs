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
    public bool IsBalanced(TreeNode root) {
        return Dfs(root) != -1;        
    }

    private int Dfs(TreeNode root) {
        if(root == null) return 0;

        int leftHeight = Dfs(root.left);
        if(leftHeight == -1) return -1;
        int rightHeight = Dfs(root.right);        
        if(rightHeight == -1) return -1;

        if(Math.Abs(leftHeight - rightHeight) > 1) return -1;

        return 1 + Math.Max(leftHeight, rightHeight);
    }
}
