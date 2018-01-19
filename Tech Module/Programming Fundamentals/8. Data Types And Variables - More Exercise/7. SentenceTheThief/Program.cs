namespace SentenceTheThief
{
    using System;

    public class SentenceTheThief
    {
        public static void Main()
        {
            string ThiefIDNumeralType = Console.ReadLine();
            long numeralTypeMaxValue = 0;

            switch (ThiefIDNumeralType)
            {
                case "sbyte":
                    numeralTypeMaxValue = sbyte.MaxValue;
                    break;
                case "int":
                    numeralTypeMaxValue = int.MaxValue;
                    break;
                case "long":
                    numeralTypeMaxValue = long.MaxValue;
                    break;
            }

            int numberOfIDsReceived = int.Parse(Console.ReadLine());
            long thiefID = long.MinValue;

            for (int i = 0; i < numberOfIDsReceived; i++)
            {
                long givenID = long.Parse(Console.ReadLine());

                if (givenID <= numeralTypeMaxValue && thiefID < givenID)
                {
                    thiefID = givenID;
                }
            }

            double sentence = 0;
            if (thiefID < 0)
            {
                sentence = Math.Ceiling(thiefID / -128.0);
            }
            else
            {
                sentence = Math.Ceiling(thiefID / 127.0);
            }

            if (sentence > 1)
            {
                Console.WriteLine($"Prisoner with id {thiefID} is sentenced to {sentence} years");
            }
            else
            {
                Console.WriteLine($"Prisoner with id {thiefID} is sentenced to {sentence} year");
            }
        }
    }
}