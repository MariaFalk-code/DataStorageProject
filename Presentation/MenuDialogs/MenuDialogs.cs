using Business.Interfaces;
using Business.Models;
using Business.Utilities;
using Data.Interfaces;

namespace Presentation.MenuDialogs;

public class MenuDialogs(IProjectService projectService)
{
    private readonly IProjectService _projectService = projectService;

    public void RunMainMenu()
    {
        var validOptions = new HashSet<string> { "1", "2", "3", "4", "5" };

        while (true)
        {
            Console.Clear();
            var option = DisplayMainMenu();

            if (!string.IsNullOrEmpty(option) && validOptions.Contains(option))
            {
                HandleMenuOption(option);
            }
            else
            {
                Console.WriteLine("InvalidOption. Please try again.");
                WaitForUserInput();
            }
        }
    }

    private static string DisplayMainMenu()
    {
        Console.WriteLine("--- Welcome to the Project Management System ---");
        Console.WriteLine();
        Console.WriteLine("Please select an option by entering the corresponding number:");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("1. View all projects by status");
        Console.WriteLine("2. Create a new project");
        Console.WriteLine("3. Edit an existing project");
        Console.WriteLine("4. Delete a project");
        Console.WriteLine("5. Exit");
        Console.WriteLine("---------------------------------");
        var option = Console.ReadLine()!;
        return option;
    }

    private void HandleMenuOption(string option)
    {
        switch (option)
        {
            case "1":
                ViewAllProjects();
                break;
            case "2":
                CreateNewProject();
                break;
            case "3":
                EditExistingProject();
                break;
            case "4":
                DeleteProject();
                break;
            case "5":
                Environment.Exit(0);
                break;
        }
    }

    private static void WaitForUserInput(string message = "Press any key to return to the main menu.")
    {
        Console.WriteLine();
        Console.WriteLine(message);
        Console.ReadKey();
    }

    private void ViewAllProjects()
    {
        Console.Clear();
        Console.WriteLine("Please enter the number representing the status of the projects you want to view:");
        Console.WriteLine("1. Not Started");
        Console.WriteLine("2. Ongoing");
        Console.WriteLine("3. Completed");
        Console.WriteLine("4. Exit to main manu");

        var validOptions = new HashSet<string> { "1", "2", "3", "4" };

        while (true)
        {
            var option = Console.ReadLine();
            Console.Clear();

            if (!string.IsNullOrEmpty(option) && validOptions.Contains(option))
            {
                DisplayProjectsByStatus(option);
            }
            else
            {
                Console.WriteLine("InvalidOption. Please try again.");
                WaitForUserInput();
            }
        }
    }

    private void DisplayProjectsByStatus(string option)
    {
        var statusId = int.Parse(option);

        if (statusId == 4)
        {
            RunMainMenu();
        }

        var projects = _projectService.GetProjectsByStatusAsync(statusId).Result;
        if (projects.Any())
        {
            Console.WriteLine($"Projects with status {statusId}:");
            foreach (var project in projects)
            {
                Console.WriteLine($"{project.ProjectNumber} - {project.Name} (Status: {project.Status.Name}) (StartDate: {project.StartDate}) (Planned EndDate: {project.EndDate})");
            }
        }
        else
        {
            Console.WriteLine("No projects found with the specified status.");
        }
        WaitForUserInput();
    }

    private void CreateNewProject()
    { 
        Console.Clear();
        var model = new ProjectRegistrationModel();

        Console.WriteLine("Please enter the following details to create a new project:");
        model.Name = PromptAndValidate.Prompt("Project Name: ", model, nameof(model.Name));
        model.Description = PromptAndValidate.Prompt("Project Description (optional): ", model, nameof(model.Description));

        string customerIdInput;
        int customerId;
        do
        {
            customerIdInput = PromptAndValidate.Prompt("Enter customer ID (must be a number): ", model, nameof(model.CustomerId));
        }
        while (!int.TryParse(customerIdInput, out customerId));
        model.CustomerId = customerId;

        string managerIdInput = PromptAndValidate.Prompt("Enter manager ID (optional): ", model, nameof(model.ManagerId));
        model.ManagerId = string.IsNullOrWhiteSpace(managerIdInput) ? null : int.Parse(managerIdInput);

        model.StartDate = DateTime.Parse(PromptAndValidate.Prompt("Enter start date (YYYY-MM-DD): ", model, nameof(model.StartDate)));

        string endDateInput = PromptAndValidate.Prompt("Enter end date (YYYY-MM-DD, optional):", model, nameof(model.EndDate));
        if (!string.IsNullOrWhiteSpace(endDateInput))
        {
            DateTime parsedEndDate = DateTime.Parse(endDateInput);

            if (parsedEndDate <= model.StartDate)
            {
                Console.WriteLine("Error: End date must be after start date. Please enter a valid date.");
                return;
            }

            model.EndDate = parsedEndDate;
        }
        else
        {
            model.EndDate = null;
        }

        var result = _projectService.CreateProjectAsync(model).Result;

        Console.Clear();
        Console.WriteLine(result ? "Project created successfully." : "Project creation failed.");
        WaitForUserInput();
    }

    private void EditExistingProject()
    {
        Console.Clear();
        Console.WriteLine("Welcome to the project editing menu.");
        Console.WriteLine("Enter 'exit' to cancel the edit at any time.");
        Console.WriteLine("Please enter the projectnumber of the project you want to edit:");
        Console.WriteLine("(View projectnumbers by selecting option 1 from the main menu.)");
        string projectNumber = Console.ReadLine()!;

        if (projectNumber.ToLower() == "exit")
        {
            Console.WriteLine("Edit cancelled.");
            WaitForUserInput();
            return;
        }
        var project = _projectService.GetProjectAsync(projectNumber).Result;

        if (project == null)
        {
            Console.WriteLine("Project not found.");
            WaitForUserInput();
            return;
        }
        Console.WriteLine($"Editing Project: {project.ProjectNumber} - {project.Name}");
        Console.WriteLine("Leave fields blank to keep existing values. Type 'exit' to cancel.");

        var updateModel = new ProjectUpdateModel();

        string nameInput = PromptAndValidate.Prompt($"Project Name ({project.Name}): ", project, nameof(project.Name));
        if (nameInput.ToLower() == "exit") { Console.WriteLine("Edit cancelled."); WaitForUserInput(); return; }
        updateModel.Name = string.IsNullOrWhiteSpace(nameInput) ? project.Name : nameInput;

        string descInput = PromptAndValidate.Prompt($"Description ({project.Description ?? "None"}): ", project, nameof(project.Description));
        if (descInput.ToLower() == "exit") { Console.WriteLine("Edit cancelled."); WaitForUserInput(); return; }
        updateModel.Description = string.IsNullOrWhiteSpace(descInput) ? project.Description : descInput;

        string statusIdInput = PromptAndValidate.Prompt(
        $"Enter new Status ID (current: {(project.Status != null ? project.Status.Id.ToString() : "None")}): ",
        new ProjectUpdateModel(),
        nameof(ProjectUpdateModel.StatusId));

        if (statusIdInput.ToLower() == "exit")
        {
            Console.WriteLine("Edit cancelled.");
            WaitForUserInput();
            return;
        }

        // Fixing possible null reference issue by ensuring a valid default
        updateModel.StatusId = string.IsNullOrWhiteSpace(statusIdInput)
            ? (project.Status?.Id ?? 1)
            : int.Parse(statusIdInput);

        string managerIdInput = PromptAndValidate.Prompt(
        $"Enter new Manager ID (current: {(project.Manager != null ? project.Manager.EmployeeNumber.ToString() : "None")}): ",
        new ProjectUpdateModel(), nameof(ProjectUpdateModel.ManagerId));

        if (managerIdInput.ToLower() == "exit") { Console.WriteLine("Edit cancelled."); WaitForUserInput(); return; }
        updateModel.ManagerId = string.IsNullOrWhiteSpace(managerIdInput) ? project.Manager?.EmployeeNumber : int.Parse(managerIdInput);

        Console.WriteLine("\nDo you want to save changes? (Y/N)");
        char confirm = Console.ReadKey().KeyChar;
        if (char.ToLower(confirm) != 'y')
        {
            Console.WriteLine("\nEdit cancelled.");
            WaitForUserInput();
            return;
        }

        var result = _projectService.UpdateProjectAsync(projectNumber, updateModel).Result;

            Console.Clear();
            if (result)
            {
                Console.WriteLine("Project updated successfully!");
            }
            else
            {
                Console.WriteLine("Failed to update project.");
            }

            WaitForUserInput();
    }

    private void DeleteProject()
    {
        Console.Clear();
        Console.WriteLine("Enter the project number of the project you want to delete (or type 'exit' to cancel):");
        string projectNumber = Console.ReadLine()!.Trim();

        if (projectNumber.ToLower() == "exit")
        {
            Console.WriteLine("Deletion cancelled.");
            WaitForUserInput();
            return;
        }

        var project = _projectService.GetProjectAsync(projectNumber).Result;

        if (project == null)
        {
            Console.WriteLine("Project not found.");
            WaitForUserInput();
            return;
        }

        // Check for related service usages before calling the service layer
        bool hasServiceUsages = _projectService.HasRelatedServiceUsagesAsync(projectNumber).Result;

        if (hasServiceUsages)
        {
            Console.WriteLine($"⚠️ WARNING: Project {projectNumber} has related service usages.");
            Console.Write("Are you sure you want to delete it? (Y/N): ");
            char confirm = Console.ReadKey().KeyChar;
            Console.WriteLine();

            if (char.ToLower(confirm) != 'y')
            {
                Console.WriteLine("Deletion cancelled.");
                WaitForUserInput();
                return;
            }
        }

        var result = _projectService.DeleteProjectAsync(projectNumber).Result;

        Console.Clear();
        if (result)
        {
            Console.WriteLine("Project deleted successfully!");
        }
        else
        {
            Console.WriteLine("Failed to delete project.");
        }

        WaitForUserInput();
    }
}



