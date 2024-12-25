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



        public static string ReverseWords(string input)
        {
            return string.Join(" ", input.Split(' ').Reverse());
        }

        static void Main(string[] args)
        {
            string st = "Hello world ! this is my string is reversed";
            Console.WriteLine(ReverseWords(st));  // Outputs: "world hello"
            Console.ReadKey();
        }
    }
}

