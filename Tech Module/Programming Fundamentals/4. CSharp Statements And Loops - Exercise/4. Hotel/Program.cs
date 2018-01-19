namespace Hotel
{
    using System;

    public class Hotel
    {
        public static void Main()
        {
            var month = Console.ReadLine();
            var nightsCount = int.Parse(Console.ReadLine());

            double studioPrice = 0;
            double doublePrice = 0;
            double suitePrice = 0;

            if (month == "May" || month == "October")
            {
                studioPrice = 50 * nightsCount;
                doublePrice = 65 * nightsCount;
                suitePrice = 75 * nightsCount;

                if (nightsCount > 7)
                {
                    studioPrice = studioPrice - (studioPrice * 0.05);
                }
                if (nightsCount > 7 && month == "October")
                {
                    studioPrice = studioPrice - (studioPrice / nightsCount);
                }
            }
            else if (month == "June" || month == "September")
            {
                studioPrice = 60 * nightsCount;
                doublePrice = 72 * nightsCount;
                suitePrice = 82 * nightsCount;

                if (nightsCount > 7 && month == "September")
                {
                    studioPrice = 60 * (nightsCount - 1);
                }

                if (nightsCount > 14)
                {
                    doublePrice = doublePrice - (doublePrice * 0.10);
                }
            }
            else if (month == "July" || month == "August" || month == "December")
            {
                studioPrice = 68 * nightsCount;
                doublePrice = 77 * nightsCount;
                suitePrice = 89 * nightsCount;

                if (nightsCount > 14)
                {
                    suitePrice = suitePrice - (suitePrice * 0.15);
                }
            }

            Console.WriteLine($"Studio: {studioPrice:F2} lv.");
            Console.WriteLine($"Double: {doublePrice:F2} lv.");
            Console.WriteLine($"Suite: {suitePrice:F2} lv.");
        }
    }
}