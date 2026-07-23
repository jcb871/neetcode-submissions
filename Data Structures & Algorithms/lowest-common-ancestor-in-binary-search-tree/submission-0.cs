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
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        if(root == null || p == null || q == null) return null;

        if(p.val > q.val) return LowestCommonAncestor(root, q, p);

        if(q.val < root.val) {
            return LowestCommonAncestor(root.left, p, q);
        }

        if(p.val > root.val) {
            return LowestCommonAncestor(root.right, p, q);
        }

        return root;
    }
}
