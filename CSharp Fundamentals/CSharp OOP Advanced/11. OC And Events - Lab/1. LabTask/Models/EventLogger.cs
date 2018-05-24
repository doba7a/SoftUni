using System;

public class EventLogger : Logger
{
    public override void Handle(LogType logType, string message)
    {
        switch (logType)
        {
            case LogType.TARGET:
                Console.WriteLine(logType.ToString() + ": " + message);
                break;
            case LogType.ERROR:
                Console.WriteLine(logType.ToString() + ": " + message);
                break;
            case LogType.EVENT:
                Console.WriteLine(logType.ToString() + ": " + message);
                break;
            default:
                break;
        }

        this.PassToSuccessor(logType, message);
    }
}

