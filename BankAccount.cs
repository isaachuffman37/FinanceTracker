public class BankAccount
{
    string _accountName;
    string _accountNumber;
    double _balance;
    string _type = "account";

    public void GetName()
    {
        Console.Write("What is the name of your account? ");
        _accountName = Console.ReadLine();
    }

    public void SetName(string accountName)
    {
        _accountName = accountName;
    }

    public void GetNumber()
    {
        Console.Write("What is your account number? ");
        _accountNumber = Console.ReadLine();
    }

    public void SetNumber(string accountNumber)
    {
        _accountNumber = accountNumber;
    }

    public void GetBalance()
    {
        Console.Write("What is the balance of your account? ");
        _balance = float.Parse(Console.ReadLine());
    }

    public void SetBalance(float balance)
    {
        _balance = balance;
    }



    public void DisplayTransactions(List<Transaction> transactions)
    {
        if (transactions.Count() > 0)
        {
            foreach( Transaction transaction in transactions)
            {
                Console.WriteLine($"{transaction.DisplayTransaction()}");
            } 
        }
        else 
        {
            Console.WriteLine("You do not have any transactions recorded yet.");
        }
    }

    public void AddBankAccount()
    {
        GetName();
        GetNumber();
        GetBalance();
    }

    public void DisplayBankAccount()
    {
        double roundedBalance = Math.Round(_balance,2);
        Console.WriteLine($"Account Name: {_accountName}\nAccount Number: {_accountNumber}\nCurrent Balance: ${roundedBalance}");
    }

    public void AddTransactionToBalance(Transaction transaction)
    {
        float transAmount = transaction.ReturnAmount();
        if (transaction.ReturnType() == "income")
        {
            _balance += transAmount;
        }
        else if (transaction.ReturnType() == "expense")
        {
            _balance -= transAmount;
        }
    }

    public double ReturnBalance()
    {
        return _balance;
    }

    public string StringifyAccount()
    {
        return $"{_type};{_accountName};{_accountNumber};{_balance}";
    }
    


}