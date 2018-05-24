using Logger.Enums;
using Logger.Models.Errors.Contracts;
using System;
using System.Globalization;

namespace Logger.Models.Errors.Factory
{
    public class ErrorFactory
    {
        const string dateFormat = "M/d/yyyy h:mm:ss tt";

        public IError CreateError(string dateAsString, string errorLevelAsString, string message)
        {
            DateTime dateTime = DateTime.ParseExact(dateAsString, dateFormat, CultureInfo.InvariantCulture);
            ErrorLevel errorLevel = this.ParseErrorLevel(errorLevelAsString);

            IError error = new Error(dateTime, errorLevel, message);

            return error;
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
