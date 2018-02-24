/*################################################################################
#
# Copyright (c) 2018
# Authors:
#  Hesham M. Eraqi (heraqi@aucegypt.edu)
#
################################################################################*/

using System;

// To execute C#, please define "static void Main" on a class
// named Solution.

class Solution
{
    static void Main(string[] args)
    {
        int[] arr = new int[] {3,2,1,3,2,5,5,6,5};
        int sum = 6;
        
        int curr_sum = arr[0], start = 0;
 
        /* Add elements one by one to curr_sum and if the curr_sum exceeds the sum, then remove starting element */
        for (int i = 1; i <= arr.Length; i++) {
            // If curr_sum exceeds the sum, then remove the starting elements
            while (curr_sum > sum) {
                curr_sum = curr_sum - arr[start];
                start++;
            }

            // If curr_sum becomes equal to sum, then return true
            if (curr_sum == sum)
                Console.WriteLine(String.Format("Sum found between indexes {0} and {1}", start, i-1));

            // Add this element to curr_sum
            if (i < arr.Length)
              curr_sum = curr_sum + arr[i];
        }
    }
}
