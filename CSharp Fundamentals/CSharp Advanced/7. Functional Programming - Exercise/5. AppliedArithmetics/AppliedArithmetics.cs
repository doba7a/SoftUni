namespace AppliedArithmetics
{
    using System;
    using System.Linq;

    public class AppliedArithmetics
    {
        public static void Main()
        {
            int[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            string commands = Console.ReadLine();

            Func<int, int> add = n => n + 1;
            Func<int, int> subtract = n => n - 1;
            Func<int, int> multiply = n => n * 2;
            Action<int[]> print = numbers => Console.WriteLine(String.Join(" ", numbers));

            while (commands != "end")
            {
                switch (commands)
                {
                    case "add":
                        input = input.Select(add).ToArray();
                        break;
                    case "subtract":
                        input = input.Select(subtract).ToArray();
                        break;
                    case "multiply":
                        input = input.Select(multiply).ToArray();
                        break;
                    case "print":
                        print(input);
                        break;
                }

                commands = Console.ReadLine();
            }
        }
    }
}
