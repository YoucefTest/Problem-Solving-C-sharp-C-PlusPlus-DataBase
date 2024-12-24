using System;
using System.Diagnostics.Eventing.Reader;

//Calculate your age in days:

struct sDate
{
    public int Year;
    public int Month;
    public int Day;
}

class Program
{
    public static bool IsLeapYear(int Year)
    {
        return (Year % 4 == 0 && Year % 100 != 0) || (Year % 400 == 0);
    }

    public static int GetHowManyDaysInMonth(int Month, int Year)
    {
        int[] daysInMonth = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

        return (Month == 2) ? (IsLeapYear(Year) ? 29 : 28) : daysInMonth[Month - 1];
    }

    public static short ReadDay()
    {
        Console.Write("Your Date Of Birth \nPlease enter a Day: ");
        return Convert.ToInt16(Console.ReadLine());
    }

    public static short ReadMonth()
    {
        Console.Write("\nPlease enter a Month: ");
        return Convert.ToInt16(Console.ReadLine());
    }

    public static short ReadYear()
    {
        Console.Write("\nPlease enter a Year: ");
        return Convert.ToInt16(Console.ReadLine());
    }

    public static sDate ReadFullDate()
    {
        sDate Date;
        Date.Day = ReadDay();
        Date.Month = ReadMonth();
        Date.Year = ReadYear();
        return Date;
    }



    public static bool isDate1LessThanDate2(sDate Date1, sDate Date2)
    {
        return (Date1.Year < Date2.Year) ||
               (Date1.Year == Date2.Year && Date1.Month < Date2.Month) ||
               (Date1.Year == Date2.Year && Date1.Month == Date2.Month && Date1.Day < Date2.Day);
    }
    public static bool isDate2LessThanDate1(sDate Date2, sDate Date1)
    {
        return (Date2.Year < Date1.Year) ||
               (Date2.Year == Date1.Year && Date2.Month < Date1.Month) ||
               (Date2.Year == Date1.Year && Date2.Month == Date1.Month && Date2.Day < Date1.Day);
    }

    public static sDate AddOneDay(sDate Date1)
    {

        int CurentDays = GetHowManyDaysInMonth(Date1.Month, Date1.Year);

        if (Date1.Day == CurentDays)
        {
            if (Date1.Month == 12)
            {
                Date1.Day = 1;
                Date1.Month = 1;
                Date1.Year++;
            }
            else
            {
                Date1.Day = 1;
                Date1.Month++;
            }
        }
        else
        {
            Date1.Day++;
        }

        return Date1;
    }


    public static int CalculateAgeInDays(sDate Date1, sDate Date2)
    {
        int Counter = 0;
        if (isDate1LessThanDate2(Date1, Date2))
        {
            while (isDate1LessThanDate2(Date1, Date2))
            {
                Date1 = AddOneDay(Date1);
                Counter++;
            }
            return Counter;
        }
        if (isDate2LessThanDate1(Date2, Date1))
        {
            while (isDate2LessThanDate1(Date2, Date1))
            {
                Date2 = AddOneDay(Date2);
                Counter++;
            }

        }
        return Counter * -1;
    }

    static void Main(string[] args)
    {
        // Read the user's birthdate
        sDate Date1 = ReadFullDate();
        sDate Date2 = ReadFullDate();

        // Print both dates
        Console.WriteLine($"{Date1.Day}/{Date1.Month}/{Date1.Year}");
        Console.WriteLine($"{Date2.Day}/{Date2.Month}/{Date2.Year}");

        // Calculate the age in days
        int AgeInDays = CalculateAgeInDays(Date1, Date2);

        // Print the calculated age in days
        Console.WriteLine("Age in days: ");
        Console.WriteLine(AgeInDays);

        Console.ReadKey();
    }
}
