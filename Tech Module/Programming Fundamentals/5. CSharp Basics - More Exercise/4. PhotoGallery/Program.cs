namespace PhotoGallery
{
    using System;

    public class PhotoGallery
    {
        public static void Main()
        {
            var name = int.Parse(Console.ReadLine());
            Console.WriteLine($"Name: DSC_{name:D4}.jpg");

            var day = int.Parse(Console.ReadLine());
            var month = int.Parse(Console.ReadLine());
            var year = int.Parse(Console.ReadLine());
            var hour = int.Parse(Console.ReadLine());
            var minute = int.Parse(Console.ReadLine());
            Console.WriteLine($"Date Taken: {day:D2}/{month:D2}/{year:D2} {hour:D2}:{minute:D2}");

            var size = double.Parse(Console.ReadLine());
            if (size < 1000)
            {
                Console.WriteLine($"Size: {size}B");
            }
            else if (size < 1000000)
            {
                Console.WriteLine($"Size: {size / 1000.0}KB");
            }
            else
            {
                Console.WriteLine($"Size: {size / 1000000.0}MB");
            }

            var photoWidth = int.Parse(Console.ReadLine());
            var photoHeight = int.Parse(Console.ReadLine());
            if (photoWidth > photoHeight)
            {
                Console.WriteLine($"Resolution: {photoWidth}x{photoHeight} (landscape)");
            }
            else if (photoHeight > photoWidth)
            {
                Console.WriteLine($"Resolution: {photoWidth}x{photoHeight} (portrait)");
            }
            else
            {
                Console.WriteLine($"Resolution: {photoWidth}x{photoHeight} (square)");
            }
        }
    }
}