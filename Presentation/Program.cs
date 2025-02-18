using Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Data.Repositories;
using Data.Interfaces;

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
    })
    .Build();
