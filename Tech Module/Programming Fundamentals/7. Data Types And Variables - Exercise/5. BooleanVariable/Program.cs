namespace BooleanVariable
{
    using System;

    public class BooleanVariable
    {
        public static void Main()
        {
            string variable = Console.ReadLine();
            bool var = Convert.ToBoolean(variable);

            if (var)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }
}