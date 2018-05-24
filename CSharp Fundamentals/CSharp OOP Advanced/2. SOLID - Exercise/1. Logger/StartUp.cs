using Logger.Controllers;
using Logger.Models.Appenders.Contracts;
using Logger.Models.Appenders.Factory;
using Logger.Models.Layouts.Factory;
using Logger.Models.Loggers;
using Logger.Models.Loggers.Contracts;

using System;
using System.Text;
using System.Collections.Generic;

namespace Logger
{
    public class StartUp
    {
        public static void Main()
        {
            GreetingMessage();

            ILogger logger = InitializeLogger();

            Engine engine = new Engine(logger);

            engine.Run();
        }

        private static ILogger InitializeLogger()
        {
            ICollection<IAppender> appenders = new List<IAppender>();

            LayoutFactory layoutFactory = new LayoutFactory();
            AppenderFactory appenderFactory = new AppenderFactory(layoutFactory);

            Console.Write("Enter appenders count: ");
            int appenderCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < appenderCount; i++)
            {
                Console.WriteLine("Enter appender data in the format described above.");
                string[] inputData = Console.ReadLine().Split();

                string appenderType = inputData[0];
                string layoutType = inputData[1];
                string errorLevel = inputData.Length == 3 ? inputData[2] : "INFO";

                IAppender appender = appenderFactory.CreateAppender(appenderType, errorLevel, layoutType);

                appenders.Add(appender);
                Console.WriteLine("Appender added!");
            }

            ILogger logger = new MainLogger(appenders);

            return logger;
        }

        private static void GreetingMessage()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Greetings!")
                .AppendLine("Please note that when you enter some data it MUST be in the format described, otherwise exceptions will hunt you down and make you write on PHP for the rest of your life.")
                .AppendLine()
                .AppendLine("Appenders MUST be in the following format: <AppenderType> <LayoutType> <REPORTLEVEL>.")
                .AppendLine("<AppenderType> is mandatory and can be ConsoleAppender or FileAppender")
                .AppendLine("<LayoutType> is mandatory and can be SimpleLayout or XmlLayout")
                .AppendLine("<REPORT LEVEL> can be INFO, WARNING, ERROR, CRITICAL or FATAL")
                .AppendLine("Note that <REPORT LEVEL> is not mandatory, by default it will be INFO")
                .AppendLine()
                .AppendLine("Errors MUST be in the following format: <REPORTLEVEL>|<time>|<message>")
                .AppendLine("<REPORT LEVEL> is mandatory and can be INFO, WARNING, ERROR, CRITICAL or FATAL")
                .AppendLine("<time> is mandatory and MUST be in the following format: M/d/yyyy h:mm:ss tt")
                .AppendLine("<message> is mandatory and is normal string");

            Console.WriteLine(sb.ToString());
        }
    }
}
