/*################################################################################
#
# Copyright (c) 2018
# Authors:
#  Hesham M. Eraqi (heraqi@aucegypt.edu)
#
################################################################################*/

using System;
using System.Collections.Generic; // For Stack

class TreeNode
{
    public TreeNode Left;
    public TreeNode Right;
    public int Data;
};

class Solution
{       
    static bool DFS_Search(int data, TreeNode root, Stack<TreeNode> searchStack)
    {
        searchStack.Push(root);
        TreeNode current;
        while (searchStack.Count != 0)
        {
            current = searchStack.Pop();
            if (current.Data == data)
                return true;
            else{
                if (current.Right != null)
                    searchStack.Push(current.Right);
                if (current.Left != null)
                    searchStack.Push(current.Left);
            }
        }
        return false;
    }
    
    static void Main(string[] args)
    {
        TreeNode node4 = new TreeNode() {Data = 20};
        TreeNode node3 = new TreeNode() {Data = 3};
        TreeNode node2 = new TreeNode() {Data = 11, Right = node4};
        TreeNode node1 = new TreeNode() {Data = 10, Left = node3};
        TreeNode root = new TreeNode() {Data = 5, Left = node1, Right = node2};
        
        Stack<TreeNode> searchStack = new Stack<TreeNode>();
        
        Console.WriteLine(DFS_Search(15,root,searchStack) ? "Yes":"No");
    }
}
