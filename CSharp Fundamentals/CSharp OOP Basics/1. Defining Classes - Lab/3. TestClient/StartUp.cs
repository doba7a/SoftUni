using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        Dictionary<int, BankAccount> bankAccDict = new Dictionary<int, BankAccount>();

        string currentInput = Console.ReadLine();

        while (currentInput != "End")
        {
            string[] inputData = currentInput
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string command = inputData[0];
            int accId = int.Parse(inputData[1]);

            switch (command)
            {
                case "Create":
                    Create(bankAccDict, accId);
                    break;
                case "Deposit":
                    decimal depositAmount = decimal.Parse(inputData[2]);
                    Deposit(bankAccDict, accId, depositAmount);
                    break;
                case "Withdraw":
                    decimal withdrawAmount = decimal.Parse(inputData[2]);
                    Withdraw(bankAccDict, accId, withdrawAmount);
                    break;
                case "Print":
                    Print(bankAccDict, accId);
                    break;
            }

            currentInput = Console.ReadLine();
        }
    }

    private static void Create(Dictionary<int, BankAccount> bankAccDict, int accId)
    {
        if (!bankAccDict.ContainsKey(accId))
        {
            BankAccount currentAcc = new BankAccount
            {
                Id = accId,
                Balance = 0
            };

            bankAccDict.Add(accId, currentAcc);
        }
        else
        {
            Console.WriteLine("Account already exists");
        }
    }

    private static void Deposit(Dictionary<int, BankAccount> bankAccDict, int accId, decimal depositAmount)
    {
        if (ExistingAccount(bankAccDict, accId))
        {
            bankAccDict[accId].Deposit(depositAmount);
        }
        else
        {
            Console.WriteLine("Account does not exist");
        }
    }

    private static void Withdraw(Dictionary<int, BankAccount> bankAccDict, int accId, decimal withdrawAmount)
    {
        if (ExistingAccount(bankAccDict, accId))
        {
            bankAccDict[accId].Withdraw(withdrawAmount);
        }
        else
        {
            Console.WriteLine("Account does not exist");
        }
    }

    private static void Print(Dictionary<int, BankAccount> bankAccDict, int accId)
    {
        if (ExistingAccount(bankAccDict, accId))
        {
            Console.WriteLine(bankAccDict[accId]);
        }
        else
        {
            Console.WriteLine("Account does not exist");
        }
    }

    private static bool ExistingAccount(Dictionary<int, BankAccount> bankAccDict, int accId)
    {
        if (!bankAccDict.ContainsKey(accId))
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
