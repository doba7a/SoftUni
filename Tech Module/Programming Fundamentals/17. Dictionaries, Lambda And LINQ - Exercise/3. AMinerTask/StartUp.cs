namespace AMinerTask
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class AMinerTask
    {
        public static void Main()
        {
            Dictionary<string, int> resourcesDictionary = new Dictionary<string, int>();

            string currentResource = Console.ReadLine();

            while (currentResource != "stop")
            {
                int currentResourceValue = int.Parse(Console.ReadLine());

                if (!resourcesDictionary.ContainsKey(currentResource))
                {
                    resourcesDictionary[currentResource] = 0;
                }

                resourcesDictionary[currentResource] += currentResourceValue;

                currentResource = Console.ReadLine();
            }

            foreach (var resource in resourcesDictionary)
            {
                Console.WriteLine($"{resource.Key} -> {resource.Value}");
            }
        }
    }
}