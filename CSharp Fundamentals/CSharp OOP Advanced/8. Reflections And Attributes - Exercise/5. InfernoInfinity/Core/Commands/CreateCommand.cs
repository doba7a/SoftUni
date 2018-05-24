using System;

public class CreateCommand : Command
{
    [Inject]
    private IWeaponFactory weaponFactory;
    [Inject]
    private IRepository repository;

    public CreateCommand(string[] data, IWeaponFactory weaponFactory, IRepository repository)
        :base(data)
    {
        this.WeaponFactory = weaponFactory;
        this.Repository = repository;
    }

    public IWeaponFactory WeaponFactory { get => weaponFactory; private set => weaponFactory = value; }
    public IRepository Repository { get => repository; private set => repository = value; }

    public override void Execute()
    {
        string weaponRarityAsString = this.Data[0].Split(' ')[0];
        Rarity weaponRarity;

        if (!Enum.TryParse(weaponRarityAsString, out weaponRarity))
        {
            return;
        }

        string weaponTypeAsString = this.Data[0].Split(' ')[1];
        string weaponName = this.Data[1];

        IWeapon currentWeapon = this.WeaponFactory.CreateWeapon(weaponRarity, weaponTypeAsString, weaponName);

        if (currentWeapon == null)
        {
            return;
        }

        this.Repository.Create(currentWeapon);
    }
}

