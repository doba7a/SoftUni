namespace calculateTriangleArea
{
    using System;

    public class calculateTriangleArea
    {
        public static void Main()
        {
            double sideLength = double.Parse(Console.ReadLine());
            double heigthLength = double.Parse(Console.ReadLine());

            double area = getTriangleArea(sideLength, heigthLength);

            Console.WriteLine(area);
        }

        public static double getTriangleArea(double sideLength, double heigthLength)
        {
            return sideLength * heigthLength / 2;
        }
    }
}