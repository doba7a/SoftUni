namespace Employee147
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
                var employee = db
                    .Employees
                    .Where(e => e.EmployeeId == 147)
                    .Select(e => new
                    {
                        Name = $"{e.FirstName} {e.LastName}",
                        Job = e.JobTitle,
                        Projects = e.EmployeesProjects
                            .OrderBy(ep => ep.Project.Name)
                            .Select(ep => ep.Project.Name)
                    })
                    .FirstOrDefault();

                using (StreamWriter sw = new StreamWriter("../../../output.txt"))
                {
                    sw.WriteLine($"{employee.Name} - {employee.Job}");

                    foreach (var project in employee.Projects)
                    {
                        sw.WriteLine(project);
                    }
                }
            }
        }
    }
}
