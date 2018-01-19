package projectrider.controller;

import projectrider.entity.Project;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import projectrider.bindingModel.ProjectBindingModel;
import projectrider.repository.ProjectRepository;

import java.util.List;

@Controller
public class ProjectController {
	private final ProjectRepository projectRepository;

	@Autowired
	public ProjectController(ProjectRepository projectRepository) {
		this.projectRepository = projectRepository;
	}

	@GetMapping("/")
	public String index(Model model) {
		List<Project> projects = this.projectRepository.findAll();

		model.addAttribute("projects", projects);
		model.addAttribute("view", "project/index");

		return "base-layout";
	}

	@GetMapping("/create")
	public String create(Model model) {
		model.addAttribute("projects", new ProjectBindingModel());
		model.addAttribute("view", "project/create");

		return "base-layout";
	}

	@PostMapping("/create")
	public String createProcess(Model model, ProjectBindingModel projectBindingModel) {
		Project newProject = new Project();

		newProject.setTitle(projectBindingModel.getTitle());
		newProject.setDescription(projectBindingModel.getDescription());
		newProject.setBudget(projectBindingModel.getBudget());

		projectRepository.saveAndFlush(newProject);

		return "redirect:/";
	}

	@GetMapping("/edit/{id}")
	public String edit(Model model, @PathVariable int id) {
		Project project = this.projectRepository.findOne(id);

		model.addAttribute("project", project);
		model.addAttribute("view", "project/edit");

		return "base-layout";
	}

	@PostMapping("/edit/{id}")
	public String editProcess(@PathVariable int id, Model model, ProjectBindingModel projectBindingModel) {
		Project existingProject = this.projectRepository.findOne(id);

		existingProject.setTitle(projectBindingModel.getTitle());
		existingProject.setDescription(projectBindingModel.getDescription());
		existingProject.setBudget(projectBindingModel.getBudget());

		projectRepository.saveAndFlush(existingProject);

		return "redirect:/";
	}

	@GetMapping("/delete/{id}")
	public String delete(Model model, @PathVariable int id) {
		Project project = this.projectRepository.findOne(id);

		model.addAttribute("project", project);
		model.addAttribute("view", "project/delete");

		return "base-layout";
	}

	@PostMapping("/delete/{id}")
	public String deleteProcess(@PathVariable int id, ProjectBindingModel projectBindingModel) {
		Project project = this.projectRepository.findOne(id);

		projectRepository.delete(project);
		projectRepository.flush();

		return "redirect:/";
	}
}
