

// BankAccount class to represent individual accounts
using System.Dynamic;

class BankAccount
{

    private static int lastAccountID = 1000;
    public string Owner = "";
    
    public int accountID {get; set;}
    public double Balance;
    static Random IDgenerate = new Random();
    // Static field to generate unique account IDs


    // Properties: AccountID, Owner, and Balance

    public BankAccount(string Owner){
        
    this.accountID = ++lastAccountID;
    this.Owner = Owner;
    int Balance = 0;
    }
    
        public BankAccount(){}
    public static void SetLastAccountID(int maxID){

        lastAccountID = maxID;
    }





    // Constructor to initialise a new account with an owner and unique ID

    // Method to deposit money
    public void Deposit(double amount)
    {
        // Validate amount (must be positive)
        if(amount > 0){
            Balance += amount;
            Console.WriteLine($"You have added {amount} to your account, your new balance is now {Balance}");
        } 
        // Add amount to balance
        // Display confirmation message
        else
        {
            Console.WriteLine("That amount is not applicable in this context, please try again");
        }
    }

    // Method to withdraw money
    public void Withdraw(double amount)
    {
        // Validate amount (must be positive and not exceed balance)
        if(Balance > amount && amount > 0){
            Balance -= amount;
            Console.WriteLine($"You have successfully withdrawn {amount} from your account, your new balance is now {Balance}");
        }
        else{
            Console.WriteLine("That amount is not applicable in this context, please try again");
        }
    }
    
    // Method to return account details as a string
    public void Display()
    {
        // Format and return account details
        Console.WriteLine($"Account ID: {lastAccountID}");
        Console.WriteLine($"Owner: {lastAccountID}");
        Console.WriteLine($"Balance: {Balance}");
    }
}
