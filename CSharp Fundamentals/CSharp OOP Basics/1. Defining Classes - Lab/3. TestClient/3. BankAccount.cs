using System;

public class BankAccount
{
    private int id;
    private decimal balance;

    public int Id
    {
        get { return this.id; }
        set { this.id = value; }
    }

    public decimal Balance
    {
        get { return this.balance; }
        set { this.balance = value; }
    }

    public void Deposit(decimal amount)
    {
        this.Balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        if (this.Balance - amount >= 0)
        {
            this.Balance -= amount;
        }
        else
        {
            Console.WriteLine("Insufficient balance");
        }
    }

    public override string ToString()
    {
        return $"Account ID{this.Id}, balance {this.Balance:F2}";
    }
}


