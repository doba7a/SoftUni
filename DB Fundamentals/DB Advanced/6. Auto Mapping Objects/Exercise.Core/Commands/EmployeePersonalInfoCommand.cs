namespace Exercise.Core.Commands
{
    using Exercise.Core.Commands.Contracts;
    using Exercise.Core.Models;
    using Exercise.IO;
    using Exercise.Services.Contracts;
    using System;

    public class EmployeePersonalInfoCommand : ICommand
    {
        private IEmployeeService employeeService;

        public EmployeePersonalInfoCommand(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public string Execute(params string[] args)
        {
            int employeeId = int.Parse(args[0]);

            EmployeePersonalInfoDto employeePersonalInfoDto = this.employeeService.EmployeeInfo<EmployeePersonalInfoDto>(employeeId);

            return string.Format(Constants.EmployeePersonalInfo,
                employeePersonalInfoDto.Id,
                employeePersonalInfoDto.FirstName,
                employeePersonalInfoDto.LastName,
                employeePersonalInfoDto.Salary,
                Environment.NewLine,
                employeePersonalInfoDto.Birthday == DateTime.MinValue ? "Employee birthday is yet to be set." : employeePersonalInfoDto.Birthday.ToShortDateString(),
                Environment.NewLine,
                employeePersonalInfoDto.Address == null ? "Employee address is yet to be set." : employeePersonalInfoDto.Address);
        }
    }
}
