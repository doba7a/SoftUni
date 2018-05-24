using System.Collections;
using System.Collections.Generic;

public class Stack<T> : IEnumerable<T>
{
    private readonly List<T> elements;

    public Stack()
    {
        this.elements = new List<T>();
    }

    public void Push(T[] elementsToAdd)
    {
        foreach (T element in elementsToAdd)
        {
            this.elements.Insert(0, element);
        }
    }

    public void Pop()
    {
        this.elements.RemoveAt(0);
    }

    public bool ExistingElementToPop => this.elements.Count > 0 ? true : false;

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

