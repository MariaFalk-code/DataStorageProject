using Business.Interfaces;

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
        Console.WriteLine("1. View all projects");
        Console.WriteLine("2. Create a new project");
        Console.WriteLine("3. Edit an existing project");
        Console.WriteLine("4. Delete a project");
        Console.WriteLine("4. Exit");
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

    private void WaitForUserInput(string message = "Press any key to return to the main menu.")
    {
        Console.WriteLine();
        Console.WriteLine(message);
        Console.ReadKey();
    }
}
}

