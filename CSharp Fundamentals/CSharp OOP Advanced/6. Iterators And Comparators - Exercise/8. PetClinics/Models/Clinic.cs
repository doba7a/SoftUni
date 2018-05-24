using System.Text;

public class Clinic : IClinic
{
    private string name;
    private readonly Room[] rooms;

    public Clinic(string name, int numberOfRooms)
    {
        this.Name = name;
        this.rooms = new Room[numberOfRooms];
    }

    public string Name { get => name; private set => name = value; }

    public Room[] Rooms => rooms;

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < this.Rooms.Length; i++)
        {
            sb.AppendLine(this.Rooms[i].ToString());
        }

        return sb.ToString().Trim();
    }
}

