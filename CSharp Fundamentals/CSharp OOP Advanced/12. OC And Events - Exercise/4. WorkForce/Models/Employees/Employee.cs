public abstract class Employee : IEmployee
{
    private string name;
    private int workHoursPerWeek;

    protected Employee(string name, int workHoursPerWeek)
    {
        this.Name = name;
        this.WorkHoursPerWeek = workHoursPerWeek;
    }

    public string Name { get => name; private set => name = value; }
    public int WorkHoursPerWeek { get => workHoursPerWeek; private set => workHoursPerWeek = value; }
}

