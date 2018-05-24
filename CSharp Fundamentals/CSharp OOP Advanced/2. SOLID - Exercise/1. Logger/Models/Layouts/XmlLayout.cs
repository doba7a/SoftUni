using Logger.Models.Errors.Contracts;
using Logger.Models.Layouts.Contracts;
using System;
using System.Globalization;

namespace Logger.Models.Layouts
{
    class XmlLayout : ILayout
    {
        const string format = "<log>{0}<date>{1}</date>{0}<level>{2}</level>{0}<message>{3}</message>{0}</log>";
        const string dateFormat = "M/d/yyyy h:mm:ss tt";

        public string FormatError(IError error)
        {
            string dateString = error.Date.ToString(dateFormat, CultureInfo.InvariantCulture);

            string formattedError = string.Format(format,
                Environment.NewLine, dateString, error.ErrorLevel.ToString(), error.Message);

            return formattedError;
        }
    }
}
