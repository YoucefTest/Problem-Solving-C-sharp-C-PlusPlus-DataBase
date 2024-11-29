using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    public static string RemovePunctuation(string st)

    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < st.Length; i++)
        {
            if (!char.IsPunctuation(st[i]))
                sb.Append(st[i]);
        }
        return sb.ToString();
    }


    // Join the list of words back into a single string


    static void Main(string[] args)
    {
        string input = "Hello world!, this is a test. HEllo !";

        Console.WriteLine(RemovePunct(input));  // Output: "hi world, this is a test. hi!"
        Console.ReadKey();
    }
}
