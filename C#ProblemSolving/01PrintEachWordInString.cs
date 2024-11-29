using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_ProblemSolving
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
        public static List<string> GetEachWordInString(string st, string delim)
        {
            List<string> Lwords = new List<string>();
            string word = "";
            int pos = 0;
            while ((pos = st.IndexOf(delim)) != -1)
            {
                word = st.Substring(0, pos);
                if (!string.IsNullOrEmpty(word))
                {
                    Lwords.Add(word);
                    word = "";
                }
                st = st.Substring(pos + delim.Length);
            }
            if (!string.IsNullOrEmpty(st))
                Lwords.Add(st);
            return Lwords;

        }
        public static void PrintEachWordInString(List<string> words)
        {
            foreach (string word in words)
            {
                Console.Write(word+"-");
            }
        }

        static void Main(string[] args)
        {
            string st = ReadString();
            Print(inWord(st, " "));
            Console.ReadKey();
        }

    }
}
