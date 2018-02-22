################################################################################
#
# Copyright (c) 2018
# Authors:
#  Hesham M. Eraqi (heraqi@aucegypt.edu)
#
################################################################################

using System;

// To execute C#, please define "static void Main" on a class
// named Solution.

class Solution
{
    static int[] computeLPSArray(string pat) {
        int[] lps = new int[pat.Length];
        lps[0] = 0; // lps[0] is always 0
        
        int len = 0; // length of the previous longest prefix suffix
        int i = 1;
        while (i < pat.Length) {
            if (pat[i] == pat[len]) { // If the new char pat[i] equal to the char at len
                len++;
                lps[i] = len; i++;
            }
            else { // not equal
                if (len != 0)
                    len = lps[len-1]; // consider the char before len
                else { // if (len == 0)
                    lps[i] = 0; i++;
                }
            }
        }
        return lps;
    }
    
    static void KMPSearch(string pat, string txt) {
        int M = pat.Length;
        int N = txt.Length;
        int[] lps = computeLPSArray(pat);

        int i = 0;  // index for txt[]
        int j  = 0;  // index for pat[]
        while (i < N) {
            if (pat[j] == txt[i]) {
                i++;
                j++;
            }

            if (j == M) {
                Console.WriteLine("Found pattern at index " + (i-j));
                j = lps[j-1];
            }
            else if (i < N && pat[j] != txt[i]) { // mismatch after j matches
                if (j != 0) //do not match lps[0..lps[j-1]] characters, they will match anyway
                    j = lps[j-1];
                else
                    i = i+1;
            }
        }
    }
    
    // For string "ABC":
    // Prefixes: "", "A", "AB", "ABC"
    // Suffixes: "", "C", "BC", "ABC"
    // Proper Prefixes: "", "A", "AB" (proper means whole string is not included)
    // Proper Suffixes: "", "C", "BC"
    // 
    // lps[i] = length of the longest Proper Prefix of pattern[0..i] that is also a Suffix of pattern[0..i].
    //       OR .............................Suffix.................................Prefix.................. (same result)

    // pattern = "AAAA" -> lps=[0, 1, 2, 3]
    // pattern = "AAACAAAAAC" -> lps=[0, 1, 2, 0, 1, 2, 3, 3, 3, 4] 
    static void Main(string[] args)
    {
        //string txt = "ABABDABACDABABCABABXXABABCABAB";
        //string pat = "ABABCABAB";
        
        string txt = "AAAAABAAABA";
        string pat = "AAAA";
        KMPSearch(pat, txt);
    }
}
