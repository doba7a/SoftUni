namespace CustomMinFunction
{
    using System;
    using System.Linq;

    public class CustomMinFunction
    {
        public static void Main()
        {
            int[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Func<int[], int> GetMinValue = num =>
            {
                int minNumber = int.MaxValue;

                for (int index = 0; index < input.Length; index++)
                {
                    if (input[index] < minNumber)
                    {
                        minNumber = input[index];
                    }
                }

                return minNumber;
            };

            Console.WriteLine(GetMinValue(input));
        }
    }
}
