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
    public static int NumberOfDaysInYear(int year)
    {
        return (isLeapYear(year)) ? 366 : 365;
    }
   
    public static int NumberOfHoursInYear(int Year)
    {
        return NumberOfDaysInYear(Year) * 24;
    }

    public static int NumberOfMinuteInYear(int Year)
    {
        return NumberOfHoursInYear(Year) * 60;
    }
    public static int NumberOfSecondInYear(int Year)
    {
        return NumberOfMinuteInYear(Year) * 60;
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
        short Year = ReadYear();
        int Days = NumberOfDaysInYear(Year);
        int Hours = NumberOfHoursInYear(Year);
        int Minute = NumberOfMinuteInYear(Year);
        int Second = NumberOfSecondInYear(Year);
        Console.WriteLine($"Number of days in year {Days}");
        Console.WriteLine($"Number of days in year {Hours}");
        Console.WriteLine($"Number of days in year {Minute}");
        Console.WriteLine($"Number of days in year {Second}");

        Console.ReadKey();
    }
}
