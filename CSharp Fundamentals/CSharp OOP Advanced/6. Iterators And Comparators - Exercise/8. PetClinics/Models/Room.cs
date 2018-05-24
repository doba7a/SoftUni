public class Room : IRoom
{
    private Pet pet;

    public Room()
    {
    }

    public Pet Pet { get => pet; private set => pet = value; }

    public bool HasAnimal() => this.Pet != null ? true : false;

    public void AddPet(Pet pet)
    {
        this.pet = pet;
    }

    public Pet ReleasePet()
    {
        Pet releasedPet = this.pet;

        this.pet = null;

        return releasedPet;
    }

    public override string ToString()
    {
        if (this.pet != null)
        {
            return this.pet.ToString();
        }

        return "Room empty";
    }
}

