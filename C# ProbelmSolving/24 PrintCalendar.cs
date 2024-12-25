using System;

class Program
{
    public static short ReadYear()
    {
        Console.WriteLine("Enter Year:");
        return Convert.ToInt16(Console.ReadLine());
    }

    public static string GetMonthName(int month)
    {
        string[] monthNames = { "Jan", "Feb", "Mar", "Apr", "May", "Jun",
                                "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
        return monthNames[month - 1];
    }

    public static int GetDaysInMonth(int month, int year)
    {
        if (month == 2 && IsLeapYear(year))
            return 29;
        int[] daysInMonth = { 31, 28, 31, 30, 31, 30,
                              31, 31, 30, 31, 30, 31 };
        return daysInMonth[month - 1];
    }

    public static bool IsLeapYear(int year)
    {
        return (year % 400 == 0) || (year % 4 == 0 && year % 100 != 0);
    }

    public static void PrintMonth(int month, int year)
    {
        string monthName = GetMonthName(month);
        int startDay = GetDayNumber(1, month, year);
        int daysInMonth = GetDaysInMonth(month, year);

        Console.WriteLine($"\n----- {monthName} {year} -----");
        Console.WriteLine("Sun\tMon\tTue\tWed\tThu\tFri\tSat");

        // Print leading spaces
        int dayCounter = 0;
        for (int i = 0; i < startDay; i++)
        {
            Console.Write("\t");
            dayCounter++;
        }

        // Print days of the month
        for (int day = 1; day <= daysInMonth; day++)
        {
            Console.Write($"{day}\t");
            dayCounter++;

            // If the current line is filled, move to the next line
            if (dayCounter == 7)
            {
                Console.WriteLine();
                dayCounter = 0;
            }
        }
        Console.WriteLine("\n");
    }

    public static int GetDayNumber(int day, int month, int year)
    {
        DateTime date = new DateTime(year, month, day);
        return (int)date.DayOfWeek;
    }

    public static void PrintAllMonths(int year)
    {
        for (int month = 1; month <= 12; month++)
        {
            PrintMonth(month, year);
        }
    }

    static void Main(string[] args)
    {
        short year = ReadYear();
        PrintAllMonths(year);
        Console.ReadKey();
    }
}
