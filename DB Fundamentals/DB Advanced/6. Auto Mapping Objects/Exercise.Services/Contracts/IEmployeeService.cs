namespace Exercise.Services.Contracts
{
    public interface IEmployeeService
    {
        TModel AddEmployee<TModel>(string firstName, string lastName, decimal salary);

        TModel SetBirthday<TModel>(int employeeId, string date);

        TModel SetAddress<TModel>(int employeeId, string address);

        TModel EmployeeInfo<TModel>(int employeeId);

        TModel EmployeePersonalInfo<TModel>(int employeeId);

        TModel SetManager<TModel>(int employeeId, int managerId);

        TModel ManagerInfo<TModel>(int managerId);

        TModel[] EmployeeOlderThan<TModel>(int age);

        void DeleteEmployee(int employeeId);
    }
}
