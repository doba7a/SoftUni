namespace CubicsRube
{
    using System;
    using System.Linq;
    using System.Numerics;

    public class CubicsRube
    {
        public static void Main()
        {
            int cubeDimensions = int.Parse(Console.ReadLine());

            BigInteger sumOfCells = 0;
            BigInteger attackedCells = cubeDimensions * cubeDimensions * cubeDimensions;

            string currentInput = Console.ReadLine();

            while (currentInput != "Analyze")
            {
                int[] inputData = currentInput
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int cubeLengthPoint = inputData[0];
                int cubeWidthPoint = inputData[1];
                int cubeDepthPoint = inputData[2];
                int particles = inputData[3];

                if (IsInCube(cubeDimensions, cubeLengthPoint, cubeWidthPoint, cubeDepthPoint) && particles != 0)
                {
                    sumOfCells += particles;
                    attackedCells--;
                }

                currentInput = Console.ReadLine();
            }

            Console.WriteLine(sumOfCells);
            Console.WriteLine(attackedCells);
        }

        public static bool IsInCube(int cubeDimensions, int cubeLengthPoint, int cubeWidthPoint, int cubeDepthPoint)
        {
            if (cubeLengthPoint >= 0 && cubeLengthPoint < cubeDimensions
                && cubeWidthPoint >= 0 && cubeWidthPoint < cubeDimensions
                && cubeDepthPoint >= 0 && cubeDepthPoint < cubeDimensions)
            {
                return true;
            }

            return false;
        }
    }
}
