namespace CameraView
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class CameraView
    {
        public static void Main()
        {
            int[] skipAndTakeElementsData = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int elementsToSkip = skipAndTakeElementsData[0];
            int elementsToTake = skipAndTakeElementsData[1];

            string inputText = Console.ReadLine();

            string cameraPattern = @"\|<";

            string[] viewsCollected = Regex.Split(inputText, cameraPattern);

            List<string> viewsFiltered = new List<string>();

            foreach (string view in viewsCollected.Skip(1))
            {
                viewsFiltered.Add(new string(view.Skip(elementsToSkip).Take(elementsToTake).ToArray()));
            }

            Console.WriteLine(string.Join(", ", viewsFiltered));
        }
    }
}