namespace EmployeesFromResearchAndDevelopment
{
    using DatabaseFirst.Data;
    using System.IO;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (SoftUniContext db = new SoftUniContext())
            {
                var employees = db
                    .Employees
                    .Where(e => e.Department.Name == "Research and Development")
                    .OrderBy(e => e.Salary)
                    .ThenByDescending(e => e.FirstName)
                    .Select(e => new
                    {
                        Name = $"{e.FirstName} {e.LastName}",
                        Dept = e.Department.Name,
                        Salary = $"${e.Salary:F2}"
                    });

                using (StreamWriter sw = new StreamWriter("../../../output.txt"))
                {
                    foreach (var employee in employees)
                    {
                        sw.WriteLine($"{employee.Name} from {employee.Dept} - {employee.Salary}");
                    }
                }
            }
        }
    }
}
