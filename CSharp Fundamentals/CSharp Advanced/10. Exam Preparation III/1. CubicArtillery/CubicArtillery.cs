namespace CubicArtillery
{
    using System;
    using System.Collections.Generic;

    public class CubicArtillery
    {
        public static void Main()
        {
            int bunkerCapacity = int.Parse(Console.ReadLine());

            Dictionary<string, Queue<int>> bunkersData = new Dictionary<string, Queue<int>>();
            Queue<string> bunkerNames = new Queue<string>();
            int currentBunkerSum = 0;

            string inputGiven = Console.ReadLine();

            while (inputGiven != "Bunker Revision")
            {
                string[] inputData = inputGiven.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string item in inputData)
                {
                    if (char.IsLetter(item[0]))
                    {
                        bunkersData[item] = new Queue<int>();
                        bunkerNames.Enqueue(item);
                    }
                    else
                    {
                        string bunkerToAddTo = bunkerNames.Peek();
                        int weaponCapacity = int.Parse(item);

                        if (currentBunkerSum + weaponCapacity <= bunkerCapacity)
                        {
                            bunkersData[bunkerToAddTo].Enqueue(weaponCapacity);
                            currentBunkerSum += weaponCapacity;
                        }
                        else if (currentBunkerSum + weaponCapacity > bunkerCapacity
                            && weaponCapacity <= bunkerCapacity
                            && bunkerNames.Count == 1)
                        {
                            while (true)
                            {
                                currentBunkerSum -= bunkersData[bunkerToAddTo].Peek();
                                bunkersData[bunkerToAddTo].Dequeue();

                                if (currentBunkerSum + weaponCapacity <= bunkerCapacity)
                                {
                                    bunkersData[bunkerToAddTo].Enqueue(weaponCapacity);
                                    currentBunkerSum += weaponCapacity;
                                    break;
                                }
                            }
                        }
                        else if (bunkerNames.Count > 1)
                        {
                            currentBunkerSum = 0;

                            if (weaponCapacity > bunkerCapacity)
                            {
                                while (bunkerNames.Count > 1)
                                {
                                    if (bunkersData[bunkerToAddTo].Count > 0)
                                    {
                                        Console.WriteLine($"{bunkerToAddTo} -> {string.Join(", ", bunkersData[bunkerToAddTo])}");
                                    }
                                    else
                                    {
                                        Console.WriteLine($"{bunkerToAddTo} -> Empty");
                                    }

                                    bunkerNames.Dequeue();

                                    bunkerToAddTo = bunkerNames.Peek();
                                }
                            }
                            else
                            {
                                if (bunkersData[bunkerToAddTo].Count > 0)
                                {
                                    Console.WriteLine($"{bunkerToAddTo} -> {string.Join(", ", bunkersData[bunkerToAddTo])}");
                                }
                                else
                                {
                                    Console.WriteLine($"{bunkerToAddTo} -> Empty");
                                }

                                bunkerNames.Dequeue();

                                bunkerToAddTo = bunkerNames.Peek();

                                bunkersData[bunkerToAddTo].Enqueue(weaponCapacity);
                                currentBunkerSum += weaponCapacity;
                            }
                        }
                    }
                }

                inputGiven = Console.ReadLine();
            }
        }
    }
}
