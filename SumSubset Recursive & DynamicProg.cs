################################################################################
#
# Copyright (c) 2018
# Authors:
#  Hesham M. Eraqi (heraqi@aucegypt.edu)
#
################################################################################

using System;
using System.Collections.Generic; // For Lists and Dictionaries

class Solution
{     
    static bool SumSub_recursive(int[] w, int i, int j) {
        if (i == 0) return (j == 0);
        else
            if (SumSub_recursive(w, i-1, j)) return true;
            else if ((j - w[i]) >= 0)  return SumSub_recursive(w, i-1, j - w[i]);
            else return false;
    }
    
    
    static bool SumSub_dynamicProg(int[] w, int m) {
        bool[,] t = new bool[w.Length+1,m+1]; // By default false's
        t[0,0] = true;
        for (int i=1; i<t.GetLength(0); i++)
            for (int j=0; j<t.GetLength(1); j++) {
                t[i,j] = t[i-1,j];
                if (j >= w[i-1]) t[i,j] = t[i-1,j] || t[i-1,j-w[i-1]];
            }
        return t[w.Length,m];
    }
    
    static void Main(string[] args)
    {
        int[] w = {5,2,3,7,8,2};
        int m = 6; // 6->No , 4->Yes
        
        Console.WriteLine(SumSub_recursive(w,w.Length-1,m) ? "Yes":"No");
        Console.WriteLine(SumSub_dynamicProg(w,m) ? "Yes":"No");
    }
}
