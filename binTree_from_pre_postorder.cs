################################################################################
#
# Copyright (c) 2018
# Authors:
#  Hesham M. Eraqi (heraqi@aucegypt.edu)
#
# Given preorder and inorder traversal of a tree, construct the binary tree.
################################################################################

/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */

public class Solution {
    public int postidx = 0;

    public TreeNode build_recursive(int[] inorder, int[] postorder, int instart, int inend) {
        if (instart>inend || postidx == -1)
            return null;

        TreeNode currentNode = new TreeNode(postorder[postidx]);
        postidx--;

        if (instart == inend)
            return currentNode;

        int inpos = 0;
        for (int i=instart; i<=inend; i++)
            if (inorder[i] == currentNode.val) {
                inpos = i;
                break;
            }

        currentNode.right = build_recursive(inorder, postorder, inpos+1, inend);
        currentNode.left = build_recursive(inorder, postorder, instart, inpos-1);

        return currentNode;
    }

    public TreeNode BuildTree(int[] inorder, int[] postorder) {
        postidx = postorder.Length-1;
        return build_recursive(inorder, postorder, 0, inorder.Length-1);
    }
}
