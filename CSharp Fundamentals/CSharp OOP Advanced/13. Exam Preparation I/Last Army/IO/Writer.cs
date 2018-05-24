using System;
using System.Text;

class Writer : IWriter
{
    private StringBuilder sb;

    public Writer()
    {
        this.sb = new StringBuilder();
    }

    public void AppendLine(string line)
    {
        sb.AppendLine(line);
    }

    public void WriteAllLine()
    {
        Console.WriteLine(sb.ToString().Trim());
    }
}
