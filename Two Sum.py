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

x_hash = {}

for i in range(len(x)):
    x_hash[x[i]] = 0
    
for i in range(len(x)):
    rem = target-x[i]
    if rem in x_hash:
        print(str(x[i]) + " " + str(rem))
