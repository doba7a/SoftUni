namespace DNASequences
{
    using System;
    using System.Collections.Generic;

    public class DNASequences
    {
        public static void Main()
        {
            var charValueDict = new Dictionary<int, char>()
            {
                { 1, 'A' },
                { 2, 'C' },
                { 3, 'G' },
                { 4, 'T' }
            };

            var matchSum = int.Parse(Console.ReadLine());

            for (int i = 1; i <= 4; i++)
            {
                for (int j = 1; j <= 4; j++)
                {
                    for (int k = 1; k <= 4; k++)
                    {
                        var currentSum = i + j + k;

                        if (currentSum >= matchSum)
                        {
                            Console.Write($"O{charValueDict[i]}{charValueDict[j]}{charValueDict[k]}O ");
                        }
                        else
                        {
                            Console.Write($"X{charValueDict[i]}{charValueDict[j]}{charValueDict[k]}X ");
                        }
                    }

                    Console.WriteLine();
                }
            }
        }
    }
}