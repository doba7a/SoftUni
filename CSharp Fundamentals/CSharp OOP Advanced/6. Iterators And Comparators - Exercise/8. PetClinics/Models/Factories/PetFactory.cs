public class PetFactory
{
    public Pet CreatePet(string name, int age, string kind)
    {
        return new Pet(name, age, kind);
    }
}

