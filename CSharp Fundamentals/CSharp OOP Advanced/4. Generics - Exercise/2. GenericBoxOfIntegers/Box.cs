public class Box<T>
{
    private T value;

    public Box(T element)
    {
        this.value = element;
    }

    public override string ToString()
    {
        return $"{this.value.GetType().FullName}: {this.value}";
    }
}


