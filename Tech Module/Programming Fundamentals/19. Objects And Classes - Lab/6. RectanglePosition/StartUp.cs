namespace RectanglePosition
{
    using System;
    using System.Linq;

    public class RectanglePosition
    {
        public static void Main()
        {
            Rectangle firstRectangle = Rectangle.ReadRectangle(Console.ReadLine());

            Rectangle secondRectangle = Rectangle.ReadRectangle(Console.ReadLine());

            string checkIfFirstRectangleIsInsideTheSecond = Rectangle.IsInside(firstRectangle, secondRectangle);

            Console.WriteLine(checkIfFirstRectangleIsInsideTheSecond);
        }
    }

    public class Rectangle
    {
        public int Top { get; set; }
        public int Left { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Bottom { get; set; }
        public int Right { get; set; }

        public static int FindBottom(int top, int height)
        {
            int bottom = top - height;

            return bottom;
        }

        public static int FindRight(int left, int width)
        {
            int right = left + width;

            return right;
        }

        public static Rectangle ReadRectangle(string rectangleData)
        {
            int[] givenRectangleData = rectangleData.Split(' ').Select(int.Parse).ToArray();

            int left = givenRectangleData[0];
            int width = givenRectangleData[2];
            int right = Rectangle.FindRight(left, width);

            int top = givenRectangleData[1];
            int height = givenRectangleData[3];
            int bottom = Rectangle.FindBottom(top, height);

            Rectangle currentRectangle = new Rectangle
            {
                Top = top,
                Bottom = bottom,
                Left = left,
                Right = right
            };

            return currentRectangle;
        }

        public static string IsInside(Rectangle firstRectangle, Rectangle secondRectangle)
        {
            if (firstRectangle.Left >= secondRectangle.Left
                && firstRectangle.Right <= secondRectangle.Right
                && firstRectangle.Top <= secondRectangle.Top
                && firstRectangle.Bottom >= secondRectangle.Bottom)
            {
                return "Inside";
            }
            else
            {
                return "Not inside";
            }
        }
    }
}