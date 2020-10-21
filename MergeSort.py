################################################################################
#
# Copyright (c) 2020
# Authors:
#  Hesham M. Eraqi (heraqi@aucegypt.edu)
#
# Mergesort: O(nlog(n)) - Stable (similar keys retains their initial order) - Not Inplace
# Quicksort: O(n^2) worst (O(nlog(n)) best&average) - Not Stable - Inplace
#
################################################################################
class Node:
    def __init__(self, key, data):
        self.key = key
        self.data = data

def merge_sort(data, s, e):
    if e > s: # Not a single element
        m = s + int((e - s)/2)
        merge_sort(data, s, m) # First part might be larger by 1
        merge_sort(data, m+1, e)
        merge(data, s, m, e)
        
def merge(data, s, m, e):
    data_copy = data.copy()
    L1 = data_copy[s:m+1]
    L2 = data_copy[m+1:e+1]
    sorted_part = []
    while (len(L1) >0 and len(L2) > 0):
        if (L1[0].key <= L2[0].key):
            sorted_part.append(Node(L1[0].key, L1[0].data))
            L1.pop(0)
        else:
            sorted_part.append(Node(L2[0].key, L2[0].data))
            L2.pop(0)
    for n in L1:
        sorted_part.append(n)
    for n in L2:
        sorted_part.append(n)

    # Add the sorted_part to A
    for i in range(len(sorted_part)):
        data[i+s] = sorted_part[i]
        
data = [Node(10, "Hesham"),
        Node(5, "Ahmed"),
        Node(7, "John"),
        Node(8, "Eman"),
        Node(10, "Nikki"),
        Node(20, "Sarah"),
        Node(9, "Mai"),
        Node(8, "Michael"),
        Node(4, "Fred"),
        Node(3, "Jens")]
merge_sort(data, 0, len(data)-1)  # takes start and end indices
print([str(data[i].key) + " " + data[i].data for i in range(len(data))])
