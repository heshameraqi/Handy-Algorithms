################################################################################
#
# Copyright (c) 2018
# Authors:
#  Hesham M. Eraqi (heraqi@aucegypt.edu)
#
################################################################################

using System;

public class Node {
    public Node Next;
    public object Value;
}

public class LinkedList {
   private Node head;
   private Node last_node;
   public int Count;
    
   public LinkedList() {
       head = null;
       last_node = head;
       Count = 0;
   }
    
   public void AddAtLast(object data) {
       Node newNode = new Node() { Value = data};
       if (head != null) {
           last_node.Next = newNode;
           last_node = newNode;
       }
       else {
           last_node = newNode;
           head = newNode;
       }
       Count++;
    }
    
    public void AddAtStart(object data) {
        Node newNode = new Node() { Value = data};
        if (head != null) {
            
            newNode.Next = head;
            head = newNode;
        }
        else {
            last_node = newNode;
            head = newNode;
        }
        Count++;
    }
    
    public void RemoveFromStart() {
    if (Count > 0) {
        head = head.Next; // C# Garbage Collector will remove head Node from memory (unlike C++)
        Count--;
    }
    else
        Console.WriteLine("No element exist in this linked list.");
    }
    
    public void PrintAllNodes() {
        //Traverse from head
        Console.Write("Head->");
        Node curr = head;
        while (curr != null) {
            Console.Write(curr.Value);
            Console.Write("->");
            curr = curr.Next;
        }
        Console.Write("NULL");
        Console.WriteLine();
    }
}

class Solution
{
    static void Main(string[] args)
    {
        LinkedList lnklist = new LinkedList();
        lnklist.PrintAllNodes();

        lnklist.AddAtLast(12);
        lnklist.AddAtLast("John");
        lnklist.AddAtLast("Peter");
        lnklist.AddAtLast(34);
        lnklist.PrintAllNodes();

        lnklist.AddAtStart(55);
        lnklist.PrintAllNodes();
        
        lnklist.RemoveFromStart();
        lnklist.PrintAllNodes();
    }
}
