namespace ProjectRider.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using Models;

    [ValidateInput(false)]
    public class ProjectController : Controller
    {
        [HttpGet]
        [Route("")]
        public ActionResult Index()
        {
            using (var database = new ProjectRiderDbContext())
            {
                List<Project> projects = database.Projects.ToList();

                return View(projects);
            }
        }

        [HttpGet]
        [Route("create")]
        public ActionResult Create()
        {
            return View(new Project());
        }

        [HttpPost]
        [Route("create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Project project)
        {
            using (var database = new ProjectRiderDbContext())
            {
                database.Projects.Add(project);
                database.SaveChanges();

                return Redirect("/");
            }
        }

        [HttpGet]
        [Route("edit/{id}")]
        public ActionResult Edit(int id)
        {
            using (var database = new ProjectRiderDbContext())
            {
                Project existingProject = database.Projects.Find(id);

                return View(existingProject);
            }
        }

        [HttpPost]
        [Route("edit/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult EditConfirm(int id, Project project)
        {
            using (var database = new ProjectRiderDbContext())
            {
                Project existingProject = database.Projects.Find(id);

                if (this.ModelState.IsValid)
                {
                    existingProject.Title = project.Title;
                    existingProject.Description = project.Description;
                    existingProject.Budget = project.Budget;

                    database.SaveChanges();

                    return Redirect("/");
                }

                return View("Edit", project);
            }
        }

        [HttpGet]
        [Route("delete/{id}")]
        public ActionResult Delete(int id)
        {
            using (var database = new ProjectRiderDbContext())
            {
                Project existingProject = database.Projects.Find(id);

                return View(existingProject);
            }
        }

        [HttpPost]
        [Route("delete/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id, Project reportModel)
        {
            using (var database = new ProjectRiderDbContext())
            {
                Project existingProject = database.Projects.Find(id);

                database.Projects.Remove(existingProject);
                database.SaveChanges();

                return Redirect("/");
            }
        }
    }
}