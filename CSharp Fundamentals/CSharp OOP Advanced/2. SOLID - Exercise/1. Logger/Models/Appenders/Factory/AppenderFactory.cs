using Logger.Enums;
using Logger.Models.Appenders.Contracts;
using Logger.Models.Layouts.Contracts;
using Logger.Models.Layouts.Factory;
using Logger.Models.LogFiles;
using Logger.Models.LogFiles.Contracts;
using System;

namespace Logger.Models.Appenders.Factory
{
    public class AppenderFactory
    {
        private const string defaultFileName = "LogFile{0}.txt";

        private LayoutFactory layoutFactory;
        private int fileNumber;

        public AppenderFactory(LayoutFactory layoutFactory)
        {
            this.layoutFactory = layoutFactory;
            this.fileNumber = 1;
        }

        public IAppender CreateAppender(string appenderType, string errorLevelAsString, string layoutType)
        {
            ILayout layout = this.layoutFactory.CreateLayout(layoutType);
            ErrorLevel errorLevel = this.ParseErrorLevel(errorLevelAsString);
            IAppender appender = null;

            switch (appenderType)
            {
                case "ConsoleAppender":
                    appender = new ConsoleAppender(layout, errorLevel);
                    break;
                case "FileAppender":
                    ILogFile file = new LogFile(string.Format(defaultFileName, this.fileNumber++));
                    appender = new FileAppender(layout, errorLevel, file);
                    break;
                default:
                    throw new ArgumentException("Invalid appender type!");
            }

            return appender;
        }

        private ErrorLevel ParseErrorLevel(string errorLevelAsString)
        {
            try
            {
                object levelObj = Enum.Parse(typeof(ErrorLevel), errorLevelAsString);

                return (ErrorLevel)levelObj;
            }
            catch (ArgumentException ae)
            {
                throw new ArgumentException("Invalid ErrorLevel Type" + ae);
            }
        }
    }
}
