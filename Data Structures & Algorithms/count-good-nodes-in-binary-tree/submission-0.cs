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
    public int GoodNodes(TreeNode root) {
        return GoodNodes(root, root?.val ?? int.MinValue);
    }

    private int GoodNodes(TreeNode root, int maxFromRoot) {
        if(root == null) return 0;

        int goodNodes = 0;
        if(root.val >= maxFromRoot) {
            maxFromRoot = root.val;
            goodNodes++;
        }

        return goodNodes + GoodNodes(root.left, maxFromRoot) + GoodNodes(root.right, maxFromRoot);
    }
}
