using System;

public class EmployeeFactory : IEmployeeFactory
{
    public IEmployee CreateEmployee(string employeeType, string employeeName)
    {
        Type classType = Type.GetType(employeeType);

        IEmployee currentEmployee = (IEmployee)Activator.CreateInstance(classType, new object[] { employeeName });

        return currentEmployee;
    }
}

