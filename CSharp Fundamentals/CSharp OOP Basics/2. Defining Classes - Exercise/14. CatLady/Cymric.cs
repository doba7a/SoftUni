public class Cymric : Cat
{
    private double furLength;

    public Cymric(string breed, string name, double furLength) : base(breed, name)
    {
        this.FurLength = furLength;
    }

    public double FurLength { get => furLength; set => furLength = value; }

    public override string ToString()
    {
        return $"{base.ToString()} {this.FurLength:f2}";
    }
}