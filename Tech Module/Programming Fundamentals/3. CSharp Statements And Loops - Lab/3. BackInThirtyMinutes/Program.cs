namespace BackIn30Minutes
{
    using System;

    public class BackIn30Minutes
    {
        public static void Main()
        {
            var hours = int.Parse(Console.ReadLine());
            var minutes = int.Parse(Console.ReadLine()) + 30;

            if (minutes > 59)
            {
                hours++;

                if (hours > 23)
                {
                    hours = 0;
                }

                minutes -= 60;
            }

            Console.WriteLine($"{hours}:{minutes:D2}");
        }
    }
}