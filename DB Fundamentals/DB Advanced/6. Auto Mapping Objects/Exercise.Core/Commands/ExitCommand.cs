namespace Exercise.Core.Commands
{
    using Exercise.Core.Commands.Contracts;
    using Exercise.Services.Contracts;
    using System;

    public class ExitCommand : ICommand
    {
        private IEmployeeService employeeService;
        private IWriter writer;

        public ExitCommand(IEmployeeService employeeService, IWriter writer)
        {
            this.employeeService = employeeService;
            this.writer = writer;
        }

        public string Execute(params string[] args)
        {
            this.writer.WriteLine("See ya!");

            Environment.Exit(0);

            return string.Empty;
        }
    }
}
