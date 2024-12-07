using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;

class Program
{

    const string ClientsFileName = @"C:\Users\Belhassous990\Documents\New folder\data.txt";

    // Define the structure of a client
    public struct sClient
    {
        public string AccountNumber;
        public string PinCode;
        public string Name;
        public string Phone;
        public double AccountBalance;
    }

    // Method to read client data from the user
    public static List<string> Split_String(string Lines, string delim)
    {
        return new List<string>(Lines.Split(new string[] { delim }, StringSplitOptions.None));

    }
    //Split Custom Funcion
    //public static List<string> SplitWords(string st, string delim)
    //{

    //    List<string> Words = new List<string>();
    //    int pos = 0;
    //    string word = "";

    //    while ((pos = st.IndexOf(delim)) != -1)
    //    {
    //        word = st.Substring(0, pos);
    //        if (!string.IsNullOrEmpty(word))
    //            Words.Add(word);
    //        word = "";
    //        st = st.Substring(pos + delim.Length);

    //    }

    //    if (!string.IsNullOrEmpty(st))
    //        Words.Add(st);

    //    return Words;
    //}

    // Method to convert client data to a string
    public static sClient ConvertRecordToLine(string line, string Seperator = "#//#")
    {
        sClient Client = new sClient();

        List<string> Words = Split_String(line, Seperator);
        Client.AccountNumber = Words[0];
        Client.PinCode = Words[1];
        Client.Name = Words[2];
        Client.Phone = Words[3];
        Client.AccountBalance = Convert.ToDouble(Words[4]);

        return Client;
    }

    // Method to add the data to the file
    public static List<sClient> ReadDataLineFromFile(string FileName)
    {
        List<sClient> Clients = new List<sClient>();
        try
        {
            using (StreamReader reader = new StreamReader(FileName))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    sClient client = ConvertRecordToLine(line);
                    Clients.Add(client);

                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error reading from file: " + ex.Message);
        }
        return Clients;

    }

    public static void Print(List<sClient> client)
    {
        foreach (sClient c in client)
        {
            Console.WriteLine(c.AccountNumber + " " + c.PinCode + " " + c.Name + " " + c.Phone + " " + c.AccountBalance);
        }


    }
    static void Main(string[] args)
    {

        List<sClient> client = ReadDataLineFromFile(ClientsFileName);
        Print(client);

        Console.ReadKey();
    }
}
