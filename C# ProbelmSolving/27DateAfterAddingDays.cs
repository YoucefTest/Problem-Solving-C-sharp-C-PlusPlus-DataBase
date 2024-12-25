using System;

struct sDate
{
    public short Year;
    public short Month;
    public short Day;
}

class Program
{
    public static bool IsLeapYear(short Year)
    {
        return (Year % 4 == 0 && Year % 100 != 0) || (Year % 400 == 0);
    }

    public static short NumberOfDaysInAMonth(short Month, short Year)
    {
        if (Month < 1 || Month > 12)
            return 0;
        int[] days = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        return (Month == 2) ? (IsLeapYear(Year) ? (short)29 : (short)28) : (short)days[Month - 1];
    }

    public static short NumberOfDaysFromTheBeginningOfTheYear(short Day, short Month, short Year)
    {
        short TotalDays = 0;
        for (int i = 1; i < Month ; i++)
        {
            TotalDays += NumberOfDaysInAMonth((short)i, Year);
        }
        TotalDays += Day;
        return TotalDays;
    }

    public static sDate DateAddDays(short Days, sDate Date)
    {
        short RemainingDays = (short)(Days + NumberOfDaysFromTheBeginningOfTheYear(Date.Day, Date.Month, Date.Year));
        short MonthDays;
        Date.Month = 1;

        while (true)
        {
            MonthDays = NumberOfDaysInAMonth(Date.Month, Date.Year);
            if (RemainingDays > MonthDays)
            {
                RemainingDays -= MonthDays;
                if (Date.Month > 12)
                {
                    Date.Month = 1;
                    Date.Year++;
                }
                else
                {
                    Date.Month++;
                }
            }
            else
            {
                Date.Day = RemainingDays;
                break;
            }
        }
        return Date;
    }

    public static short ReadDay()
    {
        Console.Write("\nPlease enter a Day: ");
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

    public static short ReadDaysToAdd()
    {
        Console.Write("\nHow many days to add? ");
        return Convert.ToInt16(Console.ReadLine());
    }

    static void Main(string[] args)
    {
        sDate Date = ReadFullDate();
        short Days = ReadDaysToAdd();
        Date = DateAddDays(Days, Date);
        Console.WriteLine($"\nDate after adding [{Days}] days is: {Date.Day}/{Date.Month}/{Date.Year}");
        Console.ReadKey();
    }
}
