namespace EmployeesWithSalaryOver50000
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
                    .Where(e => e.Salary > 50000)
                    .OrderBy(e => e.FirstName)
                    .Select(e => e.FirstName);

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
