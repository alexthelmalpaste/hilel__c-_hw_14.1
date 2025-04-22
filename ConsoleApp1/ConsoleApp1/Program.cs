using System;

public class Account
{
    public string Name { get; }
    private double balance;

    public Account(string name, double initialBalance)
    {
        Name = name;
        balance = initialBalance >= 0 ? initialBalance : throw new ArgumentException("Баланс не може бути менше 0.");
    }

    public void Deposit(double amount)
    {
        if (amount > 0)
        {
            balance += amount;
        }
        else
        {
            throw new ArgumentException("Сума депозиту повинна бути більше 0.");
        }
    }

    public void Withdrawal(double amount)
    {
        if (amount > 0 && balance - amount >= 0)
        {
            balance -= amount;
        }
        else
        {
            throw new ArgumentException("Недостатньо коштів або некоректна сума.");
        }
    }

    public double Balance
    {
        get { return balance; }
    }
}

class Program
{
    static void Main()
    {
        Account heikkisAccount = new Account("Heikki's account", 100.00);
        Account heikkisSwissAccount = new Account("Heikki's account in Switzerland", 1000000.00);

        heikkisAccount.Withdrawal(20);
        Console.WriteLine("The balance of Heikki's account is now: " + heikkisAccount.Balance);

        heikkisSwissAccount.Deposit(200);
        Console.WriteLine("The balance of Heikki's other account is now: " + heikkisSwissAccount.Balance);
    }
}
0