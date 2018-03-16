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

class Solution
{
    static string[] dictionary = {"GEEKS", "FOR", "QUIZ", "GO", "SEEK"};
    static bool isWord(string str)
    {
        for (int i=0; i<dictionary.Length; i++)
            if (str == dictionary[i])
              return true;
        return false;
    }
    
    static void Visit(char[,] boggle, bool[,] visited, int i, int j, string str) {
        // Mark current cell as visited and append current character to str
        visited[i,j] = true;
        str = str + boggle[i,j];

        // If str is present in dictionary, then print it
        if (isWord(str))
            Console.WriteLine(str);

        // Traverse 8 adjacent cells of boggle[i][j]
        for (int row=i-1; row<=i+1 && row<boggle.GetLength(0); row++)
          for (int col=j-1; col<=j+1 && col<boggle.GetLength(1); col++)
            if (row>=0 && col>=0 && !visited[row,col])
              Visit(boggle,visited, row, col, str);

        // Erase current character from string and mark visited of current cell as false
        str = str.Remove(str.Length-1); // Not needed because the string variable is passed is value already.
        visited[i,j] = false; // Importrant because in C# array is passed by reference
    }
    
    static void findWords(char[,] boggle) {
        bool[,] visited = new bool[boggle.GetLength(0),boggle.GetLength(1)]; // Mark all characters as not visited

        // Consider every character as starting caracter and start DSF
        string str = "";
        for (int i=0; i<boggle.GetLength(0); i++)
           for (int j=0; j<boggle.GetLength(1); j++)
                 Visit(boggle, visited, i, j, str);
    }
    
    static void Main(string[] args)
    {
        char[,] boggle = new char[,] {{'G','I','Z'},
                                     {'U','E','K'},
                                     {'Q','S','E'}};
        findWords(boggle);
    }
}
