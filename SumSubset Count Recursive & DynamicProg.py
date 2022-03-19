################################################################################
#
# Copyright (c) 2022
# Authors:
#  Hesham M. Eraqi (heraqi@aucegypt.edu)
#
################################################################################

# Complexity O(2^N) (exponential) since for the ‘N’ number of elements we have two possible choices to either include or exclude it.
def subsetSumCount_recursive(arr, sum):
    # Base Cases
    if sum == 0:
        return 1
    if not arr:
        return 0
    return subsetSumCount_recursive(arr[0:-1], sum) + subsetSumCount_recursive(arr[0:-1], sum-arr[-1])

# Complexity: O(sum*n)
import numpy as np
def subsetSumCount_db(arr, sum):
    M = np.zeros((sum+1, len(arr)+1))
    M[0,:] = 1

    for s in range(1, sum+1):
        for e in range(1, len(arr)+1):
            if (s-arr[e-1])>=0: # Index protection for the second operand in the addition below
                M[s,e] = M[s, e-1] + M[s-arr[e-1], e-1]
            else:
                M[s,e] = M[s, e-1]
    # print(M)
    return M[-1,-1]


arr = [2, 3, 5, 6, 8, 10]
sum = 10 # output should be 3 (All possible subsets with sum 10 are {2, 3, 5}, {2, 8}, {10})
print(subsetSumCount_recursive(arr, sum))
print(subsetSumCount_db(arr, sum))

arr = [1, 4, 3, 2]
sum = 5 # output should be 2
print(subsetSumCount_recursive(arr, sum))
print(subsetSumCount_db(arr, sum))

arr = [3, 3, 3, 3]
sum = 6 # output should be 6
print(subsetSumCount_recursive(arr, sum))
print(subsetSumCount_db(arr, sum))
