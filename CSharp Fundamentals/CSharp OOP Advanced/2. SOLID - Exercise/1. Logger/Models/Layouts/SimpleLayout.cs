using Logger.Models.Errors.Contracts;
using Logger.Models.Layouts.Contracts;

using System.Globalization;

namespace Logger.Models.Layouts
{
    public class SimpleLayout : ILayout
    {
        const string format = "{0} - {1} - {2}";
        const string dateFormat = "M/d/yyyy h:mm:ss tt";

        public string FormatError(IError error)
        {
            string dateString = error.Date.ToString(dateFormat, CultureInfo.InvariantCulture);

            string formattedError = string.Format(format,
                dateString, error.ErrorLevel.ToString(), error.Message);

            return formattedError;
        }
    }
}
