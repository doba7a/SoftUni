namespace CountWorkingDays
{
    using System;
    using System.Globalization;
    using System.Collections.Generic;

    public class CountWorkingDays
    {
        public static void Main()
        {
            DateTime firstDate = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy", CultureInfo.InvariantCulture);
            DateTime secondDate = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy", CultureInfo.InvariantCulture);

            int workingDays = 0;

            for (DateTime currentDate = firstDate; currentDate <= secondDate; currentDate = currentDate.AddDays(1))
            {
                List<DateTime> holidaysList = new List<DateTime>
                {
                    new DateTime(currentDate.Year, 01, 01),
                    new DateTime(currentDate.Year, 03, 03),
                    new DateTime(currentDate.Year, 05, 01),
                    new DateTime(currentDate.Year, 05, 06),
                    new DateTime(currentDate.Year, 05, 24),
                    new DateTime(currentDate.Year, 09, 06),
                    new DateTime(currentDate.Year, 09, 22),
                    new DateTime(currentDate.Year, 11, 01),
                    new DateTime(currentDate.Year, 12, 24),
                    new DateTime(currentDate.Year, 12, 25),
                    new DateTime(currentDate.Year, 12, 26),
                    new DateTime(currentDate.Year, 01, 01),
                };

                if (currentDate.DayOfWeek == DayOfWeek.Saturday || currentDate.DayOfWeek == DayOfWeek.Sunday || holidaysList.Contains(currentDate))
                {
                    continue;
                }

                workingDays++;
            }

            Console.WriteLine(workingDays);
        }
    }
}