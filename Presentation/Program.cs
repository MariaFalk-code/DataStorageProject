using Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Data.Repositories;
using Data.Interfaces;
using Business.Services;
using Business.Interfaces;
using Business.Models;

//Got help from ChatGPT4o with this code for configuring the database connection.
var host = Host.CreateDefaultBuilder()
    .ConfigureServices((context, services) =>
    {
        // Gets connection string from appsettings.json
        var connectionString = context.Configuration.GetConnectionString("DefaultConnection");

        // Add DbContext to the DI container
        services.AddDbContext<DataContext>(options =>
            options.UseSqlServer(connectionString));

        // Register repositories
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddScoped<IProjectRepository, ProjectRepository>();
        services.AddScoped<IServiceRepository, ServiceRepository>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IAddressRepository, AddressRepository>();
        services.AddScoped<IServiceUsageRepository, ServiceUsageRepository>();
        services.AddScoped<IContactInfoRepository, ContactInfoRepository>();
        services.AddScoped<ICustomerAddressRepository, CustomerAddressRepository>();
        services.AddScoped<ICustomerService, CustomerService>();
        services.AddScoped<IProjectService, ProjectService>();
    })
    .Build();

var projectService = host.Services.GetRequiredService<IProjectService>();


var status = 1; // Change this to any valid status name in the database
var projects = await projectService.GetProjectsByStatusAsync(status);

if (projects.Any())
{
    Console.WriteLine($"✅ Found {projects.Count()} projects with status '{status}':");
    foreach (var project in projects)
    {
        Console.WriteLine($"🔹 {project.Name} ({project.ProjectNumber}) - Customer: {project.Customer?.Id}");
    }
}
else
{
    Console.WriteLine($"❌ No projects found with status '{status}'.");
}







