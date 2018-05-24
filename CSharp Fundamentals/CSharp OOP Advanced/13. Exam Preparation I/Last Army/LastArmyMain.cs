public class LastArmyMain
{
    public static void Main()
    {
        IWriter writer = new Writer();
        IReader reader = new Reader();

        Engine engine = new Engine(reader, writer);

        engine.Run();
    }
}
