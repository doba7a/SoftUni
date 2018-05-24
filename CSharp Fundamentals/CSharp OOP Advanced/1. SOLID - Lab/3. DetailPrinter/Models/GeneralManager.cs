using System;
using System.Collections.Generic;

public class GeneralManager : Employee
{
    public GeneralManager(string name, ICollection<string> managersUnderCommand)
        : base(name)
    {
        this.ManagersUnderCommand = new List<string>(managersUnderCommand);
    }

    public IReadOnlyCollection<string> ManagersUnderCommand { get; set; }

    public override string ToString()
    {
        string result = base.ToString();

        if (this.ManagersUnderCommand.Count > 0)
        {
            result += $"{Environment.NewLine}MANAGERS UNDER COMMAND:{Environment.NewLine}{string.Join(Environment.NewLine, this.ManagersUnderCommand)}";
        }

        return result;
    }
}

