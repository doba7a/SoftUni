namespace CharacterStats
{
    using System;
    using System.Text;

    public class CharacterStats
    {
        public static void Main()
        {
            var name = Console.ReadLine();
            var currentHealth = int.Parse(Console.ReadLine());
            var maxHealth = int.Parse(Console.ReadLine());
            var currentEnergy = int.Parse(Console.ReadLine());
            var maxEnergy = int.Parse(Console.ReadLine());

            var sbHealth = new StringBuilder();
            sbHealth.Append('|');
            sbHealth.Append(new string('|', currentHealth));
            sbHealth.Append(new string('.', maxHealth - currentHealth));
            sbHealth.Append('|');

            var sbEnergy = new StringBuilder();
            sbEnergy.Append('|');
            sbEnergy.Append(new string('|', currentEnergy));
            sbEnergy.Append(new string('.', maxEnergy - currentEnergy));
            sbEnergy.Append('|');

            Console.WriteLine($"Name: {name}\r\nHealth: {sbHealth}\r\nEnergy: {sbEnergy}");
        }
    }
}