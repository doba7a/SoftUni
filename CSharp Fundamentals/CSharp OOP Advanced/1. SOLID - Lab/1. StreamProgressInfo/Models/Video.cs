public class Video : IStreamable
{
    private string name;

    public Video(string name, int length, int bytesSent)
    {
        this.name = name;
        this.Length = length;
        this.BytesSent = bytesSent;
    }

    public int Length { get; }

    public int BytesSent { get; }
}

