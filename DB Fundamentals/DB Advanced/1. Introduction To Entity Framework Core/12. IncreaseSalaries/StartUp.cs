namespace IncreaseSalaries
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
                foreach (var employee in db.Employees
                    .Where(e => e.Department.Name == "Engineering"
                        || e.Department.Name == "Tool Design"
                        || e.Department.Name == "Marketing"
                        || e.Department.Name == "Information Services"))
                {
                    employee.Salary += employee.Salary * 0.12m;
                }

                db.SaveChanges();

                var employees = db
                    .Employees
                    .Where(e => e.Department.Name == "Engineering"
                        || e.Department.Name == "Tool Design"
                        || e.Department.Name == "Marketing"
                        || e.Department.Name == "Information Services")
                    .OrderBy(e => e.FirstName)
                    .ThenBy(e => e.LastName)
                    .Select(e => new
                    {
                        Name = $"{e.FirstName} {e.LastName}",
                        Salary = $"${e.Salary:F2}"
                    });


                using (StreamWriter sw = new StreamWriter("../../../output.txt"))
                {
                    foreach (var employee in employees)
                    {
                        sw.WriteLine($"{employee.Name} ({employee.Salary})");
                    }
                }
            }
        }
    }
}
