namespace AddingANewAddressAndUpdatingEmployee
{
    using DatabaseFirst.Data;
    using DatabaseFirst.Data.Models;
    using System.IO;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            using (SoftUniContext db = new SoftUniContext())
            {
                Address address = new Address()
                {
                    AddressText = "Vitoshka 15",
                    TownId = 4
                };

                db.Employees.FirstOrDefault(e => e.LastName == "Nakov").Address = address;

                db.SaveChanges();

                var employees = db
                    .Employees
                    .OrderByDescending(e => e.AddressId)
                    .Take(10)
                    .Select(e => e.Address.AddressText);

                using (StreamWriter sw = new StreamWriter("../../../output.txt"))
                {
                    foreach (var employee in employees)
                    {
                        sw.WriteLine(employee);
                    }
                }
            }
        }
    }
}
