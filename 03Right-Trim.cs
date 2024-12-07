using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_problems
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
        public static string TrimLeft(string st)
        {
            //string w;
            //for(int i = 0; i < st.Length; i++)
            //{
            //    if (st[i] != ' ')
            //    {
            //        st = st.Substring(i );
            //        return st;
            //    }

            //}
            //return st;
            int pos =0;
            
            while (pos <st.Length && st[pos]==' ' )
            {
                pos ++;   
    
            }
            return st.Substring(pos);
        }
        public static void print (string st )
        {
            Console.WriteLine($"Right Trim "+st +"=");
        }
        static void Main(string[] args)
        {
           string st =  ReadString();
            print(TrimLeft(st));
            Console.ReadKey();

        }
    }
}
