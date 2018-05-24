using System.Collections.Generic;
using System.Linq;

public class Engine
{
    private ICommandInterpreter commandInterpreter;
    private IReader reader;
    private IWriter writer;

    public Engine(ICommandInterpreter commandInterpreter, IReader reader, IWriter writer)
    {
        this.commandInterpreter = commandInterpreter;
        this.reader = reader;
        this.writer = writer;
    }

    public void Run()
    {
        while (true)
        {
            List<string> inputData = reader.ReadLine().Split().ToList();

            string result = this.commandInterpreter.ProcessCommand(inputData);

            writer.WriteLine(result);

            if (inputData[0] == "Shutdown")
            {
                break;
            }
        }
    }
}
