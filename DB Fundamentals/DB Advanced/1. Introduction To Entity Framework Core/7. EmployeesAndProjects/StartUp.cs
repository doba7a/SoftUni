namespace EmployeesAndProjects
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
                    .Where(e => e.EmployeesProjects.Any(ep => ep.Project.StartDate.Year >= 2001
                        && ep.Project.StartDate.Year <= 2003))
                    .Take(30)
                    .Select(e => new
                    {
                        Name = $"{e.FirstName} {e.LastName}",
                        ManagerName = $"{e.Manager.FirstName} {e.Manager.LastName}",
                        Projects = e.EmployeesProjects.Select(ep => new
                        {
                            ProjectName = ep.Project.Name,
                            Date = ep.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt"),
                            EndDate = ep.Project.EndDate == null ? "not finished" : ep.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt"),
                        })
                    });
                
                using (StreamWriter sw = new StreamWriter("../../../output.txt"))
                {
                    foreach (var employee in employees)
                    {
                        sw.WriteLine($"{employee.Name} - Manager: {employee.ManagerName}");

                        foreach (var project in employee.Projects)
                        {
                            sw.WriteLine($"--{project.ProjectName} - {project.Date} - {project.EndDate}");
                        }
                    }
                }
            }   
        }
    }
}
