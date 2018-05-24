using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class CustomList<T> : IEnumerable<T> where T : IComparable<T>
{
    private const int DEFAULT_CAPACITY = 0;

    private T[] elements;

    public CustomList()
    {
        this.elements = new T[DEFAULT_CAPACITY];
    }

    public void Add(T item)
    {
        T[] tempArray = new T[this.elements.Length + 1];

        for (int i = 0; i < this.elements.Length; i++)
        {
            tempArray[i] = this.elements[i];
        }

        this.elements = tempArray;

        this.elements[this.elements.Length - 1] = item;
    }

    public T Remove(int index)
    {
        T[] tempArray = new T[this.elements.Length - 1];

        for (int i = 0; i < index; i++)
        {
            tempArray[i] = this.elements[i];
        }
        for (int i = index + 1; i < this.elements.Length; i++)
        {
            tempArray[i - 1] = this.elements[i];
        }

        T elementToReturn = this.elements[index];
        this.elements = tempArray;

        return elementToReturn;
    }

    public bool Contains(T element)
    {
        for (int i = 0; i < this.elements.Length; i++)
        {
            if (this.elements[i].Equals(element))
            {
                return true;
            }
        }

        return false;
    }

    public void Swap(int index1, int index2)
    {
        T tempElement = this.elements[index1];

        this.elements[index1] = this.elements[index2];

        this.elements[index2] = tempElement;
    }

    public int CountGreaterThan(T element)
    {
        int count = 0;

        for (int i = 0; i < this.elements.Length; i++)
        {
            if (element.CompareTo(this.elements[i]) < 0)
            {
                count++;
            }
        }

        return count;
    }

    public T Max()
    {
        T maxElement = this.elements[0];

        for (int i = 1; i < this.elements.Length; i++)
        {
            if (maxElement.CompareTo(this.elements[i]) < 0)
            {
                maxElement = this.elements[i];
            }
        }

        return maxElement;
    }

    public T Min()
    {
        T minElement = this.elements[0];

        for (int i = 1; i < this.elements.Length; i++)
        {
            if (minElement.CompareTo(this.elements[i]) > 0)
            {
                minElement = this.elements[i];
            }
        }

        return minElement;
    }


    public string Print()
    {
        StringBuilder sb = new StringBuilder();

        foreach (var element in this.elements)
        {
            sb.AppendLine(element.ToString());
        }

        return sb.ToString().Trim();
    }

    public void Sort()
    {
        Sorter.Sort(this.elements);
    }

    public IEnumerator<T> GetEnumerator()
    {
        return GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

