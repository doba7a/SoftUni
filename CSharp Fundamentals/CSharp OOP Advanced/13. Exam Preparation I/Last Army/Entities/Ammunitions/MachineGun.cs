public class MachineGun : Ammunition
{
    public const double WEIGHT = 10.6;
    public const string NAME = nameof(MachineGun);

    public MachineGun()
        : base(NAME, WEIGHT)
    {
    }
}
