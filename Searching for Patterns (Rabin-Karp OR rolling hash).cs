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

class RollingHash {
    string text;
    public long hash; // For bigger and bigger hashes
    int wordSize;
    int window_start; // index
    int window_end; // index

    public RollingHash(string t, int s) {
        text = t;
        hash = 0;
        wordSize = s;

        for (int i=0; i<wordSize; i++) 
            hash += (int)(text[i] - 'a' + 1) * (long)Math.Pow(26, wordSize - i -1); // a means 1 * 26^x and if sizeWord=3 x=0->2. Zero at window start

        window_start = 0;
        window_end = wordSize-1;
    }

    public void move_window() {
        if (window_end <= text.Length - 2) {
            hash -= (int)(text[window_start] - 'a' + 1) * (long)Math.Pow(26, wordSize-1);
            hash *= 26;
            hash += (int)(text[window_end+1] - 'a' + 1);
            
            window_start += 1;
            window_end += 1;
        }
    }

    public string window_text() {
        return text.Substring(window_start, window_end-window_start+1);
    }
}

class Solution
{
    static int rabin_karp(string word, string text) {
        if (word == "" || text == "")
            return -1;
        if (word.Length > text.Length)
            return -1;

        RollingHash rolling_hash = new RollingHash(text, word.Length);
        RollingHash word_hash = new RollingHash(word, word.Length); // Won't call move_window on that
                
        for (int i=0; i<(text.Length - word.Length + 1); i++) {
            //Console.WriteLine("Word Hash = " + word_hash.hash + ", Rolling Hash = " + rolling_hash.hash);
            if (rolling_hash.hash == word_hash.hash) {
                if (rolling_hash.window_text() == word) {
                    return i;
                }
            }
            rolling_hash.move_window();
        }
        return -1;
    }
                    
    static void Main(string[] args) // O(nm) at worst case when awful hash function that resulted in a false positive at each step of n. Best and average cases are O(n+m)
									// KMP algorithm worst case is better O(n).
									// rabin_karp might still be better because of its average case when comparing 2 big texts. You will store the smaller text hashes in a queryable data-structure efficient for membership testing (like bloom filters)
    {
        Console.WriteLine(rabin_karp("a", "abcdefgh"));
        Console.WriteLine(rabin_karp("d", "abcdefgh"));
        Console.WriteLine(rabin_karp("cupcakes", "balloonsandcupcakesgood"));
    }
}



