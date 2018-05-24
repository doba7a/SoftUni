using System;
using Logger.Enums;
using Logger.Models.Errors.Contracts;

namespace Logger.Models.Errors
{
    class Error : IError
    {
        public Error(DateTime date, ErrorLevel errorLevel, string message)
        {
            this.Date = date;
            this.ErrorLevel = errorLevel;
            this.Message = message;
        }
        
        public DateTime Date { get; }

        public ErrorLevel ErrorLevel { get; }

        public string Message { get; }
    }
}
