
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Runtime.Remoting.Services;
using System.Text;

class Program
{
    //convert Line data to record

    //5501/##/youcef/##/54100252/##/1990/##/120

    public struct stClientData
    {
        public string Name;
        public int AccountNum;
        public string phone;
        public string pin;
        public double Amount;
    }

    public static stClientData ConvertLineToRecord(string st)
    {
        string[] arr = st.Split(new string[] { "/##/" }, StringSplitOptions.RemoveEmptyEntries);
        stClientData data;
        data.AccountNum = Convert.ToInt32(arr[0]);
        data.Name = arr[1];
        data.phone = arr[2];
        data.pin = arr[3];
        data.Amount = Convert.ToDouble(arr[4]);

        return data;
    }
    public static void print(stClientData data)
    {
        Console.WriteLine($"Account Number : {data.AccountNum} \nName :{data.Name} \nPhone: {data.phone}\npin: {data.pin} \nAmount: {data.Amount} ");
    }

    static void Main(string[] args)
    {
        string st = "5501/##/youcef/##/54100252/##/1990/##/120";

        print(ConvertLineToRecord(st));

        Console.ReadKey();
    }
}
