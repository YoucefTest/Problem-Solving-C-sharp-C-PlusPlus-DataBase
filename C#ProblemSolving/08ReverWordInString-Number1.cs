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
        public static void Print(string st)
        {
            Console.WriteLine(st);
        }

        public static List<string> Split(string st, string delim)
        {

            List<string> Words = new List<string>();
            int pos = 0;
            string word = "";

            while ((pos = st.IndexOf(delim)) != -1)
            {
                word = st.Substring(0, pos);
                if (!string.IsNullOrEmpty(word))
                    Words.Add(word);
                word = "";
                st = st.Substring(pos + delim.Length);

            }

            if (!string.IsNullOrEmpty(st))
                Words.Add(st);

            return Words;
        }

        public static string Reverse(List<string> st, string delim)
        {
            st.Reverse();  // Reverse the list directly
            return string.Join(delim, st);  // Efficient way to join with a delimiter
        }

        static void Main(string[] args)
        {
            string st = ReadString();
            Print(Reverse(Split(st, " "), " "));  // Split by space and reverse
            Console.ReadKey();
        }
    }
}
