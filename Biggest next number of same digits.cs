using System;

// To execute C#, please define "static void Main" on a class
// named Solution.

class Solution
{
    static void Main(string[] args)
    {
        string input = "98753941";
        Console.WriteLine(input);

        // From right to left spot D1: number breaks ascending order
        int pivot = -1;
        for (int i=input.Length-1; i>=1; i--)
            if (Convert.ToInt32(input[i]) > Convert.ToInt32(input[i-1])) {
                pivot = i-1;
                break;
            }
        if (pivot == -1) {
            Console.Write("None");
            return;
        }

        // Get next big number to the right
        int diff = 10;
        int int_next_biggest = -1;
        for (int i=pivot+1; i<input.Length; i++) {
            int new_diff = Convert.ToInt32(input[i]) - Convert.ToInt32(input[pivot]);
            if ( new_diff > 0 && new_diff<diff ) {
                diff = new_diff;
                int_next_biggest = i;
            }
        }
        
        // Swap pivot & next big number to the right
        char[] chars = input.ToCharArray();
        chars[pivot] = input[int_next_biggest];
        chars[int_next_biggest] = input[pivot];
        input = new String(chars);
        
        // Sort starting from pivot to right
        string to_sort = input.Substring(pivot+1);
        chars = to_sort.ToCharArray();
        Array.Sort(chars);
        to_sort = new string(chars);
        input = input.Remove(pivot+1, to_sort.Length);
        input = input + to_sort;
        Console.WriteLine(input);
    }
}
