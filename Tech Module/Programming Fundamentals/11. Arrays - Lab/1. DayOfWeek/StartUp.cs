namespace DayOfWeek
{
    using System;

    public class DayOfWeek
    {
        public static void Main()
        {
            string[] daysOfWeek = new string[7]
            {
                "Monday",
                "Tuesday",
                "Wednesday",
                "Thursday",
                "Friday",
                "Saturday",
                "Sunday"
            };

            int dayToPrint = int.Parse(Console.ReadLine());

            if (dayToPrint < 1 || dayToPrint > 7)
            {
                Console.WriteLine("Invalid Day!");
            }
            else
            {
                Console.WriteLine(daysOfWeek[dayToPrint - 1]);
            }
        }
    }
}