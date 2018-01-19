namespace CatchTheThief
{
    using System;

    public class CatchTheThief
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

            Console.WriteLine(thiefID);
        }
    }
}