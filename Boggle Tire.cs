/*################################################################################
#
# Copyright (c) 2018
# Authors:
#  Hesham M. Eraqi (heraqi@aucegypt.edu)
#
################################################################################*/

using System;

// To execute C#, please define "static void Main" on a class
// named Solution.

class TrieNode {
    static int SIZE = 26;
    public TrieNode[] Child = new TrieNode[SIZE];
    public bool leaf;
    
    public TrieNode() {
        leaf = false;
        for (int i =0 ; i< SIZE ; i++)
            Child[i] = null;
    }
};

class Trie {
    public TrieNode root;
    
    public Trie() {
        root = new TrieNode();
    }
    
    int char_int(char c) {
        return (char)(c - 'A');
    }
    
    public void insert(string Key) {
        TrieNode pChild = root;
        for (int i=0; i<Key.Length; i++) {
            int index = char_int(Key[i]);
            if (pChild.Child[index] == null) {
                TrieNode newnode = new TrieNode();
                pChild.Child[index] = newnode;
            }
            pChild = pChild.Child[index];
        }

        pChild.leaf = true; // make last node as leaf node
    }
};

class Solution
{
    static int SIZE = 26;
    
    static int char_int(char c) {
        return (char)(c - 'A');
    }
    
    // function to check that current location (i and j) is in matrix range
    static bool isNotVisisted(int i, int j, bool[,] visited)
    {
        return (i >=0 && i < visited.GetLength(0) && j >=0 && j < visited.GetLength(1) && !visited[i,j]);
    }
    
    // A recursive function to print all words present on boggle
    static void searchWord(TrieNode root, char[,] boggle, int i, int j, bool[,] visited, string str) {
        // if we found word in trie / dictionary
        if (root.leaf == true)
            Console.WriteLine(str);

        // If both I and j in  range and we visited that element of matrix first time
        if (isNotVisisted(i, j, visited)) {
            // make it visited
            visited[i,j] = true;

            // traverse all childs of current root
            for (int K =0; K < SIZE; K++) {
                if (root.Child[K] != null) {
                    char ch = (char)(K + 'A'); // current character

                    // Recursively search reaming character of word in trie for all 8 adjacent cells of boggle[i][j]
                    if (isNotVisisted(i+1,j+1,visited) && boggle[i+1,j+1] == ch)
                        searchWord(root.Child[K],boggle,i+1,j+1,visited, str+ch);
                    if (isNotVisisted(i, j+1,visited)  && boggle[i,j+1] == ch)
                        searchWord(root.Child[K],boggle,i, j+1,visited, str+ch);
                    if (isNotVisisted(i-1,j+1,visited) && boggle[i-1,j+1] == ch)
                        searchWord(root.Child[K],boggle,i-1, j+1,visited, str+ch);
                    if (isNotVisisted(i+1,j, visited)  && boggle[i+1,j] == ch)
                        searchWord(root.Child[K],boggle,i+1, j,visited, str+ch);
                    if (isNotVisisted(i+1,j-1,visited) && boggle[i+1,j-1] == ch)
                        searchWord(root.Child[K],boggle,i+1, j-1,visited, str+ch);
                    if (isNotVisisted(i, j-1,visited)&& boggle[i,j-1] == ch)
                        searchWord(root.Child[K],boggle,i,j-1,visited, str+ch);
                    if (isNotVisisted(i-1,j-1,visited) && boggle[i-1,j-1] == ch)
                        searchWord(root.Child[K],boggle,i-1, j-1,visited, str+ch);
                    if (isNotVisisted(i-1, j,visited) && boggle[i-1,j] == ch)
                        searchWord(root.Child[K],boggle,i-1, j, visited, str+ch);
                }
            }

            visited[i,j] = false; // make current element unvisited
        }
    }
    
    static void findWords(char[,] boggle, Trie tire) {
        bool[,] visited = new bool[boggle.GetLength(0),boggle.GetLength(1)];
        TrieNode pChild = tire.root;
        string str = "";
        // we start searching for word in dictionary if we found a character which is child of Trie root
        for (int i = 0; i < boggle.GetLength(0); i++)
            for (int j = 0; j < boggle.GetLength(1); j++) {
                if (pChild.Child[char_int(boggle[i,j])] != null ) {
                    str = str+boggle[i,j];
                    searchWord(pChild.Child[char_int(boggle[i,j])], boggle, i, j, visited, str);
                    str = "";
                }
            }
    }
        
    static void Main(string[] args)
    {
        string[] dictionary = {"GEEKS", "FOR", "QUIZ", "GO", "SEEK"};

        // root Node of trie
        Trie trie = new Trie();
        for (int i=0; i<dictionary.Length; i++)
            trie.insert(dictionary[i]);
        
        char[,] boggle = new char[,] {{'G','I','Z'},
                                     {'U','E','K'},
                                     {'Q','S','E'}};
        findWords(boggle, trie);
    }
}
