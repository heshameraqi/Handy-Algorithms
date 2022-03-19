################################################################################
#
# Copyright (c) 2022
# Authors:
#  Hesham M. Eraqi (heraqi@aucegypt.edu)
#
# Given an array of integers nums and an integer k, return the total number of continuous subarrays whose sum equals to k.
#
################################################################################

arr = [3, 2, 1, 3, 2,  5, 5, 6, 6, 5, 3, 3]
target = 6

# -------------------------------------------------------------
# O(n^2) Solution
for s in range(len(arr)):
    sum = arr[s]
    e = s
    if sum == target: # If single element sum to target
        print("Target sum is in index %d"%(s))
    while sum <= target and (e+1)<len(arr):
        e += 1
        sum += arr[e]
        if sum == target:
            print("Target sum between index %d and %d"%(s, e))

# -------------------------------------------------------------
# O(n) Solution: using a hash table by storing cumulative sum in another array
#arr     = [3, 2, 1, 3, 2,  5,  5,  6,  6, 5, 3, 3]
#acc_arr = [3, 5, 6, 9, 11, 16, 21, 27, ...]
acc_arr = []
acc_sum = 0
H = {}
for i in range(len(arr)):
    acc_sum += arr[i]
    acc_arr.append(acc_sum)
    H[acc_sum] = i

for i in range(len(acc_arr)):
    searching = acc_arr[i] - target
    if (searching in H) and (H[searching]<i):
        print("Target sum between index %d and %d"%(H[searching]+1, i))
    if acc_arr[i] == target: # special case if starting with first index can lead to target
        print("Target sum between index 0 and %d"%(i))

# -------------------------------------------------------------
# O(n^2) Solution (another style)
start = 0
p_sum = 0
for end in range(len(arr)):
    p_sum += arr[end]
    if (p_sum == target):
        print("Target sum between index " + str(start) + " and " + str(end))
        p_sum -= arr[start]
        start += 1
    while (p_sum > target):
        p_sum -= arr[start]
        start += 1
    if (p_sum == target):  # To detect the special case if subarray length is equal to 1
        print("Target sum between index " + str(start) + " and " + str(end))
        p_sum -= arr[start]
        start += 1
