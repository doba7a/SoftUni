using System;

public class Box<T> : IComparable<T>
    where T : IComparable<T>
{
    private T value;

    public Box(T element)
    {
        this.value = element;
    }

    public int CompareTo(T other)
    {
        return this.value.CompareTo(other);
    }
}
