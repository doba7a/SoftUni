namespace DepartmentsWithMoreThan5Employees
{
    using DatabaseFirst.Data;
    using System;
    using System.IO;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            using (SoftUniContext db = new SoftUniContext())
            {
                var departments = db
                    .Departments
                    .Where(d => d.Employees.Count > 5)
                    .OrderBy(d => d.Employees.Count)
                    .ThenBy(d => d.Name)
                    .Select(d => new
                    {
                        d.Name,
                        Manager = $"{d.Manager.FirstName} {d.Manager.LastName}",
                        Employees = d.Employees.OrderBy(e => e.FirstName).ThenBy(e => e.LastName).Select(e => new
                        {
                            Name = $"{e.FirstName} {e.LastName}",
                            e.JobTitle
                        })
                    });

                using (StreamWriter sw = new StreamWriter("../../../output.txt"))
                {
                    foreach (var department in departments)
                    {
                        sw.WriteLine($"{department.Name} - {department.Manager}");

                        foreach (var employee in department.Employees)
                        {
                            sw.WriteLine($"{employee.Name} - {employee.JobTitle}");
                        }

                        sw.WriteLine("----------");
                    }
                }
            }
        }
    }
}
