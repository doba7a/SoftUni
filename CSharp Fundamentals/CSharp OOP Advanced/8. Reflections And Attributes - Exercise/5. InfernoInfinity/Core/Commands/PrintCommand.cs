using System;
using System.Linq;

public class PrintCommand : Command
{
    [Inject]
    private IRepository repository;

    public PrintCommand(string[] data, IRepository repository)
        : base(data)
    {
        this.repository = repository;
    }

    public IRepository Repository { get => repository; private set => repository = value; }

    public override void Execute()
    {
        string weaponName = this.Data[0];

        if (!this.Repository.Weapons.Any(w => w.Name == weaponName))
        {
            return;
        }

        IWeapon existingWeapon = this.Repository.Weapons.First(w => w.Name == weaponName);

        this.Repository.Print(existingWeapon);
    }
}

