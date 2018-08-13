namespace Exercise.Core.Commands
{
    using Exercise.Core.Commands.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    public class HelpCommand : ICommand
    {
        public string Execute(params string[] args)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Example: CommandName Param1 Param2...")
                .AppendLine("AddEmployee fistName(string value) lastName(string value) salary(floating-point number)")
                .AppendLine("SetBirthday employeeId(int value) date(string value in format \"dd-MM-yyyy\")")
                .AppendLine("SetAddress employeeId(int value) address(string value)")
                .AppendLine("EmployeeInfo employeeId(int value)")
                .AppendLine("EmployeePersonalInfo employeeId(int value)")
                .AppendLine("DeleteEmployee employeeId(int value)")
                .AppendLine("SetManager employeeId(int value) managerId(int value)")
                .AppendLine("ManagerInfo managerId(int value)")
                .AppendLine("ListEmployeesOlderThanAge age(int value)")
                .AppendLine("Exit");

            return sb.ToString().TrimEnd();
        }
    }
}
