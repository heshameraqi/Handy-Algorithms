################################################################################
#
# Copyright (c) 2020
# Authors:
#  Hesham M. Eraqi (heraqi@aucegypt.edu)
#
################################################################################

# merge_sort: O(nlog(n)) - Stable (similar keys retains their initial order) - Not In-place
# quick_sort: O(n^2) worst (O(nlog(n)) best&average) - Not Stable - In-place
# heap_sort: O(nlog(n)) - Not Stable - Not In-place

class Node():
    def __init__(self, key, data):
        self.key = key
        self.data = data

# --------------------------------------------------
        
def merge(data, s, m, e):
    L1 = data[s:m+1]
    L2 = data[m+1:e+1]
    
    pos1 = 0
    pos2 = 0
    sorted = []
    while (pos1<len(L1) and pos2<len(L2)):
        if L1[pos1].key <= L2[pos2].key:
            sorted.append(L1[pos1])
            pos1 += 1
        else:
            sorted.append(L2[pos2])
            pos2 += 1
    while pos1<len(L1):
        sorted.append(L1[pos1])
        pos1 += 1
    while pos2<len(L2):
        sorted.append(L2[pos2])
        pos2 += 1
        
    data[s:e+1] = sorted
    
def merge_sort(data, s, e):
    if e>s: # More than 1 element
        m = s + int((e-s)/2)
        merge_sort(data, s, m)
        merge_sort(data, m+1, e)
        merge(data, s, m, e)
    
# --------------------------------------------------

# Take first element at s (pivot) (randmly choosing 3 elements and make their median the pivot increases the changes of half split and hence better runtime), and put it in correct place (leftwall)
def partition(data, s, e):
    pivot = data[s]
    left_wall = s
    for i in range(s+1, e+1):
        if pivot.key > data[i].key:
            d = data[i]
            data.pop(i)
            data.insert(s, d)
            left_wall += 1
    return left_wall
    
def quick_sort(data, s, e):
    if e>s: # More than 1 element
        p = partition(data, s, e)
        quick_sort(data, s, p-1)
        quick_sort(data, p+1, e)
        
# --------------------------------------------------

def heapify_parent(data, p): # O(log(n))
    if (2*p+1 < len(data)): # there is a left child at least
        left_child = 2*p+1
        if 2*p+2 < len(data): # has a right child
            right_child = 2*p+2
            smallest = left_child if data[left_child].key <= data[right_child].key else right_child
        else:
            smallest = left_child

        if data[smallest].key < data[p].key:
            temp = data[p]
            data[p] = data[smallest]
            data[smallest] = temp
            heapify_parent(data, smallest)
    
def build_heap(data, p): # O(n) --> T(n) = 2T(n/2)+log(n) = O(n)
    if (2*p+1 < len(data)): # there is a left child at least
        build_heap(data, 2*p+1)
        build_heap(data, 2*p+2)
        heapify_parent(data, p)
        
def delete_min(data): # O(log(n))
    d = data[0]
    data.pop(0)
    
    # Get the last to the root & heapify
    if len(data) > 1 : # there are more than 1 item
        last = data[-1]
        data.pop(len(data)-1)
        data.insert(0, last)
        heapify_parent(data, 0)
    
    return d
    
def heap_sort(data):
    build_heap(data, 0) # O(n)
    sorted_data = []
    while len(data) > 0:
        sorted_data.append(delete_min(data))
    print([str(d.key) + " " + d.data for d in sorted_data])
    
# --------------------------------------------------

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
merge_sort(data, 0, len(data)-1)
print([str(d.key) + " " + d.data for d in data])

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
quick_sort(data, 0, len(data)-1)
print([str(d.key) + " " + d.data for d in data])

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
heap_sort(data) # Also prints
