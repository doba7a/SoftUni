namespace CalculateSequenceWithQueue
{
    using System;
    using System.Collections.Generic;

    public class CalculateSequenceWithQueue
    {
        public static void Main()
        {
            Queue<long> sequenceOfIntegers = new Queue<long>();

            long firstMemberOfTheSequence = long.Parse(Console.ReadLine());
            sequenceOfIntegers.Enqueue(firstMemberOfTheSequence);

            long nextValue = 0;
            long memberOfSequenceToUse = 0;

            while (sequenceOfIntegers.Count <= 50)
            {
                long currentMemberOfSequenceToUse = sequenceOfIntegers.ToArray()[memberOfSequenceToUse];

                nextValue = currentMemberOfSequenceToUse + 1;
                sequenceOfIntegers.Enqueue(nextValue);

                if (sequenceOfIntegers.Count >= 50)
                {
                    break;
                }

                nextValue = 2 * currentMemberOfSequenceToUse + 1;
                sequenceOfIntegers.Enqueue(nextValue);

                if (sequenceOfIntegers.Count >= 50)
                {
                    break;
                }

                nextValue = currentMemberOfSequenceToUse + 2;
                sequenceOfIntegers.Enqueue(nextValue);

                memberOfSequenceToUse++;
            }

            Console.WriteLine(string.Join(" ", sequenceOfIntegers));
        }
    }
}
