/*################################################################################
#
# Copyright (c) 2018
# Authors:
#  Hesham M. Eraqi (heraqi@aucegypt.edu)
#
################################################################################*/

# Heabsort & Mergesort are O(nlog(n)) but are not inplace. Heabsort is not stable, merge sort is stable.
# Quick sort is O(n^2) but in-place.

using System;
using System.Collections.Generic; // For Dictionary and List

class Node {
    public int key;
    public string data;
    
    public Node(int k, string s) {
       this.key = k;
       this.data = s;
   }
    
    public Node(Node otherNode) { // Copy constructor
        this.key = otherNode.key;
        this.data = otherNode.data;
    }
}

// To execute C#, please define "static void Main" on a class
// named Solution.

class Solution
{
    static void Swap(List<Node> A, int x, int y) { //function to swap elements
        Node temp = A[x];
        A[x] = A[y];
        A[y] = temp;
    }
    
    static void HeapifyParent(List<Node> A, int index) {
        int left = 2*index + 1;
        int right = 2*index + 2;
        int smallest = index;
        
        if (left<= A.Count-1 && A[left].key < A[index].key) //left<= n-1 means it exist
            smallest = left;
        if (right<= A.Count-1 && A[right].key < A[smallest].key) //right<= n-1 means it exist
            smallest = right;

        if (smallest != index) {
            Swap(A, index, smallest);
            HeapifyParent(A, smallest);
        }
    }
    
    static void BuildHeap(List<Node> A, int index) { // T(n) = 2T(n/2)+log(n) = O(n)
        int n = A.Count;
        if (index <= n/2) { //row before last
            if (index*2+1 <= n-1) // Left cild exist
                BuildHeap(A, index*2+1); // First child
            if (index*2+2 <= n-1) // Right cild exist
                BuildHeap(A, index*2+2); // Second child
            HeapifyParent(A, index);
        }
    }
    
    static Node DeleteMin(List<Node> A) {
        Node min = new Node(A[0]);
        A[0] = A[A.Count-1]; // Get the last to the root
        A.RemoveAt(A.Count-1);
        if (A.Count > 0) // A wasn't a single element tree
            HeapifyParent(A, 0);
        return min;
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
  
        // 1. BuildHeap
        BuildHeap(data, 0);
        
        // Print the heap array
        foreach (Node n in data)
            Console.Write(n.key.ToString() + "_" + n.data + " ");
        
        // 2. HeapSort nlog(n) - Not Stable - Not Inplace
        List<Node> sorted_data = new List<Node>();
        int original_dataCount = data.Count;
        for (int i=0; i<original_dataCount; i++)
            sorted_data.Add(DeleteMin(data));
        
        // Print sorted array
        Console.Write("\n");
        foreach (Node n in sorted_data)
            Console.Write(n.key.ToString() + "_" + n.data + " ");
    }
}
