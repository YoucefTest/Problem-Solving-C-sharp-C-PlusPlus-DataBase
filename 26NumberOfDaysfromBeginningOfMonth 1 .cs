using System;

class Program
{
    public static int ReadYear()
    {
        Console.WriteLine("Enter Year:");
        return Convert.ToInt16(Console.ReadLine());
    }

    public static int ReadMonth()
    {
        Console.WriteLine("Enter Month:");
        return Convert.ToInt16(Console.ReadLine());
    }
    public static int ReadDay()
    {
        Console.WriteLine("Enter Day:");
        return Convert.ToInt16(Console.ReadLine());
    }


    public static bool IsLeapYear(int year)
    {
        return (year % 400 == 0) || (year % 4 == 0 && year % 100 != 0);
    }
    public static int GetHowManyDaysInMonth(int Month, int Year)
    {
        int[] daysInMonth = { 31, 28, 31, 30, 31, 30,
                              31, 31, 30, 31, 30, 31 };

        return (Month == 2) ? (IsLeapYear(Year) ? 29 : 28) : daysInMonth[Month - 1];
    }

    public static int PrintTheNumOfDaysFromBeginningOfMonth_1(int Day, int Month, int Year)
    {
        int TotalDays = 0;
        for (int i = 1; i < Month; i++)
        {
            TotalDays += GetHowManyDaysInMonth(i, Year);
        }

        return Day + TotalDays;
    }
    public struct stDate
    {
        public int Day; public int Month; public int Year;
    }
    public static stDate GetDay_Month_YearFromTotal(int Total, int Year)
    {
        stDate date = new stDate();
        int i = 1;
        for (; i <= 12; i++)
        {
            if (Total > GetHowManyDaysInMonth(i, Year))
            {
                Total -= GetHowManyDaysInMonth(i, Year);
            }
            else
            {
                date.Day = Total;
                date.Month = i;
                date.Year = Year;
            }

        }
        return date;
    }

    static void Main(string[] args)
    {
        stDate date = new stDate();
        int Year = ReadYear();
        int Month = ReadMonth();
        int Day = ReadDay();
        int Total = PrintTheNumOfDaysFromBeginningOfMonth_1(Day, Month, Year);
        Console.WriteLine(Total);
        date = GetDay_Month_YearFromTotal(Total, Year);
        Console.WriteLine(date.Day + " " + date.Month + " " + date.Year);
        Console.ReadKey();
    }
}