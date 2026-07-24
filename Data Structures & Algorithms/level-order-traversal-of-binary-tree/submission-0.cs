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
    public List<List<int>> LevelOrder(TreeNode root) {
        List<List<int>> result = [];
        FindNodes(root, level: 0, result);
        return result;
    }

    private void FindNodes(TreeNode root, int level, List<List<int>> result) {
        if(root == null) return;

        if(result.Count <= level) {
            List<int> nodes = [];
            result.Add(nodes);
        }
        result[level].Add(root.val);

        FindNodes(root.left, level+1, result);
        FindNodes(root.right, level+1, result);
    }

}
