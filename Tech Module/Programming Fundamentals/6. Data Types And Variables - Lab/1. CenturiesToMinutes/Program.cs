namespace CenturiesToMinutes
{
    using System;

    public class CenturiesToMinutes
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            long years = n * 100;
            long days = (int)(years * 365.2422);
            long hours = days * 24;
            long minutes = hours * 60;

            Console.WriteLine($"{n} centuries = {years} years = {days} days = {hours} hours = {minutes} minutes");
        }
    }
}