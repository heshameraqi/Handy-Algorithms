################################################################################
#
# Copyright (c) 2018
# Authors:
#  Hesham M. Eraqi (heraqi@aucegypt.edu)
#
#Given two words (beginWord and endWord), and a dictionary's word list, find all shortest transformation sequence(s) from beginWord to endWord, such that:
#
#Only one letter can be changed at a time
#Each transformed word must exist in the word list. Note that beginWord is not a transformed word.
#For example,
#
#Given:
#beginWord = "hit"
#endWord = "cog"
#wordList = ["hot","dot","dog","lot","log","cog"]
#
#Return
#  [
#    ["hit","hot","dot","dog","cog"],
#    ["hit","hot","lot","log","cog"]
#  ]
#Note:
#Return an empty list if there is no such transformation sequence.
#All words have the same length.
#All words contain only lowercase alphabetic characters.
#You may assume no duplicates in the word list.
#You may assume beginWord and endWord are non-empty and are not the same.
#
################################################################################

public class Solution {
    public bool isDifferentInOneLetter(string str1, string str2) {
        int diff = 0;
        for (int i=0; i<str1.Length; i++)
            if (str1[i] != str2[i])
                diff++;
        
        return (diff==1);
    }
    
    public IList<IList<string>> FindLadders(string beginWord, string endWord, IList<string> wordList) {
        IList<IList<string>> to_return = new List<IList<string>>();
        
        Queue<List<string>> BSF_queue = new Queue<List<string>>(); // Queue of nodes, each node is list of words
        BSF_queue.Enqueue(new List<string>() {beginWord});
        
        int min_steps = int.MaxValue;
        
        while (BSF_queue.Count > 0) {
            List<string> current_node = BSF_queue.Dequeue();
            
            if (current_node[current_node.Count-1] == endWord) {
                if (current_node.Count ==  min_steps || (current_node.Count < min_steps && to_return.Count == 0)) {
                    to_return.Add(current_node);
                    min_steps = current_node.Count;
                }
                else if (current_node.Count < min_steps && to_return.Count >= 1) {
                    to_return.RemoveAt(current_node.Count -1);
                    to_return.Add(current_node);
                    min_steps = current_node.Count;
                }
            }
            else if (current_node.Count <= (wordList.Count+1) && current_node.Count <= (min_steps-1)) {
                for (int i=0; i<wordList.Count; i++) {
                    if (isDifferentInOneLetter(current_node[current_node.Count-1] , wordList[i])) {
                            List<string> new_node = new List<string>(current_node);
                            new_node.Add(wordList[i]);
                            BSF_queue.Enqueue(new_node);
                    }
                }
            }
        }
        
        return to_return;
    }
}
