using Logger.Enums;
using System;

namespace Logger.Models.Errors.Contracts
{
    public interface IError
    {
        DateTime Date { get; }

        ErrorLevel ErrorLevel { get; }

        string Message { get; }
    }
}
