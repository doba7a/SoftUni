public interface IIterator<T>
{
    bool Move();

    T Print();

    bool HasNext();
}

