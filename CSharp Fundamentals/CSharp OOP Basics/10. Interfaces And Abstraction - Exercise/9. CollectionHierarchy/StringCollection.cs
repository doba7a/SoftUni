using System;
using System.Collections.Generic;

public class StringCollection : IMyList
{
    private static List<string> myCollection = new List<string>();

    public int Count { get; private set; }
    private int SecondCounter = 0;

    public int Add(string element)
    {
        myCollection.Add(element);
        this.Count++;
        return myCollection.Count - 1;
    }

    public string RemoveFirst()
    {

        string item = myCollection[myCollection.Count - SecondCounter - 1];
        SecondCounter++;
        return item;
    }

    public string RemoveLast()
    {
        if (this.Count - 1 == -1)
        {
            this.Count = 0;
        }
        else
        {
            this.Count--;
        }

        string item = myCollection[myCollection.Count - this.Count - 1];
        return item;
    }

    public string Used()
    {
        return String.Join(" ",myCollection);
    }
}

