using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class ListyIterator<T> : IEnumerable<T>
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

    public string PrintAll()
    {
        StringBuilder sb = new StringBuilder();

        foreach (T element in this.elements)
        {
            sb.Append($"{element} ");
        }

        return sb.ToString().TrimEnd();
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < this.elements.Count; i++)
        {
            yield return elements[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}

