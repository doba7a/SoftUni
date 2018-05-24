public interface IRoom
{
    Pet Pet { get; }

    bool HasAnimal();

    void AddPet(Pet pet);

    Pet ReleasePet();
}

