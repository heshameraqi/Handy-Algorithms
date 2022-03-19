################################################################################
#
# Copyright (c) 2022
# Authors:
#  Hesham M. Eraqi (heraqi@aucegypt.edu)
#
################################################################################

# Time Complexity is O(n)

# Input : 1->2->3->4->5->6->NULL 
# Output : 2->1->4->3->6->5->NULL

# Input : 1->2->3->4->5->NULL 
# Output : 2->1->4->3->5->NULL

# Input : 1->NULL 
# Output : 1->NULL 

class Node:
    def __init__(self, data):
        self.data = data
        self.next = None
 
class LinkedList:
    def __init__(self):
        self.head = None

    def pairwiseSwap(self):
        temp = self.head

        if temp is None:
            return
 
        while(temp and temp.next):
            if(temp.data != temp.next.data):
                temp.data, temp.next.data = temp.next.data, temp.data
            temp = temp.next.next
 
    def push(self, new_data):
        new_node = Node(new_data)
        new_node.next = self.head
        self.head = new_node
 
    def printList(self):
        temp = self.head
        while(temp):
            print temp.data,
            temp = temp.next
 
 
# Driver program
llist = LinkedList()
llist.push(5)
llist.push(4)
llist.push(3)
llist.push(2)
llist.push(1)
 
print "Linked list before calling pairWiseSwap() "
llist.printList()
 
llist.pairwiseSwap()
 
print "\nLinked list after calling pairWiseSwap()"
llist.printList()
