namespace ForeignLanguages
{
    using System;

    public class ForeignLanguages
    {
        public static void Main()
        {
            var givenCountry = Console.ReadLine();

            if (givenCountry == "USA" || givenCountry == "England")
            {
                Console.WriteLine("English");
            }
            else if (givenCountry == "Spain" || givenCountry == "Argentina" || givenCountry == "Mexico")
            {
                Console.WriteLine("Spanish");
            }
            else
            {
                Console.WriteLine("unknown");
            }
        }
    }
}