using System;
using System.Net;

class Program
{
    //NumberOf_Days_Hours_Min_Sec_In certainMonth
    public static short ReadYear()
    {
        Console.WriteLine("Enter Year");
        short year = Convert.ToInt16(Console.ReadLine());
        return year;
    }
    public static int NumberOfDaysInMonth(int Month, int Year)

    {
        if (Month < 0 || Month > 12)
            return 0;
        int[] HowManyDaysInMonth = { 31, 28, 31, 30, 31, 30, 31, 30, 31, 30, 31, 30 };
        return (Month == 2) ? (isLeapYear(Year) ? 29 : 28) : HowManyDaysInMonth[Month-1];
    }

    public static short ReadMonth()
    {
        Console.WriteLine("Enter Month");
        short Month = Convert.ToInt16(Console.ReadLine());
        return Month;
    }

    public static int NumberOfHoursInMonth(int Month)
    {
        return (Month) * 24;
    }

    public static int NumberOfMinuteInYear(int HoursInMonth)
    {
        return HoursInMonth * 60;
    }
    public static int NumberOfSecondInYear(int MinuteInYear)
    {
        return MinuteInYear * 60;
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
        short Month = ReadMonth();
        int Days = NumberOfDaysInMonth(Month, Year);
        int Hours = NumberOfHoursInMonth(Days);
        int Minute = NumberOfMinuteInYear(Hours);
        int Second = NumberOfSecondInYear(Minute);
        Console.WriteLine($"Number of days in month {Days}");
        Console.WriteLine($"Number of Hours in month {Hours}");
        Console.WriteLine($"Number of minute in month {Minute}");
        Console.WriteLine($"Number of second in month {Second}");
        Console.ReadKey();
    }
}
