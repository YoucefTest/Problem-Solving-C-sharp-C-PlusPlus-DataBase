using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using static System.Net.WebRequestMethods;
using System.Security.Policy;
using System.Threading;


class Program
{
    static string[] ones = { "", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
    static string[] tens = { "", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
    static string[] thousands = { "", "Thousand", "Million", "Billion" };

    static string NumberToText(int number)
    {
        if (number == 0)
            return "Zero";

        string result = "";

        int thousandIndex = 0;
        while (number > 0)
        {
            if (number % 1000 != 0)
            {
                result = ConvertHundreds(number % 1000) + thousands[thousandIndex] + " " + result;
            }
            number /= 1000;
            thousandIndex++;
        }

        return result.Trim();
    }

    static string ConvertHundreds(int number)
    {
        string result = "";

        if (number >= 100)
        {
            result += ones[number / 100] + " Hundred ";
            number %= 100;
        }

        if (number >= 20)
        {
            result += tens[number / 10] + " ";
            number %= 10;
        }

        if (number > 0)
        {
            result += ones[number] + " ";
        }

        return result;
    }

    static void Main()
    {
        Console.Write("Enter a number: ");
        int number = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Number in text: " + NumberToText(number));
        Console.ReadKey();
    }
}

