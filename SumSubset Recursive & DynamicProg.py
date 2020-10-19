################################################################################
#
# Copyright (c) 2020
# Authors:
#  Hesham M. Eraqi (heraqi@aucegypt.edu)
#
################################################################################

import numpy as np

def subset_sum_db(arr, sum):
    # A column for each sum value (sub problem)
    
    # Example:
    # arr = [3, 34, 4, 12, 2, 5]
    #      0       1        2        3        4        5        ...    sum
    # -    true    false    false    false    false    false    false  false
    # 3    true    FALSE    FALSE    TRUE     FALSE    FALSE    ...
    # 34   true    FALSE    FALSE    TRUE     FALSE    FALSE    ...
    # 4    true    FALSE    FALSE    TRUE     TRUE     FALSE    ...
    # 12   true    FALSE    FALSE    TRUE     TRUE     FALSE    ...
    # 2    true    FALSE    *TRUE*   TRUE     TRUE     *TRUE*   ...
    # 5    true    FALSE    TRUE     TRUE     TRUE     TRUE     ...
    # ...
    mat = np.zeros((len(arr)+1, sum+1), dtype=bool)
    for c in range(mat.shape[1]): # Empty array case
        mat[0,c] = False
    for r in range(mat.shape[0]): # Base conditions (overrides previous loop) 
        mat[r,0] = True
        
    for c in range(1, mat.shape[1]):
         for r in range(1, mat.shape[0]):
                mat[r,c] = mat[r-1, c] or ( (c-arr[r-1])>=0 and mat[r-1, c-arr[r-1]] )
    # print(mat)
    return mat[-1,-1]

def subset_sum_recursive(arr, sum):
    if sum == 0: # Base conditions (overrides the next condition) 
        return True
    if not arr: # Empty array case
        return False
    elif sum>0:
        # last element complete the sum OR the array before last element satisfy sum alread 
        return subset_sum_recursive(arr[:-1], sum-arr[-1]) or subset_sum_recursive(arr[:-1], sum)
    else:
        return False

arr = [3, 34, 4, 12, 2, 5]
sum = 13  # 13->False  9->True
print(subset_sum_db(arr, sum))
print(subset_sum_recursive(arr, sum))
