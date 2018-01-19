namespace CountTheIntegers
{
    using System;

    public class CountTheIntegers
    {
        public static void Main()
        {
            var integerCount = 0;

            while (true)
            {
                var input = Console.ReadLine();

                try
                {
                    int.Parse(input);
                    integerCount++;
                }
                catch (Exception)
                {
                    Console.WriteLine(integerCount);
                    Environment.Exit(1);
                }
            }
        }
    }
}