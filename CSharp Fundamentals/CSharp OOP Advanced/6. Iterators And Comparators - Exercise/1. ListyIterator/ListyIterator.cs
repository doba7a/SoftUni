using System;
using System.Collections.Generic;

public class ListyIterator<T>
{
    private readonly List<T> elements;
    private int internalIndex = 0;

    public ListyIterator(IEnumerable<T> collection)
    {
        this.elements = new List<T>(collection);
    }

    public ListyIterator()
    {
        this.elements = new List<T>();
    }

    public bool Move()
    {
        if (HasNext())
        {
            internalIndex++;
            return true;
        }
        else
        {
            return false;
        }
    }

    public T Print()
    {
        if (this.elements.Count == 0)
        {
            throw new InvalidOperationException("Invalid Operation!");
        }

        return this.elements[internalIndex];
    }

    public bool HasNext()
    {
        if (this.elements.Count > internalIndex + 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

