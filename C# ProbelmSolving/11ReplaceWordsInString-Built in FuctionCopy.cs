using System;

class Program
{
    public static string ReplaceWordInString(string st, string Replaced, string NewWord)
    {
        return Regex.Replace(st, @"\b" + Regex.Escape(Replaced) + @"\b", NewWord, RegexOptions.IgnoreCase);
        //\b replace whole words and not substrings within other words.
        // (like . or *), and Regex.Escape() makes sure that those characters are treated literally, not as part of a regular expression pattern.
    }
}

static void Main(string[] args)
    {
        string input = "The quick brown FoX jumps over the lazy dog";
        string replaced = ReplaceWordInString(input, "fox", "cat");

        Console.WriteLine(replaced);  // Output: "The quick brown cat jumps over the lazy dog"
    }
}
