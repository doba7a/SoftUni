public class PartTimeEmployee : Employee
{
    private const int PART_TIME_EMPLOYEE_WORK_HOURS_PER_WEEK = 20;

    public PartTimeEmployee(string name) 
        : base(name, PART_TIME_EMPLOYEE_WORK_HOURS_PER_WEEK)
    {
    }
}

