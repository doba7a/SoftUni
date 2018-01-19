namespace CountSubstringOccurunces
{
    using System;

    public class CountSubstringOccurunces
    {
        public static void Main()
        {
            string inputString = Console.ReadLine().ToLower();
            string searchedString = Console.ReadLine().ToLower();

            int index = -1;
            int count = 0;

            while (true)
            {
                index = inputString.IndexOf(searchedString, index + 1);

                if (index < 0)
                {
                    break;
                }

                count++;
            }

            Console.WriteLine(count);
        }
    }
}