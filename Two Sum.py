################################################################################
#
# Copyright (c) 2018
# Authors:
#  Hesham M. Eraqi (heraqi@aucegypt.edu)
#
# Problem:
# Given an array of integers, return indices of the two numbers such that they add up to a specific target.
# You may assume that each input would have exactly one solution, and you may not use the same element twice.
################################################################################

x = [2, 4, 1, 5, 10, 6]
target = 10

# A hash table (dictionary in python) (if we don't want to report the indices, we don't need to store any values in our hash table which means it's better be a hash set)
#   has set in python is a set like: my_set = {1, 2, 3}
h = {} #value (because later I ask: does that value exist in the array in O(1)) to index
for i in range(len(x)):
    h[x[i]] = i
    
for i in range(len(x)):
    rem = target - x[i]
    if rem in h:
        print('Found at indicies %d and %d' % (i, h[rem]))
