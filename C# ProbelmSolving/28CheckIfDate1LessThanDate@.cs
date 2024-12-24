using System;


struct sDate
{
    public short Year;
    public short Month;
    public short Day;
}
class Program
{


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

    public static bool CheckIfDate1LessThanDate2(sDate Date1, sDate Date2)
    {
        return (Date1.Year < Date2.Year) ? true : (Date1.Year == Date2.Year) && Date1.Month < Date2.Month ? true :
      (Date1.Month == Date2.Month && Date1.Day < Date2.Day) ? true : false;
    }


    static void Main(string[] args)
    {
        sDate Date1 = ReadFullDate();
        sDate Date2 = ReadFullDate();


        Console.WriteLine($"\nDate 1 : {Date1.Day}/{Date1.Month}/{Date1.Year}");
        Console.WriteLine($"\nDate 2 : {Date2.Day}/{Date2.Month}/{Date2.Year}");
        if (CheckIfDate1LessThanDate2(Date1, Date2))

            Console.WriteLine("Yes Date1 is less than Date 2");
        else Console.WriteLine("Date1 is greater than date 2");


        Console.ReadKey();
    }
}
