################################################################################
#
# Copyright (c) 2018
# Authors:
#  Hesham M. Eraqi (heraqi@aucegypt.edu)
#
################################################################################

using System;
using System.Collections.Generic; // For Lists and Dictionaries

// To execute C#, please define "static void Main" on a class
// named Solution.

class Node {
    public int key;
    public string data;
    
    public Node(int k, string d){
        key = k;
        data = d;
    }
    
    public Node(Node anotherNode){
        key = anotherNode.key;
        data = anotherNode.data;
    }
}

class Solution
{
    static void Swap(List<Node> A, int x, int y) { //function to swap elements
        Node temp = A[x];
        A[x] = A[y];
        A[y] = temp;
    }
    
    static int Partition(List<Node> A, int s, int e) {
        int p = s; // Pivot (hopefully gets in middle by end of this function) Median of 3 is better than just s
        
        int p_key = A[p].key;
        int leftwall = s;
        for (int i = s+1; i<=e; i++) {
            if (A[i].key < p_key) {
                Swap(A, i, leftwall + 1);
                leftwall++;
            }
        }
        
        Swap(A, p, leftwall);
        return leftwall;
    }
    
    static void QuickSort(List<Node> A, int s, int e) {
        if (s < e) {
            int p = Partition(A, s, e); // Get Pivot
            QuickSort(A, s, p);
            QuickSort(A, p+1, e);
        }
    }
    
    static void Main(string[] args)
    {
        List<Node> data = new List<Node> {
            new Node(10, "Hesham"),
            new Node(5, "Ahmed"),
            new Node(7, "John"),
            new Node(8, "Eman"),
            new Node(10, "Nikki"),
            new Node(20, "Sarah"),
            new Node(9, "Mai"),
            new Node(8, "Michael"),
            new Node(4, "Fred"),
            new Node(3, "Jens")
        };
        
        // O(nlog(n)) best&average, O(n^2) worst - Not Stable - Inplace
        QuickSort(data, 0, data.Count-1);
             
        foreach (Node n in data)
            Console.Write(n.key.ToString() + "_" + n.data + " ");
    }
}
