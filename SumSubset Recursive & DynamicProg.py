################################################################################
#
# Copyright (c) 2020
# Authors:
#  Hesham M. Eraqi (heraqi@aucegypt.edu)
#
################################################################################

# Using Divide and Conquer (implemented by recursion)
# Worst case complexity: O(2^n) (exponential, it's NP-complete problem: no polynomial time solution exists)
# Each item can be chosen or not
def subset_sum_recursive(arr, sum):
    # Base Cases
    if sum == 0: 
        return True
    if not arr: # Array is empty (and still searching for a sum)
        return False

    return subset_sum_recursive(arr[0:-1], sum-arr[-1]) or subset_sum_recursive(arr[0:-1], sum)

# Dynamic Programming (Used when solutions of the same subproblems are needed again and again)
# Canbe used when there are 1) Overlapping Subproblems and the problem has 2) Optimal Substructure property
# In dynamic programming, computed solutions to subproblems are stored in a table so that these don’t have to be recomputed. So Dynamic Programming is not useful when there are no common (overlapping) subproblems because there is no point storing the solutions if they are not needed again.
# To use DP, Optimal Substructure Property should be true for the problem: Optimal solution of the given problem can be obtained by using optimal solutions of its subproblems. 
# Worst case complexity: O(sum*n)
# Example to understand:
    # arr = [3, 34, 4, 12, 2, 5]
    #         EmptyArray   3       34       4       12       2       5       ...
    # 0       true         true    true     true    true     true    true
    # 1       false        FALSE   FALSE    FALSE   FALSE    FALSE   FALSE
    # 2       false        FALSE   FALSE    FALSE   FALSE    *TRUE*  TRUE
    # 3       false        TRUE    TRUE     TRUE    TRUE     TRUE    TRUE
    # 4       false        FALSE   FALSE    *TRUE*  TRUE     TRUE    TRUE
    # 5       false        FALSE   FALSE    FALSE   FALSE    *TRUE*  TRUE
    # ...     false        ...     ...      ...     ...      ...     ...
    # sum     false        ...     ...      ...     ...      ...     ...
import numpy as np
def subset_sum_db(arr, sum):
    M = np.zeros((sum+1, len(arr)+1), dtype=bool)
    M[:,0] = False
    M[0,:] = True

    for s in range(1, sum+1):
        for e in range(1, len(arr)+1):
            M[s,e] = M[s, e-1] or ( (s-arr[e-1])>=0 and M[s-arr[e-1],e-1]) # (s-arr[e-1])>=0 is a protection condition

    return M[-1,-1]

arr = [3, 34, 4, 12, 2, 5]
sum = 34 # 13->False  9->True

print(subset_sum_recursive(arr, sum))
print(subset_sum_db(arr, sum))
