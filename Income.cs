public class Income : Transaction
{
    string _source;
    public override string DisplayTransaction()
    {
        return $"+{_amount} {_description} {_date}";
    }

    public void GetSource()
    {
        Console.Write("What source did this come from? ");
        _source = Console.ReadLine();
    }

    public void SetSource(string source)
    {
        _source = source;
    }

    public override void AddTransaction(BankAccount b)
    {
        base.AddTransaction(b);
        GetSource();
        AddTransactionToBalance(b);
    }

    

    public float ReturnIncomeAmount()
    {
        return _amount;
    }

    public override void GetTransactionType()
    {
        _type = "income";
    }
    

    public override void AddTransactionToBalance(BankAccount b)
    {
    
    }

    public override string StringifyTransaction()
    {
        return $"{_type};{_amount};{_description};{_dateInput};{_source}";
    }

    
}