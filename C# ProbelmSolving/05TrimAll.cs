using System;
using System.Collections.Generic;
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
        public static string TrimRight(string st)
        {
            int index = st.Length - 1;
            while (st[index] > 0 && st[index] == ' ')
            {
                index--;
            }
            return st.Substring(0, index + 1);
        }
        public static string TrimLeft(string st)
        {

            int pos = 0;

            while (pos < st.Length && st[pos] == ' ')
            {
                pos++;

            }
            return st.Substring(pos);
        }
        public static string TrimAll(string st)
        {
            return TrimLeft(TrimRight(st));
        }

        public static void print(string st)
        {
            Console.WriteLine($"TrimALL " + st + "=");
        }

        static void Main(string[] args)
        {
            string st = ReadString();
            print(TrimAll(st));
            Console.ReadKey();
        }
    }
}
