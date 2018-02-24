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
    
    static int knapsack_recursive(int[] w, int[] v, int n, int m) {
        if (n > 0) {
            int p = knapsack_recursive(w, v, n-1, m);
            if (w[n-1] <= m)
                p = Max(p, knapsack_recursive(w, v, n-1, m-w[n-1])+v[n-1]);
            return p;
        }
        else
            return 0;
    }
    
    static int knapsack_dynamicProg(int[] w, int[] v, int m) {
        int[,] p = new int[w.Length+1,m+1]; // By default 0's
        for (int i=1; i<p.GetLength(0); i++)
            for (int j=0; j<p.GetLength(1); j++) {
                p[i,j] = p[i-1,j];
                if (j >= w[i-1]) p[i,j] = Max(p[i-1,j],  p[i-1,j-w[i-1]]+v[i-1]);
            }
        return p[w.Length,m];
    }
    
    static void Main(string[] args)
    {
        int[] w = {2,1,3,2};
        int[] v = {12,10,20,15};
        int m = 5;
        
        Console.WriteLine(knapsack_recursive(w,v,w.Length,m)); // O(n^2)
        Console.WriteLine(knapsack_dynamicProg(w,v,m));
    }
}
