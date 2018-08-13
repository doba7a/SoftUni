namespace Exercise.Core.Commands
{
    using Exercise.Core.Commands.Contracts;
    using Exercise.Core.Models;
    using Exercise.IO;
    using Exercise.Services.Contracts;
    using System.Text;

    public class ListEmployeesOlderThanAgeCommand : ICommand
    {
        private IEmployeeService employeeService;

        public ListEmployeesOlderThanAgeCommand(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public string Execute(params string[] args)
        {
            int ageGiven = int.Parse(args[0]);

            ProjectionDto[] projectionDtos = employeeService.EmployeeOlderThan<ProjectionDto>(ageGiven);

            StringBuilder sb = new StringBuilder();

            foreach (ProjectionDto emp in projectionDtos)
            {
                sb.AppendLine(string.Format(Constants.Projection,
                    emp.FirstName,
                    emp.LastName,
                    emp.Salary,
                    emp.ManagerLastName == null ? "[no manager]" : emp.ManagerLastName));
            }

            return sb.ToString().TrimEnd();
        }
    }
}
