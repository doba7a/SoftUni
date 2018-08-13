namespace Exercise.Core.Commands
{
    using Exercise.Core.Commands.Contracts;
    using Exercise.Core.Models;
    using Exercise.IO;
    using Exercise.Services.Contracts;

    public class AddEmployeeCommand : ICommand
    {
        private IEmployeeService employeeService;

        public AddEmployeeCommand(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public string Execute(params string[] args)
        {
            string firstName = args[0];
            string lastName = args[1];
            decimal salary = decimal.Parse(args[2]);

            EmployeeDto employeeDto = this.employeeService.AddEmployee<EmployeeDto>(firstName, lastName, salary);

            return string.Format(Constants.EmployeeAdded,
                firstName,
                lastName);
        }
    }
}
