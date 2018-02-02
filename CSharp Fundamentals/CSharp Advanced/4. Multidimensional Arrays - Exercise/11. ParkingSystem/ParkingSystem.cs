namespace ParkingSystem
{
    using System;
    using System.Linq;

    public class ParkingSystem
    {
        public static void Main()
        {
            int[] parkingDimensions = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = parkingDimensions[0];
            int columns = parkingDimensions[1];

            bool[][] parking = new bool[rows][];

            string carsParking = Console.ReadLine();

            while (carsParking != "stop")
            {
                int[] currentCarData = carsParking
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

                int entryRow = currentCarData[0];
                int desiredRow = currentCarData[1];
                int desiredColumn = currentCarData[2];

                if (parking[desiredRow] == null)
                {
                    parking[desiredRow] = new bool[columns];
                }

                if (!parking[desiredRow][desiredColumn])
                {
                    parking[desiredRow][desiredColumn] = true;

                    int distance = CalculateDistance(entryRow, desiredRow, desiredColumn);

                    Console.WriteLine(distance);
                }
                else
                {
                    int distanceFromDesiredSpot = 1;

                    while (true)
                    {
                        int columnToTheLeft = desiredColumn - distanceFromDesiredSpot;
                        int columnToTheRight = desiredColumn + distanceFromDesiredSpot;

                        if (columnToTheLeft < 1 && columnToTheRight >= columns)
                        {
                            Console.WriteLine($"Row {desiredRow} full");

                            break;
                        }

                        if (columnToTheLeft > 0 && !parking[desiredRow][columnToTheLeft])
                        {
                            parking[desiredRow][columnToTheLeft] = true;

                            int distance = CalculateDistance(entryRow, desiredRow, columnToTheLeft);

                            Console.WriteLine(distance);

                            break;
                        }

                        if (columnToTheRight < columns && !parking[desiredRow][columnToTheRight])
                        {
                            parking[desiredRow][columnToTheRight] = true;

                            int distance = CalculateDistance(entryRow, desiredRow, columnToTheRight);

                            Console.WriteLine(distance);

                            break;
                        }

                        distanceFromDesiredSpot++;
                    }
                }

                carsParking = Console.ReadLine();
            }
        }

        public static int CalculateDistance(int entryRow, int desiredRow, int desiredColumn)
        {
            int distance = 1 + Math.Abs(entryRow - desiredRow) + desiredColumn;

            return distance;
        }
    }
}
