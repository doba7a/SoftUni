namespace GeometryCalculator
{
    using System;

    public class GeometryCalculator
    {
        public static void Main()
        {
            string calculateAreaOf = Console.ReadLine();

            AreaToCalculate(calculateAreaOf);
        }

        public static void AreaToCalculate(string calculateAreaOf)
        {
            switch (calculateAreaOf)
            {
                case "triangle":
                    double triangleSide = double.Parse(Console.ReadLine());
                    double triangleHeigth = double.Parse(Console.ReadLine());
                    double triangleResult = triangleSide * triangleHeigth / 2;
                    Console.WriteLine($"{triangleResult:F2}");
                    break;
                case "rectangle":
                    double rectangleFirstSide = double.Parse(Console.ReadLine());
                    double rectangleSecondSide = double.Parse(Console.ReadLine());
                    double rectangleResult = rectangleFirstSide * rectangleSecondSide;
                    Console.WriteLine($"{rectangleResult:F2}");
                    break;
                case "square":
                    double squareSide = double.Parse(Console.ReadLine());
                    double squareResult = squareSide * squareSide;
                    Console.WriteLine($"{squareResult:F2}");
                    break;
                case "circle":
                    double circleRadius = double.Parse(Console.ReadLine());
                    double circleResult = Math.PI * circleRadius * circleRadius;
                    Console.WriteLine($"{circleResult:F2}");
                    break;
            }
        }
    }
}