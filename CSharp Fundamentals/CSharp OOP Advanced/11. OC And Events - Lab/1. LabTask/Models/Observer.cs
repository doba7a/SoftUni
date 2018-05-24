public class Observer : IObserver
{
    private IAttacker attacker;

    public Observer(IAttacker attacker)
    {
        this.attacker = attacker;
    }

    public void Update(int value)
    {
        this.attacker.Update(value);
    }
}