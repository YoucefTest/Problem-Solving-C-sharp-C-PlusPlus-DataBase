using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Runtime.Remoting.Services;
using System.Text;

class Program
{
    //Read clinet data and convert it to string

    public struct stClientData
    {
        public int AccoubtNum;
        public string pin, Name, phone;
        public double AccountBalance;
    }
    public static stClientData ReadInfo()
    {
        stClientData client = new stClientData();

        Console.WriteLine("enter name: ");
        client.Name = Console.ReadLine();

        Console.WriteLine("enter account: ");
        client.AccoubtNum = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("enter Pin: ");
        client.pin = Console.ReadLine();

        Console.WriteLine("enter phone: ");
        client.phone = Console.ReadLine();

        Console.WriteLine("enter account balance: ");
        client.AccountBalance = Convert.ToDouble(Console.ReadLine());
        return client;
    }


    public static string joinrecord(stClientData client)
    {
        return string.Join("/##/", client.AccoubtNum, client.Name, client.phone, client.pin, client.AccountBalance);
    }

    static void Main(string[] args)
    {
        stClientData client = ReadInfo();
        Console.WriteLine(joinrecord(client));



        Console.ReadKey();
    }
}
