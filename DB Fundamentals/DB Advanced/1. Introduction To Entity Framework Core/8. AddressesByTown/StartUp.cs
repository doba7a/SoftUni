namespace AddressesByTown
{
    using DatabaseFirst.Data;
    using System.IO;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            using (SoftUniContext db = new SoftUniContext())
            {
                var addresses = db
                    .Addresses
                    .OrderByDescending(a => a.Employees.Count())
                    .ThenBy(a => a.Town.Name)
                    .ThenBy(a => a.AddressText)
                    .Take(10)
                    .Select(a => new
                    {
                        a.AddressText,
                        TownName = a.Town.Name,
                        EmployeesCount = a.Employees.Count
                    });

                using (StreamWriter sw = new StreamWriter("../../../output.txt"))
                {
                    foreach (var address in addresses)
                    {
                        sw.WriteLine($"{address.AddressText}, {address.TownName} - {address.EmployeesCount} employees");
                    }
                }
            }
        }
    }
}
