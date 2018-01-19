namespace BeverageLabels
{
    using System;

    public class BeverageLabels
    {
        public static void Main()
        {
            var name = Console.ReadLine();
            var volume = double.Parse(Console.ReadLine());
            var energyPer100ml = double.Parse(Console.ReadLine());
            var sugarPer100ml = double.Parse(Console.ReadLine());

            var multiplier = volume / 100.00;

            Console.WriteLine($"{volume}ml {name}:\r\n{energyPer100ml * multiplier}kcal, {sugarPer100ml * multiplier}g sugars");
        }
    }
}