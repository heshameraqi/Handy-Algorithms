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
    // Returns number of pairs in A[0..n-1] with sum equal to 'sum'
    static int getPairsCount(int[] A, int sum) {
        // Store counts of all elements in hash
        Dictionary<int, int> dict = new Dictionary<int, int>();
        for (int i=0; i<A.Length; i++)
            if (dict.ContainsKey(A[i]))
                dict[A[i]]++;
            else
                dict[A[i]] = 1;

        // iterate through each element and increment the
        // count (Notice that every pair is counted twice)
        int twice_count = 0;
        for (int i=0; i<A.Length; i++)
        {
            if (dict.ContainsKey(sum-A[i]))
                twice_count += dict[sum-A[i]];

			// if (A[i], A[i]) pair satisfies the condition,
            // then we need to ensure that the count is
            // decreased by one such that the (A[i], A[i])
            // pair is not considered
            if (sum-A[i] == A[i])
                twice_count--;
        }

        return twice_count/2;
    }
    
    static void Main(string[] args)
    {
        int[] A = new int[] {1, 2, 5, 7, -1, 5};
        int sum = 6;
        Console.WriteLine("Count of pairs is " + getPairsCount(A, sum));
    }
}
