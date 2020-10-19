################################################################################
#
# Copyright (c) 2020
# Authors:
#  Hesham M. Eraqi (heraqi@aucegypt.edu)
#
################################################################################

arr = [3, 2, 1, 3, 2, 5, 5, 6, 5, 3, 3]
target = 6;

start = 0
p_sum =0
for end in range(len(arr)):
    p_sum += arr[end]
    if (p_sum == target):
        print("Indices from " + str(start) + " to " + str(end))
        p_sum -= arr[start]
        start += 1
    while (p_sum > target):
        p_sum -= arr[start]
        start += 1
    if (p_sum == target): # To detect the special case if subarray length is equal to 1
        print("Indices from " + str(start) + " to " + str(end))
        p_sum -= arr[start]
        start += 1
