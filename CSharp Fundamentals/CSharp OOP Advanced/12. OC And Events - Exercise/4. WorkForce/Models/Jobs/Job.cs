using System;

public class Job : IJob
{
    public event EventHandler JobDoneEventHandler;

    private string name;
    private int hoursOfWorkRequired;
    private IEmployee employee;
    private bool jobDone;

    public Job(string name, int hoursOfWorkRequired, IEmployee employee)
    {
        this.Name = name;
        this.HoursOfWorkRequired = hoursOfWorkRequired;
        this.Employee = employee;
        this.JobDone = false;
    }

    public string Name { get => name; private set => name = value; }
    public int HoursOfWorkRequired { get => hoursOfWorkRequired; private set => hoursOfWorkRequired = value; }
    public IEmployee Employee { get => employee; private set => employee = value; }
    public bool JobDone { get => jobDone; private set => jobDone = value; }

    public bool Update()
    {
        this.HoursOfWorkRequired -= this.Employee.WorkHoursPerWeek;

        if (this.HoursOfWorkRequired <= 0)
        {
            this.JobDoneEventHandler?.Invoke(this, EventArgs.Empty);
            return true;
        }

        return false;
    }

    public void OnJobDone(object sender, EventArgs e)
    {
        Console.WriteLine($"Job {this.Name} done!");
        this.JobDone = true;
    }

    public override string ToString()
    {
        return $"Job: {this.Name} Hours Remaining: {this.HoursOfWorkRequired}";
    }
}

