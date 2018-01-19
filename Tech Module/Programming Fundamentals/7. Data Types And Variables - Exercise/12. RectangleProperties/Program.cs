namespace RectangleProperties
{
    using System;

    public class RectangleProperties
    {
        public static void Main()
        {
            double width = double.Parse(Console.ReadLine());
            double heigth = double.Parse(Console.ReadLine());

            Console.WriteLine(2 * width + 2 * heigth);
            Console.WriteLine(width * heigth);
            Console.WriteLine(Math.Sqrt(width * width + heigth * heigth));
        }
    }
}