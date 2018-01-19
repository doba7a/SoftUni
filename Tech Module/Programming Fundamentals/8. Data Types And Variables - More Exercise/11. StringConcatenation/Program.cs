namespace StringConcatenation
{
    using System;
    using System.Collections.Generic;

    public class StringConcatenation
    {
        public static void Main()
        {
            string delimeter = Console.ReadLine();
            string evenOrOdd = Console.ReadLine();
            int numberOfInputs = int.Parse(Console.ReadLine());

            List<string> output = new List<string>();

            for (int i = 1; i <= numberOfInputs; i++)
            {
                string givenWord = Console.ReadLine();

                if (evenOrOdd == "even" && i % 2 == 0)
                {
                    output.Add(givenWord);
                }
                else if (evenOrOdd == "odd" && i % 2 == 1)
                {
                    output.Add(givenWord);
                }
            }

            Console.WriteLine(string.Join(delimeter, output));
        }
    }
}