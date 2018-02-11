namespace HitList
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class HitList
    {
        public static void Main()
        {
            int infoIndex = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, string>> dataDict = new Dictionary<string, Dictionary<string, string>>();

            string currentInput = Console.ReadLine();

            while (currentInput != "end transmissions")
            {
                string[] inputData = currentInput
                    .Split(new[] { '=', ':', ';' }, StringSplitOptions.RemoveEmptyEntries);

                string name = inputData[0];

                if (!dataDict.ContainsKey(name))
                {
                    dataDict[name] = new Dictionary<string, string>();
                }

                for (int i = 1; i < inputData.Length; i += 2)
                {
                    string key = inputData[i];
                    string value = inputData[i + 1];

                    dataDict[name][key] = value;
                }

                currentInput = Console.ReadLine();
            }

            int personInfoIndex = 0;

            string personToKill = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[1];

            Console.WriteLine($"Info on {personToKill}:");
            foreach (var info in dataDict[personToKill].OrderBy(x => x.Key))
            {
                personInfoIndex += info.Key.Length + info.Value.Length;

                Console.WriteLine($"---{info.Key}: {info.Value}");
            }

            Console.WriteLine($"Info index: {personInfoIndex}");

            if (personInfoIndex >= infoIndex)
            {
                Console.WriteLine("Proceed");
            }
            else
            {
                Console.WriteLine($"Need {infoIndex - personInfoIndex} more info.");
            }
        }
    }
}
