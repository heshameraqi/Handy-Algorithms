################################################################################
#
# Copyright (c) 2020
# Authors:
#  Hesham M. Eraqi (heraqi@aucegypt.edu)
#
# Given an array of integers nums and an integer k, return the total number of continuous subarrays whose sum equals to k.
#
################################################################################

arr = [3, 2, 1, 3, 2, 5, 5, 6, 6, 5, 3, 3]
target = 6

# -------------------------------------------------------------
# O(n^2) Solution
start = 0
p_sum = 0
for end in range(len(arr)):
    p_sum += arr[end]
    if (p_sum == target):
        print("Indices from " + str(start) + " to " + str(end))
        p_sum -= arr[start]
        start += 1
    while (p_sum > target):
        p_sum -= arr[start]
        start += 1
    if (p_sum == target):  # To detect the special case if subarray length is equal to 1
        print("Indices from " + str(start) + " to " + str(end))
        p_sum -= arr[start]
        start += 1

print("----------------------------------------------------------")
# O(n) Solution: using a hash table by storing cumulative sum in another array
cum_sum = [0]
p_sum = 0
for i in range(len(arr)):
    p_sum += arr[i]
    cum_sum.append(p_sum)

# Search if 'cum_sum[j] - cum_sum[i] = target' (j>i) happens similar to the 'two sums' problem searching if sum[i] + sum[j] = target
h = {}
for i in range(len(cum_sum)):
    h[cum_sum[i]] = i

for i in range(len(cum_sum)):
    searching = target + cum_sum[i]
    if searching in h:
        if h[searching] > i:
            print("Indices from " + str(i) + " to " + str(h[searching]-1))
