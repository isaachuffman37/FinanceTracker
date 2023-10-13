using System.IO;

public class Menu
{
    List<Budget> _budgets = new List<Budget>();
    List<Expense> _expenses = new List<Expense>();
    List<Expense> _usedExpenses = new List<Expense>();
    List<Transaction> _transactions = new List<Transaction>();
    List<Income> _incomes = new List<Income>();
    List<BankAccount> _accounts = new List<BankAccount>();
    User user = new User();
    BankAccount bank = new BankAccount();

    string _budgetResponse = "";
    string _accountResponse;
    string _optionResponse;
    bool correctName = false;
    bool correctPassword = false;


    public void DisplayMenu()
    {
        Console.Write("1. Sign In\n2. Create Account\nWhich would you like to do? ");
        _accountResponse = Console.ReadLine();
        if(_accountResponse == "1")
        {
            while ( correctName == false)
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("You are not signed in yet, please provide your correct name and password");
                AuthenticateName();
            }

            while (correctPassword == false)
            {
                AuthenticatePassword();
            }

            string name = user.ReturnName();
            Console.WriteLine();
            Console.WriteLine();
            Console.Clear();
            Console.WriteLine($"Welcome, {name}. You are signed in! Please enjoy your finance tracker:)");

            while (_optionResponse != "7")
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.Write("1. View Account And History\n2. Add Budget Element\n3. Add Expense\n4. Add Income\n5. View Report\n6. Save\n7. Quit\nWhich would you like to do? ");
                _optionResponse = Console.ReadLine();
                Console.WriteLine();
                Console.WriteLine();

                switch(_optionResponse)
                {
                    case "1":
                        bank.DisplayBankAccount();
                        bank.DisplayTransactions(_transactions);
                        break;
                    case "2":
                        Budget budget = new Budget();
                        budget.AddBudget();
                        _budgets.Add(budget);
                        break;
                    case "3":
                        Expense e = new Expense();
                        e.AddTransaction(bank);
                        bank.AddTransactionToBalance(e);
                        _transactions.Add(e);
                        _expenses.Add(e);
                        break;
                    case "4":
                        Income i = new Income();
                        i.AddTransaction(bank);
                        bank.AddTransactionToBalance(i);
                        _transactions.Add(i);
                        _incomes.Add(i);
                        break;
                    case "5":
                        
                        Report r = new Report();
                        r.DisplayReport(_budgets,_expenses,_incomes, _usedExpenses);
                        
                        break;
                    case "6":
                        SaveFile(user,_accounts,_budgets,_expenses,_incomes);
                        break;
                    case "7":

                        break;
                    default:
                        Console.Write($"{_optionResponse} was an invalid option, please choose again");
                        break;
                }
            }
        }
        if (_accountResponse == "2")
        {
    
            user.AddUser();
            Console.WriteLine();
            Console.WriteLine("Congratulations! You are now signed in.\nNow let's add an account:");
            Console.WriteLine();

            
            bank.AddBankAccount();
            Console.WriteLine();
            Console.WriteLine("Perfect! Now, think of the elements of your budget.\nLet's add one of them now:");
            _accounts.Add(bank);
            
            while (_budgetResponse != "n")
            {
                Budget bgt = new Budget();
                bgt.AddBudget();
                _budgets.Add(bgt);
                Console.WriteLine();
                Console.Write("Your budget element has been successfully added.\nWould you like to add another one?(y/n) ");
                _budgetResponse = Console.ReadLine();
            } 

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Now you are all set up! Take a look at the options below to track your finances");
        
            while (_optionResponse != "7")
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.Write("1. View Account And History\n2. Add Budget Element\n3. Add Expense\n4. Add Income\n5. View Report\n6. Save\n7. Quit\nWhich would you like to do? ");
                _optionResponse = Console.ReadLine();
                Console.WriteLine();
                Console.WriteLine();

                switch(_optionResponse)
                {
                    case "1":
                        bank.DisplayBankAccount();
                        bank.DisplayTransactions(_transactions);
                        break;
                    case "2":
                        Budget budget = new Budget();
                        budget.AddBudget();
                        _budgets.Add(budget);
                        break;
                    case "3":
                        Expense e = new Expense();
                        e.AddTransaction(bank);
                        bank.AddTransactionToBalance(e);
                        _transactions.Add(e);
                        _expenses.Add(e);
                        break;
                    case "4":
                        Income i = new Income();
                        i.AddTransaction(bank);
                        bank.AddTransactionToBalance(i);
                        _transactions.Add(i);
                        _incomes.Add(i);
                        break;
                    case "5":
                        Report r = new Report();
                        r.DisplayReport(_budgets,_expenses,_incomes, _usedExpenses);
                        break;
                    case "6":
                        SaveFile(user,_accounts,_budgets,_expenses,_incomes);
                        break;
                    case "7":

                        break;
                    default:
                        Console.Write($"{_optionResponse} was an invalid option, please choose again");
                        break;
                }
            }
        }
    }
    

    public void SaveFile(User u, List<BankAccount> b, List<Budget> budgets, List<Expense> expenses, List<Income> incomes )
    {
        string filename = u.ReturnName() + ".txt";
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine($"{u.StringifyUser()}");

            foreach (BankAccount account in b)
            {
              outputFile.WriteLine($"{account.StringifyAccount()}");  
            }

            foreach (Budget budget in budgets)
            {
                outputFile.WriteLine($"{budget.StringifyBudget()}");
            }

            foreach (Expense expense in expenses)
            {
                outputFile.WriteLine($"{expense.StringifyTransaction()}");
            }
            
            foreach (Expense expense in _usedExpenses)
            {
                outputFile.WriteLine($"{expense.StringifyTransaction()}");
            }

            foreach (Income income in incomes)
            {
                outputFile.WriteLine($"{income.StringifyTransaction()}");
            }
            

        }
    }

    public void LoadFile(User u)
    {
        string filename = u.ReturnName() + ".txt";
        string[] lines = System.IO.File.ReadAllLines(filename);
        foreach (string line in lines)
        {
            string[] parts = line.Split(";");
            if (parts[0] == "user")
            {
                string type = parts[0];
                string name = parts[1];
                string password = parts[2];
                user.SetName(name);
                user.SetPassword(password);
            }

            if (parts[0]== "account")
            {
               string name = parts[1];
               string number = parts[2];
               float balance = float.Parse(parts[3]);
               bank.SetName(name);
               bank.SetNumber(number);
               bank.SetBalance(balance);
               _accounts.Add(bank);

            }

            if (parts[0] == "budget")
            {
               string category = parts[1];
               float amount = float.Parse(parts[2]);
               Budget budget = new Budget();
               budget.SetCategory(category);
               budget.SetBudgetAmount(amount);
               _budgets.Add(budget);

            }

            if (parts[0] == "expense")
            {
                string budgetType = parts[0];
                float amount = float.Parse(parts[1]);
                string description = parts[2];
                string date = parts[3];
                string category = parts[4];
                Expense expense = new Expense();
                expense.SetAmount(amount);
                expense.SetCategory(category);
                expense.SetDate(date);
                expense.SetDescription(description);
                expense.GetTransactionType();
                _expenses.Add(expense);
                _transactions.Add(expense);
            }

            if (parts[0] == "income")
            {
                string budgetType = parts[0];
                float amount = float.Parse(parts[1]);
                string description = parts[2];
                string date = parts[3];
                string source = parts[4];
                Income income = new Income();
                income.SetAmount(amount);
                income.SetDate(date);
                income.SetDescription(description);
                income.SetSource(source);
                income.GetTransactionType();
                _incomes.Add(income);
                _transactions.Add(income);
            }
        }
    }


    public bool SignInLoadFile(string filename)
    {
        try
        {
            string[] lines = System.IO.File.ReadAllLines(filename);
            foreach (string line in lines)
            {
                string[] parts = line.Split(";");
                if (parts[0] == "user")
                {
                    string type = parts[0];
                    string name = parts[1];
                    string password = parts[2];
                    user.SetName(name);
                    user.SetPassword(password);
                }

                else if (parts[0]== "account")
                {
                string name = parts[1];
                string number = parts[2];
                float balance = float.Parse(parts[3]);
                bank.SetName(name);
                bank.SetNumber(number);
                bank.SetBalance(balance);
                _accounts.Add(bank);

                }

                else if (parts[0] == "budget")
                {
                string category = parts[1];
                float amount = float.Parse(parts[2]);
                Budget budget = new Budget();
                budget.SetCategory(category);
                budget.SetBudgetAmount(amount);
                _budgets.Add(budget);

                }

                else if (parts[0] == "expense")
                {
                    string budgetType = parts[0];
                    float amount = float.Parse(parts[1]);
                    string description = parts[2];
                    string date = parts[3];
                    string category = parts[4];
                    Expense expense = new Expense();
                    expense.SetAmount(amount);
                    expense.SetCategory(category);
                    expense.SetDateInput(date);
                    expense.SetDate(date);
                    expense.SetDescription(description);
                    expense.GetTransactionType();
                    _transactions.Add(expense);
                    _expenses.Add(expense);

                }

                else if (parts[0] == "income")
                {
                    string budgetType = parts[0];
                    float amount = float.Parse(parts[1]);
                    string description = parts[2];
                    string date = parts[3];
                    string source = parts[4];
                    Income income = new Income();
                    income.SetAmount(amount);
                    income.SetDateInput(date);
                    income.SetDate(date);
                    income.SetDescription(description);
                    income.SetSource(source);
                    income.GetTransactionType();
                    _transactions.Add(income);
                    _incomes.Add(income);
                }
            }
            return true;
        }

        catch
        {
            return false;
        }
    }

    public void AuthenticatePassword()
    {
        Console.Write("Password: ");
        string password = Console.ReadLine();
        if(user.ReturnPassword() == password)
        {
            correctPassword = true;
        }
        else
        {
            Console.WriteLine("The password you entered is not correct. Please try again.");
            correctPassword = false;
        }

    }

    public void AuthenticateName()
    {
        Console.Write("Name: ");
        string name = Console.ReadLine();
        string filename = name + ".txt";

        if (SignInLoadFile(filename) == true)
        {
            correctName = true;
        }
        else
        {
            Console.WriteLine("The name you entered does not exist, please try again");
            correctName = false;
        }
    }
}



