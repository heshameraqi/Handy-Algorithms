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
    // O(n) It's considered a Dynamic Programming algorithm
    static int Kadane(List<int> A, out int startIndex, out int endIndex) {
        int maxSum = int.MinValue;
        int sum = 0;
        
        endIndex = -1;
        startIndex = -1;
        int tempStart = 0;
        for (int i = 0; i < A.Count; i++) {
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
        for (int i = 1; i < A.Count; i++) { // Find the maximum element in array
            if (A[i] > maxSum) {
                maxSum = A[i];
                startIndex = i;
                endIndex = i;
            }
        }
        return maxSum;
    }
    
    static void FindMaxSum(int[,] M) {
        // Variables to store the final output
        int maxSum = int.MinValue;
        int finalLeft, finalRight, finalTop, finalBottom;
        finalLeft = finalRight = finalTop = finalBottom = 0;

        int sum, start, finish;
        sum = start = finish = 0;
        for (int left = 0; left < M.GetLength(1); left++) {
            List<int> temp = new List<int>(new int[M.GetLength(0)]);
            for (int right = left; right < M.GetLength(1); right++) {
               // Calculate sum between current left and right for every row 'i'
                for (int i = 0; i < M.GetLength(0); i++)
                    temp[i] += M[i,right];

                sum = Kadane(temp, out start, out finish);
                
                // Compare sum with maximum sum so far. If sum is more, then 
                // update maxSum and other output values
                if (sum > maxSum) {
                    maxSum = sum;
                    finalLeft = left;
                    finalRight = right;
                    finalTop = start;
                    finalBottom = finish;
                }
            }
        }

        // Print final values
        Console.WriteLine("(Top,Left) = " + finalTop + "," + finalLeft);
        Console.WriteLine("(Bottom,Right) = " + finalBottom + "," + finalRight);
        Console.WriteLine("Max sum = " + maxSum);
    }
    
    static void Main(string[] args)
    {
        int[,] M = new int[,] {{1, 2, -1, -4, -20},
                               {-8, -3, 4, 2, 1},
                               {3, 8, 10, 1, 3},
                               {-4, -1, 1, 7, -6}
                              }; // M.GetLength(0) is the number of rows
        
        FindMaxSum(M);
        //Kadane(A, out startIndex, out endIndex);
    }
}
