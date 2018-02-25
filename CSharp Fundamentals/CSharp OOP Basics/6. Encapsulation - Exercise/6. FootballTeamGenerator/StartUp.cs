using System;

public class StartUp
{
    public static void Main(string[] args)
    {
        string input = Console.ReadLine();

        while (input != "END")
        {
            string[] tokens = input.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            try
            {
                Engine.Launch(tokens);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            input = Console.ReadLine();
        }
    }
}
