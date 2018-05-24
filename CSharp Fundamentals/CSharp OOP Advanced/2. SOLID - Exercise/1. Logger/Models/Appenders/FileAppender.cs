using Logger.Enums;
using Logger.Models.Appenders.Contracts;
using Logger.Models.Errors.Contracts;
using Logger.Models.Layouts.Contracts;
using Logger.Models.LogFiles.Contracts;
using System.Text;

namespace Logger.Models.Appenders
{
    class FileAppender : IAppender
    {
        private ILogFile logFile;
        private int messagesAppended;

        public FileAppender(ILayout layout, ErrorLevel errorLevel, ILogFile logFile)
        {
            this.Layout = layout;
            this.ErrorLevel = errorLevel;
            this.logFile = logFile;
            this.messagesAppended = 0;
        }

        public ILayout Layout { get; }

        public ErrorLevel ErrorLevel { get; }

        public void Append(IError error)
        {
            string formattedError = this.Layout.FormatError(error);

            this.logFile.WriteToFile(formattedError);

            this.messagesAppended++;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {this.ErrorLevel.ToString()}, Messages appended: {this.messagesAppended}, , File size: {this.logFile.Size}");

            return sb.ToString().TrimEnd();
        }
    }
}
