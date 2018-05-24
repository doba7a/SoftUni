using Logger.Models.Appenders.Contracts;
using Logger.Models.Errors.Contracts;
using Logger.Models.Loggers.Contracts;
using System.Collections.Generic;

namespace Logger.Models.Loggers
{
    public class MainLogger : ILogger
    {
        private IEnumerable<IAppender> appenders;

        public MainLogger(IEnumerable<IAppender> appenders)
        {
            this.appenders = appenders;
        }

        public IReadOnlyCollection<IAppender> Appenders => (IReadOnlyCollection<IAppender>)this.appenders;

        public void Log(IError error)
        {
            foreach (IAppender appender in this.appenders)
            {
                if (appender.ErrorLevel <= error.ErrorLevel)
                {
                    appender.Append(error);
                }
            }
        }
    }
}
