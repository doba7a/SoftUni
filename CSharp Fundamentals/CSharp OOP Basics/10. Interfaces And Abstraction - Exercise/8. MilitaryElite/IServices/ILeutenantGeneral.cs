using System;
using System.Collections.Generic;
using System.Text;

public interface ILeutenantGeneral : IPrivate
{
    ICollection<IPrivate> Privates { get; }

    void AddPrivate(IPrivate inputPrivate);
}

