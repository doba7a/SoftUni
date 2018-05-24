using System;

class Engine : IEngine
{
    private const string END_GAME_COMMAND = "Enough! Pull back!";
    private IReader reader;
    private IWriter writer;

    public Engine(IReader reader, IWriter writer)
    {
        this.reader = reader;
        this.writer = writer;
    }
    public void Run()
    {
        string input = this.reader.ReadLine();
        GameController gameController = new GameController(this.writer);

        while (!input.Equals(END_GAME_COMMAND))
        {
            try
            {
                gameController.GiveInputToGameController(input);
            }
            catch (ArgumentException arg)
            {
                writer.AppendLine(arg.Message);
            }

            input = this.reader.ReadLine();
        }

        gameController.RequestResult();
        this.writer.WriteAllLine();
    }
}

