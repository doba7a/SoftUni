namespace BoatSimulator
{
    using System;

    public class BoatSimulator
    {
        public static void Main()
        {
            char firstBoatSign = char.Parse(Console.ReadLine());
            char secondBoatSign = char.Parse(Console.ReadLine());

            int numberOfLines = int.Parse(Console.ReadLine());

            int firstBoatMoves = 0;
            int secondBoatMoves = 0;

            for (int i = 1; i <= numberOfLines; i++)
            {
                string currentInput = Console.ReadLine();

                if (currentInput == "UPGRADE")
                {
                    firstBoatSign = (char)(firstBoatSign + 3);
                    secondBoatSign = (char)(secondBoatSign + 3);
                    continue;
                }

                if (i % 2 == 1)
                {
                    firstBoatMoves += currentInput.Length;
                    if (firstBoatMoves >= 50)
                    {
                        Console.WriteLine(firstBoatSign);
                        Environment.Exit(1);
                    }
                }
                else
                {
                    secondBoatMoves += currentInput.Length;
                    if (secondBoatMoves >= 50)
                    {
                        Console.WriteLine(secondBoatSign);
                        Environment.Exit(1);
                    }
                }
            }

            if (firstBoatMoves > secondBoatMoves)
            {
                Console.WriteLine(firstBoatSign);
            }
            else
            {
                Console.WriteLine(secondBoatSign);
            }
        }
    }
}