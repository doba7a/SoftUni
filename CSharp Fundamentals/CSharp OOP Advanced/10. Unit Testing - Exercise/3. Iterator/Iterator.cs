using System;
using System.Collections;
using System.Collections.Generic;

public class Iterator : IEnumerable
{
    private readonly List<string> elements;
    private int internalIndex = 0;

    public Iterator(IEnumerable<string> collection)
    {
        this.elements = ValidateInput(collection);
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

    public string Print()
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

    private List<string> ValidateInput(IEnumerable<string> collection)
    {
        if (collection ==  null)
        {
            throw new ArgumentNullException();
        }

        foreach (string element in collection)
        {
            if (element == null)
            {
                throw new ArgumentNullException(element, "Elements cannot be null.");
            }
        }

        return new List<string>(collection);
    }

    public IEnumerator GetEnumerator()
    {
        for (int i = 0; i < this.elements.Count; i++)
        {
            yield return this.elements[i];
        }
    }
}


