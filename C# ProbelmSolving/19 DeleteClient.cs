using System;
using System.Collections.Generic;
using System.IO;

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
        public bool MarkForDelete;  // To mark the client for deletion
    }

    // Method to split string by delimiter
    public static List<string> SplitString(string S1, string Delim)
    {
        List<string> vString = new List<string>();
        int pos = 0;
        string sWord;

        while ((pos = S1.IndexOf(Delim)) != -1)
        {
            sWord = S1.Substring(0, pos);
            if (!string.IsNullOrEmpty(sWord))
            {
                vString.Add(sWord);
            }
            S1 = S1.Substring(pos + Delim.Length);
        }

        if (!string.IsNullOrEmpty(S1))
        {
            vString.Add(S1);  // Add the last word
        }

        return vString;
    }

    // Convert a line of text into a client record
    public static sClient ConvertLinetoRecord(string Line, string Seperator = "#//#")
    {
        sClient Client = new sClient();
        List<string> vClientData = SplitString(Line, Seperator);

        Client.AccountNumber = vClientData[0];
        Client.PinCode = vClientData[1];
        Client.Name = vClientData[2];
        Client.Phone = vClientData[3];
        Client.AccountBalance = Convert.ToDouble(vClientData[4]);

        return Client;
    }

    // Convert a client record to a line of text
    public static string ConvertRecordToLine(sClient Client, string Seperator = "#//#")
    {
        return $"{Client.AccountNumber}{Seperator}{Client.PinCode}{Seperator}{Client.Name}{Seperator}{Client.Phone}{Seperator}{Client.AccountBalance}";
    }

    // Load clients data from a file
    
    public static List<sClient> LoadClientsDataFromFile(string FileName)
    {
        List<sClient> vClients = new List<sClient>();

        try
        {
            using (StreamReader MyFile = new StreamReader(FileName))
            {
                string Line;
                while ((Line = MyFile.ReadLine()) != null)
                {
                    sClient Client = ConvertLinetoRecord(Line);
                    vClients.Add(Client);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error reading file: " + ex.Message);
        }

        return vClients;
    }

    // Print the client details
    public static void PrintClientCard(sClient Client)
    {
        Console.WriteLine("\nThe following are the client details:");
        Console.WriteLine($"Account Number: {Client.AccountNumber}");
        Console.WriteLine($"Pin Code: {Client.PinCode}");
        Console.WriteLine($"Name: {Client.Name}");
        Console.WriteLine($"Phone: {Client.Phone}");
        Console.WriteLine($"Account Balance: {Client.AccountBalance}");
    }

    // Find a client by account number
    public static bool FindClientByAccountNumber(string AccountNumber, List<sClient> vClients, out sClient Client)
    {
        Client = new sClient();
        foreach (sClient C in vClients)
        {
            if (C.AccountNumber == AccountNumber)
            {
                Client = C;
                return true;
            }
        }
        return false;
    }

    // Mark a client for deletion

    public static bool MarkClientForDeleteByAccountNumber(string AccountNumber, ref List<sClient> vClients)
    {
        for (int i = 0; i < vClients.Count; i++)
        {
            sClient C = vClients[i];
            if (C.AccountNumber == AccountNumber)
            {
                C.MarkForDelete = true;
                vClients[i] = C; // Update the list with the modified client
                return true;
            }
        }
        return false;
    }


    // Save clients data to the file
    public static List<sClient> SaveClientsDataToFile(string FileName, List<sClient> vClients)
    {
        try
        {
            using (StreamWriter MyFile = new StreamWriter(FileName, false)) // Overwrite file
            {
                foreach (sClient C in vClients)
                {
                    if (!C.MarkForDelete)
                    {
                        string DataLine = ConvertRecordToLine(C);
                        MyFile.WriteLine(DataLine);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error saving file: " + ex.Message);
        }

        return vClients;
    }

    // Delete a client by account number
    public static bool DeleteClientByAccountNumber(string AccountNumber, ref List<sClient> vClients)
    {
        sClient Client;
        char Answer = 'n';

        if (FindClientByAccountNumber(AccountNumber, vClients, out Client))
        {
            PrintClientCard(Client);
            Console.WriteLine("\nAre you sure you want to delete this client? y/n?");
            Answer = Char.ToLower(Console.ReadKey().KeyChar);

            if (Answer == 'y')
            {
                MarkClientForDeleteByAccountNumber(AccountNumber, ref vClients);
                SaveClientsDataToFile(ClientsFileName, vClients);
               // vClients = LoadClientsDataFromFile(ClientsFileName); // Reload data after deletion
                Console.WriteLine("\nClient deleted successfully.");
                return true;
            }
        }
        else
        {
            Console.WriteLine($"\nClient with Account Number ({AccountNumber}) not found!");
            return false;
        }

        return false;
    }

    // Read account number from user input
    public static string ReadClientAccountNumber()
    {
        Console.WriteLine("\nPlease enter Account Number:");
        return Console.ReadLine();
    }

    static void Main(string[] args)
    {
        string AccountNumber = ReadClientAccountNumber();
        List<sClient> vClients = LoadClientsDataFromFile(ClientsFileName);

     

        DeleteClientByAccountNumber(AccountNumber, ref vClients);

        Console.ReadKey();

    }
}
