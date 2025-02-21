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


var updateModel = new ProjectUpdateModel
{
    Name = "Updated Office System",
    Description = "New description for the office system project.",
    StatusId = 2, // Assuming 2 = "In Progress"
    ManagerId = 3, // Assuming manager with ID 3 exists
    StartDate = DateTime.UtcNow,
    EndDate = DateTime.UtcNow.AddMonths(6)
};

var updateResult = await projectService.UpdateProjectAsync("P-1001", updateModel);
Console.WriteLine(updateResult ? "✅ Project Updated Successfully!" : "❌ Failed to Update Project");








