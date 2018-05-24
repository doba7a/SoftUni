using System;
using System.Collections.Generic;
using System.Text;

public class LeutenantGeneral : Private, ILeutenantGeneral
{
    public LeutenantGeneral(int id, string firstName, string lastName, double salary)
        : base(id, firstName, lastName, salary)
    {
        this.Privates = new List<IPrivate>();
    }

    public ICollection<IPrivate> Privates { get; set; }

    public void AddPrivate(IPrivate inputPrivate)
    {
        Privates.Add(inputPrivate);
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"{base.ToString()}");
        sb.AppendLine("Privates:");
        sb.AppendLine($"{String.Join("\n", Privates)}");
        return sb.ToString().TrimEnd();
    }
}

