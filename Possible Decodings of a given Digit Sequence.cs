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
    static int countDecoding_recursive(string code, int n) { // = PART1 + PART2
        if (n == 0 || n == 1) // base cases
            return 1;

        // If the last digit is not 0, then last digit must add to the number of words 
        int count = 0;
        if (code[n-1] > '0')
            count = countDecoding_recursive(code, n-1); // PART1

        // If the last two digits form a number smaller than or equal to 26, then consider last two digits and recur
        if ( code[n-2] == '1' || (code[n-2] == '2' && code[n-1] < '7') )
            count += countDecoding_recursive(code, n-2); // PART2

        return count;
    }
                    
    static void Main(string[] args) // O(n^2)
    {
        string code = "1234";
        Console.WriteLine(countDecoding_recursive(code, code.Length));
    }
}
