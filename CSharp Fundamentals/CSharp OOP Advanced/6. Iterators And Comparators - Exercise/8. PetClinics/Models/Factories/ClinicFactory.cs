using System;

public class ClinicFactory
{
    public Clinic CreateClinic(string name, int numberOfRooms)
    {
        if (numberOfRooms % 2 == 0)
        {
            throw new InvalidOperationException("Invalid Operation!");
        }

        Clinic currentClinic = new Clinic(name, numberOfRooms);

        for (int i = 0; i < currentClinic.Rooms.Length; i++)
        {
            currentClinic.Rooms[i] = new Room();
        }

        return currentClinic;
    }
}

