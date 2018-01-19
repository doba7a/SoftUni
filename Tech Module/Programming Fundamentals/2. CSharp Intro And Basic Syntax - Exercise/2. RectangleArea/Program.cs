namespace RectangleArea
{
    using System;

    public class RectangleArea
    {
        public static void Main()
        {
            var rectangelWidth = double.Parse(Console.ReadLine());
            var rectangleHeight = double.Parse(Console.ReadLine());

            var area = rectangelWidth * rectangleHeight;

            Console.WriteLine($"{area:F2}");
        }
    }
}