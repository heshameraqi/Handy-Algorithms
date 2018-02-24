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
 * struct TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * };
 */

public class Solution {
    int preIndex = 0;
    
    public TreeNode build_recursive(int[] preorder, int[] inorder, int inStrt, int inEnd) {
        Console.WriteLine("Start=" + inStrt.ToString() + " End=" + inEnd.ToString());
        if(inStrt > inEnd)
            return null;
       
        if (preIndex >= (preorder.Length))
            return null;
        
        TreeNode tNode = new TreeNode(preorder[preIndex]);
        preIndex++;
        
        if(inStrt == inEnd)
            return tNode;

        int inIndex = 0;
        for(int i = inStrt; i <= inEnd; i++)
        {
            if(inorder[i] == tNode.val)
                inIndex = i;
        }
        
        Console.WriteLine(inIndex);

        tNode.left = build_recursive(preorder, inorder, inStrt, inIndex-1);
        tNode.right = build_recursive(preorder, inorder, inIndex+1, inEnd);

        return tNode;
    }
    
    public TreeNode BuildTree(int[] preorder, int[] inorder) {
        return build_recursive(preorder, inorder, 0, inorder.Length-1);
    }
}
