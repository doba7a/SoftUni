using System;
using System.Collections.Generic;
using System.Text;

public interface IMyList : IAddRemoveCollection
{
    string RemoveFirst();

    string Used();
}

