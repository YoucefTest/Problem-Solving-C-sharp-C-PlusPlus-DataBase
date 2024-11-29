using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
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
            StringBuilder sb = new StringBuilder();
            int index = st.Count - 1;
            while (index >= 0)
            {
                sb.Append(st[index]);
                if (index > 0)
                {
                    sb.Append(delim); // Add delimiter
                }
                index--;
            }
            return sb.ToString();
        }

        static void Main(string[] args)
        {
            string st = ReadString();
            Print(Reverse(Split(st, " "), " "));


            Console.ReadKey();
        }

    }
}
