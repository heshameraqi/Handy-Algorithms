################################################################################
#
# Copyright (c) 2020
# Authors:
#  Hesham M. Eraqi (heraqi@aucegypt.edu)
#
# Mergesort: O(nlog(n)) - Stable (similar keys retains their initial order) - Not Inplace
# Heapsort: O(nlog(n)) - Not Stable - Not Inplace
# Quicksort: O(n^2) worst (O(nlog(n)) best&average) - Not Stable - Inplace
################################################################################
class Node:
    def __init__(self, key, data):
        self.key = key
        self.data = data

# --------------------------------------------------------------------
        
def merge_sort(data, s, e):
    if e > s: # 2 elements or more
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

# --------------------------------------------------------------------

def swap(data, i, j):
    temp = data[i]
    data[i] = data[j]
    data[j] = temp
    
def partition(data, s, e): # Take first element at s (pivot) (randmly choosing 3 elements and make their medianthe pivot increases the changes of half split and hence better runtime) and put it in correct place (leftwall)
    p = s # Pivot
    # make all items smaller than pivot before it
    leftwall = s;
    for i in range(s+1, e+1):
        if data[i].key < data[p].key:
            leftwall += 1
            swap(data, i, leftwall)
    swap(data, p, leftwall)
    return leftwall
    
def quick_sort(data, s, e):
       if e > s: # 2 elements or more
            p = partition(data, s, e)
            quick_sort(data, s, p)
            quick_sort(data, p+1, e)

# --------------------------------------------------------------------

def build_heap(data, index): # T(n) = 2T(n/2)+log(n) = O(n), index is the parent to start from
        n = len(data)
        if index <= (n-1)/2: # until before last row in the heap tree
            if index*2+1 <= n-1: # Left cild exist
                build_heap(data, index*2+1); # First child
            if index*2+2 <= n-1: # Right cild exist
                build_heap(data, index*2+2) # Second child
            heapify_parent(data, index)

def heapify_parent(data, index): # O(log(n))
    left = 2*index + 1
    right = 2*index + 2
    smallest = index

    if left <= len(data)-1 and data[left].key < data[index].key: # left<= n-1 means it exist
        smallest = left
    if right <= len(data)-1 and data[right].key < data[smallest].key: # right<= n-1 means it exist
        smallest = right

    if smallest != index:
        swap(data, index, smallest)
        heapify_parent(data, smallest) # Recursively heapify the affected sub-tree 
    
def delete_min(data): # O(lon(n))
        min_node = Node(data[0].key, data[0].data)
        data[0] = data[len(data)-1] # Get the last to the root
        data.pop(len(data)-1)
        if len(data) > 0: # A wasn't a single element tree
            heapify_parent(data, 0)
        return min_node

def heap_sort(data):
    build_heap(data, 0) # O(n)
    sorted_data = []
    count = len(data)
    for i in range(count):
        sorted_data.append(delete_min(data)) # O(lon(n))
    print([str(sorted_data[i].key) + " " + sorted_data[i].data for i in range(len(sorted_data))])

# --------------------------------------------------------------------
        
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
quick_sort(data, 0, len(data)-1)  # takes start and end indices
print([str(data[i].key) + " " + data[i].data for i in range(len(data))])

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
heap_sort(data)  # does the printing
