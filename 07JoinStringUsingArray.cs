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


        public static void print(string st)
        {
            Console.WriteLine(st);
        }

        //string JoinString(string [] arrString , short Length, string Delim)
        //{
        //    string S1 = "";
        //    for (short i = 0; i < Length; i++)
        //    {
        //        S1 = S1 + arrString[i] + Delim;
        //    }
        //    return S1.Substring(0, S1.Length - Delim.Length);
        //}

        public static string JoinStringUsingArr(string[] arr, string delim)
        {
            if (arr.Length == 0) return "";  // Handle empty array edge case

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < arr.Length; i++)
            {
                sb.Append(arr[i]);
                if (i < arr.Length - 1)  // Only add delimiter if not the last element
                    sb.Append(delim);
            }
            return sb.ToString();
        }

        static void Main(string[] args)
        {
            string[] arr = { "youcef", "nasser", "merouan", "hassen" };

            print(JoinStringUsingArr(arr, "#//#"));
            Console.ReadKey();
        }

    }
}
