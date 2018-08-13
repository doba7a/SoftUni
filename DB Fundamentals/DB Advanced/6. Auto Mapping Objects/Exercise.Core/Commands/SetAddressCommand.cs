namespace Exercise.Core.Commands
{
    using Exercise.Core.Commands.Contracts;
    using Exercise.Core.Models;
    using Exercise.IO;
    using Exercise.Services.Contracts;
    using System.Linq;

    public class SetAddressCommand : ICommand
    {
        private IEmployeeService employeeService;

        public SetAddressCommand(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public string Execute(params string[] args)
        {
            int employeeId = int.Parse(args[0]);
            string address = string.Join(" ", args.Skip(1));

            EmployeeDto employeeDto = this.employeeService.SetAddress<EmployeeDto>(employeeId, address);

            return string.Format(Constants.EmployeeAddressSet,
                employeeId,
                address);
        }
    }
}
