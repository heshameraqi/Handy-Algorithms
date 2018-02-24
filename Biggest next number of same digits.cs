/*################################################################################
#
# Copyright (c) 2018
# Authors:
#  Hesham M. Eraqi (heraqi@aucegypt.edu)
#
################################################################################*/

using System;
using System.Text; // For StringBuilder

class Solution
{
    static int FindPivot(string num) {
        for (int i=num.Length-1; i>=1; i--) {
            if ( Convert.ToInt32(num[i-1]) < Convert.ToInt32(num[i]) )
                return i-1;
        }
        return -1;
    }
    
    static void Main(string[] args) // If number is 9876 it's the result already
    {
        //string num = Console.ReadLine();
        string num = "98791"; // 53921->59123 98791->98971
        StringBuilder result = new StringBuilder(num);
        int p_idx = Solution.FindPivot(num);
        if (p_idx != -1) {
            // Get lowest_biggest_right_idx
            int lowest_biggest_right_idx = p_idx+1;
            for (int i = p_idx+2; i < num.Length; i++)
                if (Convert.ToInt32(num[i]) > Convert.ToInt32(num[p_idx]) && 
                    Convert.ToInt32(num[i]) < Convert.ToInt32(num[lowest_biggest_right_idx]))
                    lowest_biggest_right_idx = i;
            
            Console.WriteLine(p_idx); // For Debugging
            Console.WriteLine(lowest_biggest_right_idx); // For Debugging
            
            // Swap
            char temp = num[lowest_biggest_right_idx];
            result[lowest_biggest_right_idx] = num[p_idx];
            result[p_idx] = temp;
            
            // Sort
            string toSort = result.ToString().Substring(lowest_biggest_right_idx);
            
            char[] toSort_array = toSort.ToCharArray();
            Array.Sort(toSort_array);
            toSort = new string(toSort_array);
            
            result.Remove(lowest_biggest_right_idx, toSort.Length);
            result.Append(toSort);
        }
        
        Console.WriteLine(result.ToString());
    }
}
