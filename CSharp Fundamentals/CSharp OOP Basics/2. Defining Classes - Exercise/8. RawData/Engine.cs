public class Engine
{
    private int speed;
    private int power;

    public Engine(int speedGiven, int powerGiven)
    {
        this.Speed = speedGiven;
        this.Power = powerGiven;
    }

    public int Speed { get => speed; set => speed = value; }
    public int Power { get => power; set => power = value; }
}

