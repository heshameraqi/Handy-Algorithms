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
    static int Kadane(int[] A, out int startIndex, out int endIndex) {
        int maxSum = int.MinValue;
        int sum = 0;
        
        endIndex = -1;
        startIndex = -1;
        int tempStart = 0;
        for (int i = 0; i < A.Length; i++) {
            sum += A[i];
            if (sum > maxSum) {
                maxSum = sum;
                startIndex = tempStart;
                endIndex = i;
            }
            if (sum < 0) {
                sum = 0;
                tempStart = i + 1;
            }
        }
        if (endIndex != -1)
            return maxSum;
        
        // Special Case: When all numbers in arr[] are negative
        startIndex = 0;
        endIndex = 0;
        maxSum = A[0];
        for (int i = 1; i < A.Length; i++) { // Find the maximum element in array
            if (A[i] > maxSum) {
                maxSum = A[i];
                startIndex = i;
                endIndex = i;
            }
        }
        return maxSum;
    }
    
    static void Main(string[] args)
    {
        int[] A = new int[] {1, -3, 2, 1, -1};
        int startIndex;
        int endIndex;
        Kadane(A, out startIndex, out endIndex);
        Console.WriteLine("Maximum Sum Subarray starts at index " + startIndex + 
                          " and ends at index " + endIndex);
    }
}
