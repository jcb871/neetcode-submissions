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
    public TreeNode BuildTree(int[] preorder, int[] inorder) {
        if(preorder.Length ==0 || inorder.Length == 0) return null;
        Dictionary<int, int> inorderIndexDict = [];        
        for(int i=0; i<inorder.Length;i++) {
            inorderIndexDict[inorder[i]] = i;
        }
        return BuildTree(preorder, 0, preorder.Length-1, inorder, 0, inorder.Length-1, inorderIndexDict);
    }

    private TreeNode BuildTree(int[] preorder, int poStart, int poEnd, int[] inorder, int ioStart, int ioEnd, Dictionary<int, int> inorderIndexDict) {
        if(poEnd < poStart || ioEnd < ioStart) return null;

        //preorder = Root, L, R
        //inorder = L, Root, R
        TreeNode root = new TreeNode(preorder[poStart]);        

        int left = inorderIndexDict[root.val];
        //left sub tree is between ioStart and left-1 in inorder.
        int leftNodes = (left-1) - ioStart + 1;
        //right sub tree is between left+1 and ioEnd in inorder. 
        int rightNodes = ioEnd - (left+1) + 1;
         
        //left sub tree is between poStart+1 and poStart+leftNodes
        //right sub tree is between poStart+1+leftNodes and poEnd
        root.left = BuildTree(preorder, poStart+1, poStart+leftNodes, inorder, ioStart, ioStart+leftNodes-1, inorderIndexDict);
        root.right = BuildTree(preorder, poStart+leftNodes+1, poEnd, inorder, ioStart+1+leftNodes, ioEnd, inorderIndexDict);
        
        return root;
    }
}
