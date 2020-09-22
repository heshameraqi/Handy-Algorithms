/*################################################################################
#
# Copyright (c) 2018
# Authors:
#  Hesham M. Eraqi (heraqi@aucegypt.edu)
#
################################################################################*/

using System;

class Solution
{       
    static int Max(int x, int y) {
        return (x >= y) ? x : y;
    }
    
    static int knapsack_recursive(int[] w, int[] v, int n, int c) {
        // n is number of remaining items to decide to put or not
        // c is the remaning weight capacity
        if (n > 0 && c > 0) {
            int current_v = knapsack_recursive(w, v, n-1, c); // value for not putting the item given optimal decisions before
            if (w[n-1] <= c)  // I can take that item
                current_v = Max(current_v, // not taking it
                        knapsack_recursive(w, v, n-1, c-w[n-1]) + v[n-1]); // taking it
            return current_v;
        }
        else
            return 0;
    }
    
    static int knapsack_dynamicProg(int[] w, int[] v, int c) {
        int[,] current_v = new int[w.Length+1,c+1]; // By default 0's
        int item_i_weight = 0;
        int item_i_value = 0;
        for (int i=1; i<current_v.GetLength(0); i++) {
            item_i_weight = w[i-1];
            item_i_value = v[i-1];
            for (int j=1; j<current_v.GetLength(1); j++) {
                if (j >= item_i_weight) current_v[i,j] = Max(current_v[i-1,j], current_v[i-1,j-item_i_weight]+item_i_value); // Take it or not
                else
                    current_v[i,j] = current_v[i-1,j]; // Won't take it
            }
        }
        return current_v[w.Length,c];
    }
    
    static void Main(string[] args)
    {
        int[] w = {2,1,3,2};
        int[] v = {12,10,20,15};
        int c = 5;
        
        Console.WriteLine(knapsack_recursive(w,v,w.Length,c)); // O(n^2)
        Console.WriteLine(knapsack_dynamicProg(w,v,c));  // // O(nc), linear in n
    }
}
