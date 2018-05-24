using System;

public class Employee : Worker, ISleeper
{
    public Employee(string id) : base(id)
    {
    }

    public void EmployeeWork(int hours)
    {
        base.Work(hours);
    }

    public void Sleep()
    {
        Console.WriteLine("Employee fallen asleep");
    }
}

