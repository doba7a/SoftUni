namespace Exercise.Core.Commands
{
    using Exercise.Core.Commands.Contracts;
    using Exercise.IO;
    using Exercise.Services.Contracts;

    public class DeleteEmployeeCommand : ICommand
    {
        private IEmployeeService employeeService;

        public DeleteEmployeeCommand(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public string Execute(params string[] args)
        {
            int employeeId = int.Parse(args[0]);

            this.employeeService.DeleteEmployee(employeeId);

            return string.Format(Constants.EmployeeRemoved, employeeId);
        }
    }
}
