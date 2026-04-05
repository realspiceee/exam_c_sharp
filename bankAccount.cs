using System;

class BankAccount
{
    private decimal balance;

    public decimal Balance
    {
        get { return balance; }
    }

    public BankAccount(decimal initialBalance)
    {
        if (initialBalance < 0)
            throw new ArgumentException("Баланс не может быть отрицательным");

        balance = initialBalance;
    }

    public void Deposit(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Сумма должна быть положительной");

        balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Сумма должна быть положительной");

        if (amount > balance)
            throw new InvalidOperationException("Недостаточно средств");

        balance -= amount;
    }
}

class Program
{
    static void Main()
    {
        BankAccount account = new BankAccount(1000);

        account.Deposit(500);
        Console.WriteLine($"После пополнения: {account.Balance}");

        account.Withdraw(300);
        Console.WriteLine($"После снятия: {account.Balance}");
    }
}