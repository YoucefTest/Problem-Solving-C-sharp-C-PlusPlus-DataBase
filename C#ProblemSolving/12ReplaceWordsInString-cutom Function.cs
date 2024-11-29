using System;
using System.Collections.Generic;

class Program
{
    // Split the string based on the delimiter and return a list of words
    static List<string> SplitString(string input, string delimiter)
    {
        List<string> words = new List<string>();
        int pos = 0;
        string word;

        while ((pos = input.IndexOf(delimiter)) != -1)
        {
            word = input.Substring(0, pos);
            if (!string.IsNullOrEmpty(word))
            {
                words.Add(word);
            }
            input = input.Substring(pos + delimiter.Length);
        }

        // Add the last word if it's not empty
        if (!string.IsNullOrEmpty(input))
        {
            words.Add(input);
        }

        return words;
    }

    // Join a list of words into a single string with a delimiter
    static string JoinString(List<string> words, string delimiter)
    {
        string result = string.Join(delimiter, words);
        return result;
    }

    // Convert a string to lowercase
    static string LowerAllString(string input)
    {
        return input.ToLower();
    }

    // Replace a word in the string using the SplitString method
    static string ReplaceWordInStringUsingSplit(string input, string stringToReplace, string replaceWith)
    {
        // Split the input string into words
        List<string> words = SplitString(input, " ");

        for (int i = 0; i < words.Count; i++)
        {
            // Compare in a case-insensitive way by converting both words to lowercase
            if (LowerAllString(words[i]) == LowerAllString(stringToReplace))
            {
                words[i] = replaceWith; // Replace the word
            }
        }

        // Join the list of words back into a single string
        return JoinString(words, " ");
    }


    // Join the list of words back into a single string


    static void Main(string[] args)
    {
        string input = "Hello world, this is a test. HEllo !";
        string output = ReplaceWordInStringUsingSplit(input, "hello", "hi");  // Case insensitive replacement

        Console.WriteLine(output);  // Output: "hi world, this is a test. hi!"
        Console.ReadKey();
    }
}
