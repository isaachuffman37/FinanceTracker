public class Report
{
    DateTime _startDate;
    DateTime _endDate;
    float _totalExpenses;
    float _totalIncome;    
    float _addAmount;
    float _expenseAmount;
    float _incomeAmount;

    public void CalcCurrentBudgets(List<Budget> budgets, List<Expense> expenses, List<Expense> usedExpenses)
    {
        List<Expense> removeExpenses = new List<Expense>();
        
        if (expenses.Count() != 0 && budgets.Count() != 0)
        {
            foreach (Budget budget in budgets)
            {
                foreach (Expense expense in expenses)
                {
                    if (budget.ReturnCategory() == expense.ReturnExpenseCategory() && expense.ReturnDate() >= _startDate && expense.ReturnDate() <= _endDate)
                    {
                        _addAmount = expense.ReturnAmount();
                        budget.AddExpenseToBudget(_addAmount);
                        removeExpenses.Add(expense);
                        usedExpenses.Add(expense);
                    }
                }
            }

            foreach (Expense expense in removeExpenses)
            {
                expenses.Remove(expense);
            }
        }
    }

    public void CalcTotalExpenses(List<Expense> expenses, List<Expense> usedExpenses)
    {
        if (expenses.Count() > 0)
        {
            foreach(Expense expense in expenses)
            {
                DateTime expenseDate = expense.ReturnDate();
                if(_startDate <= expenseDate && expenseDate <= _endDate)
                {
                    _expenseAmount = expense.ReturnAmount();
                    _totalExpenses += _expenseAmount;
                }
            }
        }
        if (usedExpenses.Count() > 0)
        {
            foreach(Expense usedExpense in usedExpenses)
            {
                DateTime usedExpenseDate = usedExpense.ReturnDate();
                if(_startDate <= usedExpenseDate && usedExpenseDate <= _endDate)
                {
                     _expenseAmount = usedExpense.ReturnAmount();
                    _totalExpenses += _expenseAmount;
                }
            }
        }
    }

    public void DisplayTotalExpenses()
    {
        double roundedExpenses = Math.Round(_totalExpenses, 2);
        Console.WriteLine($"Your total expenses are: $-{roundedExpenses} ");
    }

    public void CalcTotalIncome(List<Income> incomes)
    {
        foreach(Income income in incomes)
        {
            DateTime incomeDate = income.ReturnDate();
            if(_startDate <= incomeDate && incomeDate <= _endDate)
            {
                _incomeAmount = income.ReturnIncomeAmount();
                _totalIncome += _incomeAmount;
            }
        }
    }

    public void DisplayTotalIncome()
    {
        double roundedIncome = Math.Round(_totalIncome, 2);
        Console.WriteLine($"Your total income is: ${roundedIncome} ");
    }

     public void GetStartDate()
    {
        Console.Write("What is the date you want the data to start?(MM/DD/YYYY) ");
        string _userInput = Console.ReadLine();
        if (DateTime.TryParse(_userInput, out _startDate))
        {

        }
        else
        {
            Console.WriteLine("Invalid date and time format.");
        }
    }

    public void SetStartDate(DateTime startDate)
    {
        _startDate = startDate;
    }

    public void GetEndDate()
    {
        Console.Write("What is the date you want the data to end?(MM/DD/YYYY) ");
        string endDate = Console.ReadLine();
        if (DateTime.TryParse(endDate, out _endDate))
        {

        }
        else
        {
            Console.WriteLine("Invalid date and time format.");
        }
    }

    public void DisplayBudgets(List<Budget> budgets)
    {
        foreach (Budget budget in budgets)
        {
            budget.DisplayBudget();
        }
    }

    public void SetEndDate(DateTime endDate)
    {
        _endDate = endDate;
    }

    public void DisplayReport(List<Budget>budgets, List<Expense>expenses, List<Income> incomes, List<Expense> usedExpenses)
    {
        GetStartDate();
        GetEndDate();
        CalcCurrentBudgets(budgets, expenses, usedExpenses);
        DisplayBudgets(budgets);
        CalcTotalExpenses(expenses, usedExpenses);
        DisplayTotalExpenses();
        CalcTotalIncome(incomes);
        DisplayTotalIncome();

    }



}