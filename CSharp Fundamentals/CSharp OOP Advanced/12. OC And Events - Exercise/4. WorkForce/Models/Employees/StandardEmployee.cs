public class StandardEmployee : Employee
{
    private const int STANDART_EMPLOYEE_WORK_HOURS_PER_WEEK = 40;

    public StandardEmployee(string name) 
        : base(name, STANDART_EMPLOYEE_WORK_HOURS_PER_WEEK)
    {
    }
}

