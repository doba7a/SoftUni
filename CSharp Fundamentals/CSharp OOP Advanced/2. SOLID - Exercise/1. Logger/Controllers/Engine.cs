using Logger.Models.Appenders.Contracts;
using Logger.Models.Errors.Contracts;
using Logger.Models.Errors.Factory;
using Logger.Models.Loggers.Contracts;
using System;

namespace Logger.Controllers
{
    public class Engine
    {
        private ILogger logger;
        private ErrorFactory errorFactory;

        public Engine(ILogger logger)
        {
            this.logger = logger;
            this.errorFactory = new ErrorFactory();
        }

        public void Run()
        {
            Console.WriteLine("Enter error data in the format described or type END to terminate the program");
            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] inputData = input.Split('|');

                string errorLevel = inputData[0];
                string date = inputData[1];
                string message = inputData[2];

                IError error = errorFactory.CreateError(date, errorLevel, message);

                logger.Log(error);

                Console.WriteLine("Enter error data in the format described or type END to terminate the program");
                input = Console.ReadLine();
            }

            Console.WriteLine("Logger info");
            foreach (IAppender appender in this.logger.Appenders)
            {
                Console.WriteLine(appender.ToString());
            }
        }
    }
}
