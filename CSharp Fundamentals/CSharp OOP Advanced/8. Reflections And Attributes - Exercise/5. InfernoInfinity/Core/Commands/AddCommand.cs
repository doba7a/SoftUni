using System;
using System.Linq;

public class AddCommand : Command
{
    [Inject]
    private IRepository repository;
    [Inject]
    private IGemFactory gemFactory;

    public AddCommand(string[] data, IRepository repository, IGemFactory gemFactory)
        : base(data)
    {
        this.GemFactory = gemFactory;
        this.Repository = repository;
    }

    public IRepository Repository { get => repository; private set => repository = value; }
    public IGemFactory GemFactory { get => gemFactory; private set => gemFactory = value; }

    public override void Execute()
    {
        string weaponName = this.Data[0];

        if (!this.Repository.Weapons.Any(w => w.Name == weaponName))
        {
            return;
        }

        IWeapon existingWeapon = this.Repository.Weapons.First(w => w.Name == weaponName);

        int socketIndex = int.Parse(this.Data[1]);

        if (socketIndex < 0 || socketIndex > existingWeapon.Gems.Length)
        {
            return;
        }

        string gemClarityAsString = this.Data[2].Split(' ')[0];
        Clarity gemClarity;

        if (!Enum.TryParse(gemClarityAsString, out gemClarity))
        {
            return;
        }

        string gemKindAsString = this.Data[2].Split(' ')[1];

        IGem currentGem = this.GemFactory.CreateGem(gemClarity, gemKindAsString);

        if (currentGem == null)
        {
            return;
        }

        this.Repository.Add(existingWeapon, currentGem, socketIndex);
    }
}

