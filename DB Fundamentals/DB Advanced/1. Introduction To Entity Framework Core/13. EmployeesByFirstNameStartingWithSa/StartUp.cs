namespace EmployeesByFirstNameStartingWithSa
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
                var employees = db
                    .Employees
                    .Where(e => e.FirstName.StartsWith("Sa"))
                    .OrderBy(e => e.FirstName)
                    .ThenBy(e => e.LastName)
                    .Select(e => new
                    {
                        Name = $"{e.FirstName} {e.LastName}",
                        Job = e.JobTitle,
                        Salary = $"${e.Salary:F2}"
                    });


                using (StreamWriter sw = new StreamWriter("../../../output.txt"))
                {
                    foreach (var employee in employees)
                    {
                        sw.WriteLine($"{employee.Name} - {employee.Job} - ({employee.Salary})");
                    }
                }
            }
        }
    }
}
