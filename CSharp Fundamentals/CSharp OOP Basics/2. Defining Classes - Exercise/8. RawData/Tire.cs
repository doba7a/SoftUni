public class Tire
{
    private double pressure;
    private int age;

    public Tire(double pressureGiven, int ageGiven)
    {
        this.Pressure = pressureGiven;
        this.Age = ageGiven;
    }

    public double Pressure { get => pressure; set => pressure = value; }
    public int Age { get => age; set => age = value; }
}

