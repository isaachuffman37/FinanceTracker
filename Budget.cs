public class Budget
{
    string _category;
    float _amount;
    float _currentlySpent;
    float _amountLeft;
    float _percent;
    string _type = "budget";

    public void DisplayBudget()
    {
        _percent = (float)Math.Round(_currentlySpent/_amount * 100,1,MidpointRounding.AwayFromZero);
        _amountLeft = (float)Math.Round(_amount - _currentlySpent,2);
        Console.WriteLine($"{_category}: {_currentlySpent}/{_amount}");
        Console.WriteLine($"Percentage spent: {_percent}%");
        if (_amountLeft > 0)
        {   
            Console.WriteLine("You are currently UNDER budget.");
            Console.WriteLine($"Amount left: ${_amountLeft}");
        }
        else if (_amountLeft == 0)
        {
            Console.WriteLine("You have spent your budget");
        }
        else if (_amountLeft < 0)
        {
            Console.WriteLine("You have spent more than what you budgeted.");
            Console.WriteLine($"Amount overused: ${_amountLeft}");
        }
        Console.WriteLine("");
    }

    public void GetCurrentlySpent()
    {
        Console.Write("How much of the budget have you spent already? ");
        _currentlySpent = float.Parse(Console.ReadLine());
    }

    public void SetCurrentlySpent(float currentlySpent)
    {
        _currentlySpent = currentlySpent;
    }

    public void resetBudget()
    {
        _currentlySpent = 0;
    }

    public void AddExpenseToBudget(float expenseAmount)
    {
        _currentlySpent += expenseAmount;
    }

     public void GetCategory()
    {
        Console.Write("Which category is this budget for? ");
        _category = Console.ReadLine();
    }

    public void SetCategory(string category)
    {
        _category= category;
    }


     public void GetBudgetAmount()
    {
        Console.Write("How much would you like this budget to be? ");
        _amount = float.Parse(Console.ReadLine());
    }

    public void SetBudgetAmount(float amount)
    {
        _amount = amount;
    }

    public string ReturnCategory()
    {
        return _category;
    }

    public void AddBudget()
    {
        GetCategory();
        GetBudgetAmount();
        GetCurrentlySpent();

    }

    public string StringifyBudget()
    {
        return $"{_type};{_category};{_amount}";
    }








}