################################################################################
#
# Copyright (c) 2018
# Authors:
#  Hesham M. Eraqi (heraqi@aucegypt.edu)
#
################################################################################

using System;
using System.Collections.Generic; // For Stack

class Solution
{       
    static int current_order = 0;
    static void Visit(int k, ref int[] order, bool[,] Adj_Matrix)
    {
        order[k] = ++current_order;
        for (int i = 0; i<order.Length; i++)
            if (Adj_Matrix[i,k])
                if (order[i] == 0) Visit(i, ref order, Adj_Matrix);
    }
    
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
        
    
        int[] order = new int[data.Length]; // zeros means unvisited
        for (int i = 0; i<data.Length; i++)
            if (order[i] == 0) Visit(i, ref order, Adj_Matrix);
        
        // Print current_order of visit
        foreach (string s in data)
            Console.Write(s + " ");
        Console.Write("\n");
        foreach (int v in order)
            Console.Write(v + " ");
    }
}
