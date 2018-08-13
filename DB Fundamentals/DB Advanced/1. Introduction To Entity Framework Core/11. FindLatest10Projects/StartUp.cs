namespace FindLatest10Projects
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
                var projects = db
                    .Projects
                    .OrderByDescending(p => p.StartDate)
                    .Take(10)
                    .OrderBy(p => p.Name)
                    .Select(p => new
                    {
                        p.Name,
                        p.Description,
                        StartDate = p.StartDate.ToString("M/d/yyyy h:mm:ss tt")
                    });

                using (StreamWriter sw = new StreamWriter("../../../output.txt"))
                {
                    foreach (var project in projects)
                    {
                        sw.WriteLine(project.Name);
                        sw.WriteLine(project.Description);
                        sw.WriteLine(project.StartDate);
                    }
                }
            }
        }
    }
}
