using System;
using System.IO;

class Program
{
    // Define a constant for the file name
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
    public static sClient ReadNewClient()
    {
        sClient Client = new sClient();

        Console.Write("Enter Account Number: ");
        Client.AccountNumber = Console.ReadLine();

        Console.Write("Enter PinCode: ");
        Client.PinCode = Console.ReadLine();

        Console.Write("Enter Name: ");
        Client.Name = Console.ReadLine();

        Console.Write("Enter Phone: ");
        Client.Phone = Console.ReadLine();

        Console.Write("Enter AccountBalance: ");
        Client.AccountBalance = Convert.ToDouble(Console.ReadLine());

        return Client;
    }

    // Method to convert client data to a string
    public static string ConvertRecordToLine(sClient Client, string Seperator = "#//#")
    {
        string stClientRecord = "";
        stClientRecord += Client.AccountNumber + Seperator;
        stClientRecord += Client.PinCode + Seperator;
        stClientRecord += Client.Name + Seperator;
        stClientRecord += Client.Phone + Seperator;
        stClientRecord += Client.AccountBalance.ToString();
        return stClientRecord;
    }

    // Method to add the data to the file
    public static void AddDataLineToFile(string FileName, string stDataLine)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(FileName, true))
            {
                writer.WriteLine(stDataLine);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error writing to file: " + ex.Message);
        }
    }

    // Method to add a new client
    public static void AddNewClient()
    {
        sClient Client = ReadNewClient();
        AddDataLineToFile(ClientsFileName, ConvertRecordToLine(Client));
    }

    // Method to add multiple clients
    public static void AddClients()
    {
        char AddMore = 'Y';
        do
        {
            Console.Clear();
            Console.WriteLine("Adding New Client:\n");
            AddNewClient();

            Console.WriteLine("\nClient Added Successfully, do you want to add more clients? Y/N? ");
            AddMore = Char.ToUpper(Console.ReadKey().KeyChar);


        } while (AddMore == 'Y');
    }

    // Main method
    static void Main(string[] args)
    {
        AddClients();
    }
}
