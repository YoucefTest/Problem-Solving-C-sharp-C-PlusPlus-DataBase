using System;
using System.Net;

class Program
{
    public static short ReadYear()
    {
        Console.WriteLine("Enter Year");
        short year = Convert.ToInt16(Console.ReadLine());
        return year;
    }

    public static bool isLeapYear(int year)
    {
        if ((year % 400 == 0) || (year % 4 == 0 && year % 100 != 0))
            return true;
        else
            return false;
    }



    static void Main(string[] args)
    {
        short year = ReadYear();
        if (isLeapYear(year))
        {
            Console.WriteLine("is Leap year");
        }
        else
        {
            Console.WriteLine("Is Not Leap Year");
        }

        Console.ReadKey();
    }
}
