package projectrider.bindingModel;

import javax.validation.constraints.NotNull;

public class ProjectBindingModel {
    @NotNull
    private String title;

    @NotNull
    private String description;

    @NotNull
    private long budget;

    public String getTitle() {
        return title;
    }

    public void setTitle(String title) {
        this.title = title;
    }

    public String getDescription() {
        return description;
    }

    public void setDescription(String description) {
        this.description = description;
    }

    public long getBudget() {
        return budget;
    }

    public void setBudget(long budget) {
        this.budget = budget;
    }
}
