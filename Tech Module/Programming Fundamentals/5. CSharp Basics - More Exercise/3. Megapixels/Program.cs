namespace Megapixels
{
    using System;

    public class Megapixels
    {
        public static void Main()
        {
            var imageWidth = double.Parse(Console.ReadLine());
            var imageHeight = double.Parse(Console.ReadLine());

            double megapixels = (imageWidth * imageHeight) / 1000000.0;

            Console.WriteLine($"{imageWidth}x{imageHeight} => {Math.Round(megapixels, 1)}MP");
        }
    }
}