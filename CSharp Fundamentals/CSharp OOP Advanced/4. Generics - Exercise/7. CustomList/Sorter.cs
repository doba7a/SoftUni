using System;

public class Sorter
{
    public Sorter()
    {
    }


    public static void Sort<T>(T[] elements) where T : IComparable<T>
    {
        T temp;

        for (int write = 0; write < elements.Length; write++)
        {
            for (int sort = 0; sort < elements.Length - 1; sort++)
            {
                if (elements[sort].CompareTo(elements[sort + 1]) > 0)
                {
                    temp = elements[sort + 1];
                    elements[sort + 1] = elements[sort];
                    elements[sort] = temp;
                }
            }
        }
    }
}

