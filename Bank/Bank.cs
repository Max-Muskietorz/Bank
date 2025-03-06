using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;

// Bank class to manage multiple accounts
class Bank
{
    List<BankAccount> accounts = new List<BankAccount>{};
    static string DataBaseFile = "accounts.json";
    BankAccount bankAccount = new BankAccount();

    public Bank (){

        accounts = LoadAccounts();
    }
    // Method to run the banking system loop

public void Run()
    {
        Console.WriteLine("Welcome to the Bank Account Management System!");

        while (true)
        {
            Console.WriteLine("\n1. Create Account\n2. Deposit\n3. Withdraw\n4. Display Accounts\n5. Bank Account Balance");
            Console.Write("Select an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateAccount();
                    break;
                case "2":
                    PerformTransaction();
                    break;
                case "3":
                    PerformTransaction();
                    break;
                case "4":
                    DisplayAccounts();
                    break;
                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }
        }
    }

    // Method to create a new bank account
    private void CreateAccount()
    {
        // Ask the user for their name
        Console.WriteLine("What is your name?: ");
        string name = Console.ReadLine();
        // Create a new BankAccount instance and store it in the list
        BankAccount account = new BankAccount(name);
        accounts.Add(account);

        SaveAccount();

        // Display confirmation with the account ID

        Console.WriteLine($"The name under your account is: {name}");
        Console.WriteLine($"Your account ID is: {account.accountID}");
        
        
    }

    private void SaveAccount(){
        try{
        string json = JsonSerializer.Serialize(accounts, new JsonSerializerOptions{WriteIndented = true});
        File.WriteAllText(DataBaseFile, json);   
        }
        catch(Exception ex){
            Console.WriteLine($"Error saving saccounts: {ex.Message}");
        }

    }        

    static List<BankAccount> LoadAccounts(){
        if(File.Exists(DataBaseFile)){
            string json = File.ReadAllText(DataBaseFile);
            var loadedAccounts = JsonSerializer.Deserialize<List <BankAccount>>(json) ?? new List<BankAccount>();
            
            if (loadedAccounts.Count > 0){

                int maxID = loadedAccounts.Max(a => a.accountID);
                BankAccount.SetLastAccountID(maxID);
            }
            return loadedAccounts;
                    }

    return new List<BankAccount>();
    }    
    
    
     // Method to handle deposits and withdrawals
    private void PerformTransaction()
    {
        // Ask for an account ID
        Console.WriteLine("What is your account ID?: ");
        int ID = int.Parse(Console.ReadLine());

            
        
        // Find the account in the list
        BankAccount account = accounts.Find(a => a.accountID == ID);
        if (account != null){

        // Ask for an amount and validate input
        Console.WriteLine("Would you like to deposit/withdraw?: ");
        string totTransaction = Console.ReadLine();
        Console.WriteLine("How much would you like to deposit/withdraw?");
        double toTransacte = int.Parse(Console.ReadLine());
        switch(totTransaction){
            case "deposit":
                account.Deposit(toTransacte);
                break;
            case "withdraw":
                account.Withdraw(toTransacte);
                break;
              
        }
        
        }
        
        // Perform deposit or withdrawal based on the boolean flag
    }

    // Method to display all account                                 

    private void DisplayAccounts()
    {
        List<BankAccount> accoun = LoadAccounts();      
                // Loop through the account list and print details
        foreach (var account in accoun){
            Console.WriteLine(account);
    }

    
}
}