using System.Collections.Generic;
using System.Linq;

public class PetClinicsController
{
    private readonly List<Clinic> clinics;
    private readonly List<Pet> petsWaiting;
    private PetFactory petFactory;
    private ClinicFactory clinicFactory;

    public PetClinicsController()
    {
        this.clinics = new List<Clinic>();
        this.petsWaiting = new List<Pet>();
        this.petFactory = new PetFactory();
        this.clinicFactory = new ClinicFactory();
    }

    public void Create(string[] args)
    {
        string clinicOrPet = args[0];

        switch (clinicOrPet)
        {
            case "Clinic":
                string clinicName = args[1];
                int numberOfRooms = int.Parse(args[2]);
                Clinic currentClinic = this.clinicFactory.CreateClinic(clinicName, numberOfRooms);
                this.clinics.Add(currentClinic);
                break;
            case "Pet":
                string petName = args[1];
                int age = int.Parse(args[2]);
                string petKind = args[3];
                Pet currentPet = this.petFactory.CreatePet(petName, age, petKind);
                this.petsWaiting.Add(currentPet);
                break;
        }
    }

    public bool Add(string[] args)
    {
        string petName = args[0];
        string clinicName = args[1];

        if (!this.petsWaiting.Any(p => p.Name == petName) || !this.clinics.Any(c => c.Name == clinicName))
        {
            return false;
        }

        Clinic existingClinic = this.clinics.First(c => c.Name == clinicName);
        int roomIndex = FindEmptyRoomIndex(existingClinic);

        if (roomIndex == -1)
        {
            return false;
        }

        Pet existingPet = this.petsWaiting.First(p => p.Name == petName);
        this.petsWaiting.Remove(existingPet);
        existingClinic.Rooms[roomIndex].AddPet(existingPet);

        return true;
    }
    
    private int FindEmptyRoomIndex(Clinic existingClinic)
    {
        int index = -1;

        int tempIndex = existingClinic.Rooms.Length / 2;
        int counter = 1;
        bool moveLeft = true;

        while (tempIndex >= 0 && tempIndex < existingClinic.Rooms.Length)
        {
            if (existingClinic.Rooms[tempIndex].HasAnimal())
            {
                if (moveLeft)
                {
                    tempIndex -= counter++;
                    moveLeft = false;
                }
                else
                {
                    tempIndex += counter++;
                    moveLeft = true;
                }
            }
            else
            {
                index = tempIndex;
                break;
            }
        }

        return index;
    }

    public bool Release(string[] args)
    {
        string clinicName = args[0];

        if (!this.clinics.Any(c => c.Name == clinicName))
        {
            return false;
        }

        Clinic existingClinic = this.clinics.First(c => c.Name == clinicName);
        int petRoomIndex = PetRoomIndexToRelease(existingClinic);

        if (petRoomIndex == -1)
        {
            return false;
        }

        Pet releasedPet = existingClinic.Rooms[petRoomIndex].ReleasePet();
        this.petsWaiting.Add(releasedPet);

        return true;
    }

    private int PetRoomIndexToRelease(Clinic existingClinic)
    {
        int index = -1;

        int tempIndex = existingClinic.Rooms.Length / 2;

        while (tempIndex < existingClinic.Rooms.Length)
        {
            if (existingClinic.Rooms[tempIndex].HasAnimal())
            {
                index = tempIndex;
                return index;
            }
            tempIndex++;
        }

        tempIndex = 0;

        while (tempIndex < existingClinic.Rooms.Length / 2)
        {
            if (existingClinic.Rooms[tempIndex].HasAnimal())
            {
                index = tempIndex;
                return index;
            }
            tempIndex++;
        }

        return index;
    }

    public bool HasEmptyRooms(string[] args)
    {
        string clinicName = args[0];

        if (!this.clinics.Any(c => c.Name == clinicName))
        {
            return false;
        }

        Clinic existingClinic = this.clinics.First(c => c.Name == clinicName);

        if (!existingClinic.Rooms.Any(r => r.HasAnimal()))
        {
            return true;
        }

        return false;
    }

    public string Print(string[] args)
    {
        if (args.Length == 1)
        {
            string clinicName = args[0];
            Clinic existingClinic = this.clinics.First(c => c.Name == clinicName);

            return existingClinic.ToString();
        }
        else
        {
            string clinicName = args[0];
            int roomIndex = int.Parse(args[1]) - 1;

            Clinic existingClinic = this.clinics.First(c => c.Name == clinicName);
            return existingClinic.Rooms[roomIndex].ToString();
        }
    }
}

