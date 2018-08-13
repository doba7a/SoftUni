namespace DeleteProjectById
{
    using DatabaseFirst.Data;
    using System.IO;
    using System.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {
            using (SoftUniContext db = new SoftUniContext())
            {
                var empProjectsToDelete = db.EmployeesProjects.Where(ep => ep.ProjectId == 2);

                foreach (var empProjectToDelete in empProjectsToDelete)
                {
                    db.EmployeesProjects.Remove(empProjectToDelete);
                }

                var projectToDelete = db.Projects.Find(2);
                db.Projects.Remove(projectToDelete);

                db.SaveChanges();

                var projects = db
                    .Projects
                    .Take(10)
                    .Select(p => p.Name);


                using (StreamWriter sw = new StreamWriter("../../../output.txt"))
                {
                    foreach (var project in projects)
                    {
                        sw.WriteLine(project);
                    }
                }
            }
        }
    }
}
