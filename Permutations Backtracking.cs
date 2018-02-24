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
    static void permutations_backtracking(int[] x, int[] v, int k) {
        for (int i=0; i<v.Length; i++) {
            x[k] = v[i];
            if (k == x.Length-1) {
                foreach (int s in x)
                    Console.Write(s + " ");
                Console.Write("\n");
            }
            else
                permutations_backtracking(x,v,k+1);
        }
    }
    
    static void Main(string[] args)
    {
        int[] x = new int[3];
        int[] v = {0,1};
        
        permutations_backtracking(x,v,0); // O(n^(2-1)
    }
}
