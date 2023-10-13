public class User
{
    string _name;
    string _password;
    string _type = "user";

    public void DisplayName()
    {
        Console.WriteLine($"{_name}");
    }

    public void GetName()
    {
        Console.Write("What is your name? ");
        _name = Console.ReadLine();
    }

    public void SetName(string name)
    {
        _name = name;
    }

    public void GetPassword()
    {
        Console.Write("What is your password? ");
        _password = Console.ReadLine();
    }

    public void SetPassword(string password)
    {
        _password = password;
    }

    public void AddUser()
    {
        GetName();
        GetPassword();
    }
    public string ReturnName()
    {
        return _name;
    }
    public string ReturnPassword()
    {
        return _password;
    }

    public string StringifyUser()
    {
        return $"{_type};{_name};{_password}";
    }

    
}