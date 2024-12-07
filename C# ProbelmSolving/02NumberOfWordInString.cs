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
        public static int CountEachWordInString(string st, string delim)
        {
            int Counter = 0;
        
            string word = "";
            int pos = 0;
            while ((pos = st.IndexOf(delim)) != -1)
            {
                word = st.Substring(0, pos);
                if (!string.IsNullOrEmpty(word))
                {
                    Counter++;
                    word = "";
                }
                st = st.Substring(pos + delim.Length);
            }
            if (!string.IsNullOrEmpty(st))
                Counter++;
            return Counter++;

        }
        public static void PrintNumberOfWordINString(int Counter)
        {
            Console.WriteLine($"The Number of Words In Your string {Counter} ");
        }

        static void Main(string[] args)
        {
            string st = ReadString();
            PrintNumberOfWordINString(CountEachWordInString(st, " "));
            Console.ReadKey();
        }

    }
}
