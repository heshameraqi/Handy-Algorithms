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
    static void Merge(List<Node> A, int s, int m, int e) {
        List<Node> B = new List<Node>(A); // Copy A to B
        List<Node> sorted_part = new List<Node>();

        List<Node> L1 = B.GetRange(s,m-s+1);
        List<Node> L2 = B.GetRange(m+1,e-(m+1)+1);
        while (L1.Count >0 && L2.Count > 0) {
            if (L1[0].key <= L2[0].key) {
                sorted_part.Add(new Node(L1[0]));
                L1.RemoveAt(0);
            }
            else {
                sorted_part.Add(new Node(L2[0]));
                L2.RemoveAt(0);
            }
        }
        
        foreach (Node n in L1)
            sorted_part.Add(n);
        foreach (Node n in L2)
            sorted_part.Add(n);
        
        // Add the sorted_part to A
        for (int i=0; i<e-s+1; i++)
            A[i+s] = sorted_part[i];
    }
    
    static void MergeSort(List<Node> A, int s, int e) {
        if (s < e) {
            int m = (e+s)/2;
            MergeSort(A, s, m);
            MergeSort(A, m+1, e);
            Merge(A, s, m, e);
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
        
        // O(nlog(n)) - Stable - Not Inplace
        MergeSort(data, 0, data.Count-1);
             
        foreach (Node n in data)
            Console.Write(n.key.ToString() + "_" + n.data + " ");
    }
}
