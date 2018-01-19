namespace ImmuneSystem
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Text;

    public class ImmuneSystem
    {
        public static void Main()
        {
            List<string> virusesFought = new List<string>();

            int immuneSystemHealth = int.Parse(Console.ReadLine());

            int initialImmuneSystemHealth = immuneSystemHealth;

            string virusName = Console.ReadLine();

            while (virusName != "end")
            {
                int virusStrength = CalculateVirusStrength(virusName);

                int virusTimeToDefeat = CalculateTimeToDefeatVirus(virusesFought, virusName, virusStrength);

                Console.WriteLine($"Virus {virusName}: {virusStrength} => {virusTimeToDefeat} seconds");

                if (immuneSystemHealth - virusTimeToDefeat <= 0)
                {
                    Console.WriteLine("Immune System Defeated.");
                    Environment.Exit(1);
                }

                immuneSystemHealth -= virusTimeToDefeat;

                Console.WriteLine($"{virusName} defeated in {virusTimeToDefeat / 60}m {virusTimeToDefeat % 60}s.");
                Console.WriteLine($"Remaining health: {immuneSystemHealth}");

                int immuneSystemRegenerationAfterFightingAVirus = (int)(immuneSystemHealth * 0.2);
                immuneSystemHealth =
                    Math.Min(initialImmuneSystemHealth, immuneSystemHealth + immuneSystemRegenerationAfterFightingAVirus);

                virusName = Console.ReadLine();
            }

            Console.WriteLine($"Final Health: {immuneSystemHealth}");
        }

        public static int CalculateVirusStrength(string virusName)
        {
            byte[] virusChars = Encoding.ASCII.GetBytes(virusName);
            int virusStrength = 0;

            foreach (byte charAsInt in virusChars)
            {
                virusStrength += charAsInt;
            }

            virusStrength /= 3;

            return virusStrength;
        }

        public static int CalculateTimeToDefeatVirus(List<string> virusesFought, string virusName, int virusStrength)
        {
            int currentVirusTimeToDefeat = 0;

            if (!virusesFought.Contains(virusName))
            {
                virusesFought.Add(virusName);
                currentVirusTimeToDefeat = virusStrength * virusName.Length;
            }
            else
            {
                currentVirusTimeToDefeat = (virusStrength * virusName.Length) / 3;
            }

            return currentVirusTimeToDefeat;
        }
    }
}