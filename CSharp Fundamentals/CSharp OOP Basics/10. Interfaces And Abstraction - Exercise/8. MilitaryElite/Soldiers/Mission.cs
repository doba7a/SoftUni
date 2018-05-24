using System;
using System.Collections.Generic;
using System.Text;

public class Mission : IMission
{
    public Mission(string codeName, string state)
    {
        this.CodeName = codeName;
        this.State = Enum.Parse<State>(state);
    }
    public string CodeName { get; private set; }

    public State State { get; private set; }

    public override string ToString()
    {
        return $"Code Name: {CodeName} State: {State}";
    }
}

