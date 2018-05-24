using System;
using System.Collections.Generic;

public class Manager : Employee
{
    public Manager(string name, ICollection<string> documents) 
        : base(name)
    {
        this.Documents = new List<string>(documents);
    }

    public IReadOnlyCollection<string> Documents { get; set; }

    public override string ToString()
    {
        string result = base.ToString();

        if (this.Documents.Count > 0)
        {
            result += $"{Environment.NewLine}DOCUMENTS:{Environment.NewLine}{string.Join($"{Environment.NewLine}", this.Documents)}";
        }

        return result;
    }
}

