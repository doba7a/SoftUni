namespace EmployeesFullInformation
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
                    .OrderBy(e => e.EmployeeId)
                    .Select(e => new
                    {
                        Information = $"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary:F2}",
                    });

                using (StreamWriter sw = new StreamWriter("output.txt"))
                {
                    foreach (var employee in employees)
                    {
                        sw.WriteLine(employee.Information);
                    }
                }             
            }
        }
    }
}
