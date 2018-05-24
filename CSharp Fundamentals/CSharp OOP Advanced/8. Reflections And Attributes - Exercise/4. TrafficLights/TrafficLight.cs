using System;

public class TrafficLight
{
    private TrafficLightEnum lightSignal;

    public TrafficLight(string lightSignal)
    {
        this.LightSignal = Enum.Parse<TrafficLightEnum>(lightSignal);
    }

    public TrafficLightEnum LightSignal { get => lightSignal; private set => lightSignal = value; }

    public void ChangeLight()
    {
        this.LightSignal++;

        this.LightSignal = (int)this.LightSignal > 2 ? 0 : this.LightSignal;
    }

    public override string ToString()
    {
        return $"{this.LightSignal}";
    }
}

