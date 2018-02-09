namespace KnightsOfHonor
{
    using System;
    using System.Linq;

    public class KnightsOfHonor
    {
        public static void Main()
        {
            Action<string[]> print = message => message.ToList().ForEach(x => Console.WriteLine($"Sir {x}"));

            string[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            print(input);
        }
    }
}
