namespace greaterOfTwoValues
{
    using System;

    public class greaterOfTwoValues
    {
        public static void Main()
        {
            string type = Console.ReadLine();

            if (type == "int")
            {
                int first = int.Parse(Console.ReadLine());
                int second = int.Parse(Console.ReadLine());
                int result = greaterValue(first, second);
                Console.WriteLine(result);
            }

            else if (type == "char")
            {
                char first = char.Parse(Console.ReadLine());
                char second = char.Parse(Console.ReadLine());
                char result = greaterValue(first, second);
                Console.WriteLine(result);
            }

            else if (type == "string")
            {
                string first = Console.ReadLine();
                string second = Console.ReadLine();
                string result = greaterValue(first, second);
                Console.WriteLine(result);
            }

        }

        public static int greaterValue(int first, int second)
        {
            return Math.Max(first, second);
        }

        public static char greaterValue(char first, char second)
        {
            if (first >= second)
            {
                return first;
            }
            else
            {
                return second;
            }
        }

        public static string greaterValue(string first, string second)
        {
            if (first.CompareTo(second) >= 0)
            {
                return first;
            }
            else
            {
                return second;
            }
        }
    }
}
