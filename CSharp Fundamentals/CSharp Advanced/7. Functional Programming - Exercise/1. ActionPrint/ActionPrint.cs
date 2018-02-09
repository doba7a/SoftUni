namespace ActionPrint
{
    using System;

    public class ActionPrint
    {
        public static void Main()
        {
            Action<string[]> print = message => Console.WriteLine(String.Join("\n", message));

            string[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            print(input);
        }
    }
}
