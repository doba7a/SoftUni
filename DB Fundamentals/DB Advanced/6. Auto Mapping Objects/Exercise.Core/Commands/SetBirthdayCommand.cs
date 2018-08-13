namespace Exercise.Core.Commands
{
    using Exercise.Core.Commands.Contracts;
    using Exercise.Core.Models;
    using Exercise.IO;
    using Exercise.Services.Contracts;

    public class SetBirthdayCommand : ICommand
    {
        private IEmployeeService employeeService;

        public SetBirthdayCommand(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public string Execute(params string[] args)
        {
            int employeeId = int.Parse(args[0]);
            string date = args[1];

            EmployeeDto employeeDto = this.employeeService.SetBirthday<EmployeeDto>(employeeId, date);

            return string.Format(Constants.EmployeeBirthdaySet,
                employeeId,
                date);
        }
    }
}
