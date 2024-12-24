using System;
using System.Net;

class Program
{
    public static int GetNumberFromUser()
    {
        int number = Convert.ToInt32(Console.ReadLine());
        return number;
    }

    enum Ones { zero, one, two, three, four, five, six, seven, eight, nine, ten, eleven, twelve, thirteen, fourteen, fifteen, sixteen, seventeen, eighteen, nineteen }
    enum Tens { zero, ten, twenty, thirty, forty, fifty, sixty, seventy, eighty, ninety }
    static string[] OnesWords = { "", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };

    static string[] TensWords = { "", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

    static string[] ThousandsWords = { "", "Thousand", "Million", "Billion" };

    public static string ConvertNumberToWords(int num)
    {





        // Base case for numbers 1-19
        if (num >= 1 && num <= 19)
        {
            return OnesWords[num];
        }
        // Case for numbers 20-99
        else if (num >= 20 && num <= 99)
        {
            return TensWords[num / 10] + " " + OnesWords[num % 10];
        }
        // Case for numbers 100-999
        else if (num >= 100 && num <= 999)
        {
            return OnesWords[num / 100] + " hundred " + ConvertNumberToWords(num % 100);
        }
        // Case for numbers 1000-999999 (Thousand)
        else if (num >= 1000 && num <= 999999)
        {
            return ConvertNumberToWords(num / 1000) + " thousand " + ConvertNumberToWords(num % 1000);
        }
        // Case for numbers 1 million to less than 1 billion
        else if (num >= 1000000 && num < 1000000000)
        {
            return ConvertNumberToWords(num / 1000000) + " million " + ConvertNumberToWords(num % 1000000);
        }
        // Case for numbers 1 billion and higher
        else if (num >= 1000000000)
        {
            return ConvertNumberToWords(num / 1000000000) + " billion " + ConvertNumberToWords(num % 1000000000);
        }

        return "";
    }

    static void Main(string[] args)
    {
        int n = GetNumberFromUser();
        string result = ConvertNumberToWords(n);

        // If the number is zero, print "Zero"
        if (string.IsNullOrEmpty(result))
        {
            result = "Zero";
        }

        Console.WriteLine(result);
        Console.ReadKey();
    }
}
