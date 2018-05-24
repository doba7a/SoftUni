using System.Linq;

public class RemoveCommand : Command
{
    [Inject]
    private IRepository repository;

    public RemoveCommand(string[] data, IRepository repository)
        :base(data)
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

        int socketIndex = int.Parse(this.Data[1]);

        if (socketIndex < 0 || socketIndex > existingWeapon.Gems.Length || existingWeapon.Gems[socketIndex] == null)
        {
            return;
        }

        this.Repository.Remove(existingWeapon, socketIndex);
    }
}

