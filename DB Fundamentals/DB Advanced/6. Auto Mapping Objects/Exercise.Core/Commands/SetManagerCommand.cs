namespace Exercise.Core.Commands
{
    using Exercise.Core.Commands.Contracts;
    using Exercise.Core.Models;
    using Exercise.IO;
    using Exercise.Services.Contracts;

    public class SetManagerCommand : ICommand
    {
        private IEmployeeService employeeService;

        public SetManagerCommand(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public string Execute(params string[] args)
        {
            int employeeId = int.Parse(args[0]);
            int managerId = int.Parse(args[1]);

            EmployeeDto employeeDto = this.employeeService.SetManager<EmployeeDto>(employeeId, managerId);

            return string.Format(Constants.EmployeeManagerSet,
                managerId,
                employeeId);
        }
    }
}
