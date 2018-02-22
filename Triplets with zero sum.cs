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
    static void findTriplets(int[] arr) {
        bool found = false;
        for (int i=0; i<arr.Length-1; i++) {
            // Find all pairs with sum equals to "-arr[i]"
            HashSet<int> hashSet = new HashSet<int>();
            for (int j=i+1; j<arr.Length; j++) {
                int x = -arr[i] -arr[j];
                if ( hashSet.Contains(x) ) {
                    Console.WriteLine(x + " " + arr[i] + " " + arr[j]);
                    found = true;
                }
                else
                    hashSet.Add(arr[j]);
            }
        }

        if (found == false)
            Console.WriteLine("No Triplet Found");
    }
    
    static void Main(string[] args)
    {
        int[] arr = new int[] {0, -1, 2, -3, 1};
        findTriplets(arr);
    }
}
