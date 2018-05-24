using Logger.Enums;
using Logger.Models.Errors.Contracts;
using Logger.Models.Layouts.Contracts;

namespace Logger.Models.Appenders.Contracts
{
    public interface IAppender
    {
        ILayout Layout { get; }

        ErrorLevel ErrorLevel { get; }

        void Append(IError error);
    }
}
