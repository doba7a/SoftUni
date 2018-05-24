using Logger.Models.Appenders.Contracts;
using Logger.Models.Errors.Contracts;

using System.Collections.Generic;

namespace Logger.Models.Loggers.Contracts
{
    public interface ILogger
    {
        IReadOnlyCollection<IAppender> Appenders { get; }

        void Log(IError error);
    }
}
