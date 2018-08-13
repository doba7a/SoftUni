namespace Exercise.Core.Commands
{
    using Exercise.Core.Commands.Contracts;
    using Exercise.Core.Models;
    using Exercise.IO;
    using Exercise.Services.Contracts;

    public class EmployeeInfoCommand : ICommand
    {
        private IEmployeeService employeeService;

        public EmployeeInfoCommand(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public string Execute(params string[] args)
        {
            int employeeId = int.Parse(args[0]);

            EmployeeDto employeeDto = this.employeeService.EmployeeInfo<EmployeeDto>(employeeId);

            return string.Format(Constants.EmployeeInfo,
                employeeDto.Id,
                employeeDto.FirstName,
                employeeDto.LastName,
                employeeDto.Salary);
        }
    }
}
