using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_
{
    internal class Program
    {
        public static string ReadString()
        {
            string st = "";
            Console.WriteLine("Enter string");
            st = Console.ReadLine();
            return st;
        }

        public static void print(string st)
        {
            Console.WriteLine(st);
        }
        //public static string JoinString(List<string> Words, string Delim)
        //{
        //    if (Words.Count == 0) return "";  // Handle empty list edge case

        //    string word = "";
        //    foreach (string s in Words)
        //    {
        //        word += s +Delim;

        //    }
        //    return word.Substring(0 , word.Length -Delim.Length);
        //}

        public static string JoinString(List<string> words, string delim)
        {
            if (words.Count == 0) return "";  // Handle empty list edge case

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < words.Count; i++)
            {
                sb.Append(words[i]);
                if (i < words.Count - 1)  // Avoid adding delimiter after last word
                {
                    sb.Append(delim);
                }
            }

            return sb.ToString();
        }
        static void Main(string[] args)
        {

            List<string> words = new List<string> { "youcef", "Rayan", "marouane" };
            print(JoinString(words, "#//#"));
            Console.ReadKey();
        }
    }
}
