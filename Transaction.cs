public abstract class Transaction 
{
    protected float _amount;
    protected string _description;
    protected DateTime _date;
    protected string _type;
    protected string _dateInput;

    public abstract string DisplayTransaction();

    public void GetAmount()
    {
        Console.Write("What is the amount? ");
        _amount = float.Parse(Console.ReadLine());
    }

    public void SetAmount(float amount)
    {
        _amount = amount;
    }

    public void GetDescription()
    {
        Console.Write("What is the description? ");
        _description = Console.ReadLine();
    }

    public void SetDescription(string description)
    {
        _description = description;
    }

    public void GetDate()
    {
        Console.Write("Enter the date (MM/dd/yyyy): ");
        _dateInput = Console.ReadLine();


        if (DateTime.TryParse(_dateInput, out _date))
        {
            
        }
        else
        {
            // Failed to parse the user input
            Console.WriteLine("Invalid date and time format.");
        }
    }

    public void SetDate(string dateInput)
    {
        if (DateTime.TryParse(dateInput, out _date))
        {
            
        }
        else
        {
            Console.WriteLine("Invalid date and time format.");
        }
    }

    public void SetDateInput(string dateInput)
    {
        _dateInput = dateInput;
    }
    public virtual void AddTransaction(BankAccount b)
    {
        GetTransactionType();
        GetAmount();
        GetDescription();
        GetDate();
    }

    public DateTime ReturnDate()
    {
        return _date;
    }

    public float ReturnAmount()
    {
        return _amount;
    }

    public string ReturnType()
    {
        return _type;
    }

    public abstract void GetTransactionType();

    public abstract void AddTransactionToBalance(BankAccount b);

    public abstract string StringifyTransaction();
}