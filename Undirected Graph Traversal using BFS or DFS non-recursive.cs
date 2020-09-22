/*################################################################################
#
# Copyright (c) 2018
# Authors:
#  Hesham M. Eraqi (heraqi@aucegypt.edu)
#
################################################################################*/

using System;
using System.Collections.Generic; // For Queue (for BFS) & Stack (for DFS)

class Solution
{       
    static int current_order = 0;
    
    static void Main(string[] args)
    {
        string[] data = new string[] {"A","B","C","D","E","F","G"};
        bool[,] Adj_Matrix = new bool[,] { 
            {false, true, true, false, false, true, true},
            {true, false, false, false, false, false, false},
            {true, false, false, false, false, false, false},
            {false, false, false, false, true, true, false},
            {false, false, false, true, false, true, true},
            {true, false, false, true, true, false, false},
            {true, false, false, false, true, false, false} };
        bool BFS = false; // false if DFS is needed
        
        int[] order = new int[data.Length];
        if (BFS) {
            Queue<int> searchQueue = new Queue<int>();
            int k = 0;
            searchQueue.Enqueue(k);
            while (searchQueue.Count != 0) {
                k = searchQueue.Dequeue();
                order[k] = ++current_order;
                for (int i = 0; i<data.Length; i++) //left to right (more accurate than the opposite)
                    if (Adj_Matrix[i,k] && order[i] == 0) { // 0:unseen
                        searchQueue.Enqueue(i);
                        order[i] = -1; // -1:seen but waiting it's value
                    }
            }
        }
        else { // DFS
            Stack<int> searchStack = new Stack<int>();
            int k = 0;
            searchStack.Push(k);
            while (searchStack.Count != 0) {
                k = searchStack.Pop();
                order[k] = ++current_order;
                for (int i = data.Length-1; i>=0; i--) //right to left
                    if (Adj_Matrix[i,k] && order[i] == 0) { // 0:unseen
                        searchStack.Push(i);
                        order[i] = -1; // -1:seen but waiting it's value
                    }

            }
        }

        // Print current_order of visit
        foreach (string s in data)
            Console.Write(s + " ");
        Console.Write("\n");
        foreach (int v in order)
            Console.Write(v + " ");
    }
}
