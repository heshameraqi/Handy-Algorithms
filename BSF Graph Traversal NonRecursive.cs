################################################################################
#
# Copyright (c) 2018
# Authors:
#  Hesham M. Eraqi (heraqi@aucegypt.edu)
#
################################################################################

using System;
using System.Collections.Generic; // For Queue

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
        
        int[] order = new int[data.Length];
        Queue<int> searchQueue = new Queue<int>();
        
        int k = 0;
        searchQueue.Enqueue(k);
        while (searchQueue.Count != 0) {
            k = searchQueue.Dequeue();
            order[k] = ++current_order;
            for (int i = 0; i<data.Length; i++) //left to right (not a big difference)
                if (Adj_Matrix[i,k] && order[i] == 0) { // 0:unseen
                    searchQueue.Enqueue(i);
                    order[i] = 1; // 1:seen but waiting it's value
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
