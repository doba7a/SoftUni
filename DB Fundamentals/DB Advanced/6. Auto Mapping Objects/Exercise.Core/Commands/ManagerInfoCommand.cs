namespace Exercise.Core.Commands
{
    using Exercise.Core.Commands.Contracts;
    using Exercise.Core.Models;
    using Exercise.IO;
    using Exercise.Models;
    using Exercise.Services.Contracts;
    using System.Text;

    public class ManagerInfoCommand : ICommand
    {
        private IEmployeeService employeeService;

        public ManagerInfoCommand(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public string Execute(params string[] args)
        {
            int managerId = int.Parse(args[0]);

            ManagerDto managerDto = this.employeeService.ManagerInfo<ManagerDto>(managerId);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(string.Format(Constants.ManagerInfo,
                managerDto.FirstName,
                managerDto.LastName,
                managerDto.EmployeesManagedCount));

            foreach (Employee emp in managerDto.EmployeesManaged)
            {
                sb.AppendLine($"   - {emp.FirstName} {emp.LastName} - ${emp.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
