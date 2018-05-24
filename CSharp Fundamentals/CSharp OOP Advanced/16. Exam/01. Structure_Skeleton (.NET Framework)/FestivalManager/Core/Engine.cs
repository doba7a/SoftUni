using System;
using System.Linq;

namespace FestivalManager.Core
{
    using System.Reflection;
    using Contracts;
    using Controllers.Contracts;
    using IO.Contracts;

    class Engine : IEngine
    {
        private const string EndCommand = "END";

        private IReader reader;
        private IWriter writer;
        private IFestivalController festivalCоntroller;
        private ISetController setCоntroller;

        public Engine(IReader reader, IWriter writer, IFestivalController festivalCоntroller, ISetController setCоntroller)
        {
            this.reader = reader;
            this.writer = writer;
            this.festivalCоntroller = festivalCоntroller;
            this.setCоntroller = setCоntroller;
        }

        public void Run()
        {
            while (true)
            {
                string input = reader.ReadLine();

                if (input == EndCommand)
                {
                    break;
                }

                try
                {
                    var result = this.ProcessCommand(input);
                    this.writer.WriteLine(result);
                }
                catch (Exception ex)
                {
                    this.writer.WriteLine("ERROR: " + ex.InnerException.Message);
                }
            }

            string end = this.festivalCоntroller.ProduceReport();

            this.writer.WriteLine("Results:");
            this.writer.WriteLine(end);
        }

        public string ProcessCommand(string input)
        {
            string commandOutput = "";

            string[] inputData = input.Split(' ');
            string command = inputData[0];

            if (command == "LetsRock")
            {
                commandOutput = this.setCоntroller.PerformSets();
            }
            else
            {
                MethodInfo festivalcontrolfunction = this.festivalCоntroller.GetType()
                   .GetMethods()
                   .FirstOrDefault(x => x.Name == command);

                string[] args = inputData.Skip(1).ToArray();

                commandOutput = (string)festivalcontrolfunction.Invoke(this.festivalCоntroller,new object[] { args });
            }

            return commandOutput;
        }
    }
}