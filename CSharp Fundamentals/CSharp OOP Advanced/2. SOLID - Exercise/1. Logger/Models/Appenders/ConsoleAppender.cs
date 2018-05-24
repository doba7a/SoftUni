using System;
using System.Text;
using Logger.Enums;
using Logger.Models.Appenders.Contracts;
using Logger.Models.Errors.Contracts;
using Logger.Models.Layouts.Contracts;

namespace Logger.Models.Appenders
{
    class ConsoleAppender : IAppender
    {
        private int messagesAppended;

        public ConsoleAppender(ILayout layout, ErrorLevel errorLevel)
        {
            this.Layout = layout;
            this.ErrorLevel = errorLevel;
            this.messagesAppended = 0;
        }

        public ILayout Layout { get; }
        public ErrorLevel ErrorLevel { get; }

        public void Append(IError error)
        {
            string formattedError = this.Layout.FormatError(error);

            Console.WriteLine(formattedError);

            this.messagesAppended++;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {this.ErrorLevel.ToString()}, Messages appended: {this.messagesAppended}");

            return sb.ToString().TrimEnd();
        }
    }
}
