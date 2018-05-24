using System.Collections.Generic;
using System.Linq;

public class Box<T> : IBox<T>
{
    private readonly List<T> elements;

    public Box()
    {
        this.elements = new List<T>();
    }

    public int Count => this.elements.Count;

    public void Add(T element)
    {
        this.elements.Add(element);
    }

    public T Remove()
    {
        T element = this.elements.Last();

        this.elements.RemoveAt(this.elements.Count - 1);

        return element;
    }
}

