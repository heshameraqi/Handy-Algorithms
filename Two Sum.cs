/*################################################################################
#
# Copyright (c) 2018
# Authors:
#  Hesham M. Eraqi (heraqi@aucegypt.edu)
#
# Problem:
# Given an array of integers, return indices of the two numbers such that they add up to a specific target.
# You may assume that each input would have exactly one solution, and you may not use the same element twice.
################################################################################*/

using System.Collections.Generic; // For Lists and Dictionaries

public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        // Insert elements in a hash map
        Dictionary<int, int> dict = new Dictionary<int, int>(); // Hash Map
        for (int i=0; i<nums.Length; i++)
            dict[nums[i]] = i;
        
        for (int i=0; i<nums.Length; i++) {
            int complement = target - nums[i];
            if (dict.ContainsKey(complement) && dict[complement] != i) { // Obtained complement is not nums[i] itself
                return new int[] { i, dict[complement] };
            }
        }
        return new int[] { -1, -1 }; 
    }
}
