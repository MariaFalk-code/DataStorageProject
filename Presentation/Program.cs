using Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;

//Got help from ChatGPT4o with this code for configuring the database connection.
var host = Host.CreateDefaultBuilder()
    .ConfigureServices((context, services) =>
    {
        // Gets connection string from appsettings.json
        var connectionString = context.Configuration.GetConnectionString("DefaultConnection");

        // Add DbContext to the DI container
        services.AddDbContext<DataContext>(options =>
            options.UseSqlServer(connectionString));
    })
    .Build();

//Gets the DataContext instance from DI (example usage)
using var scope = host.Services.CreateScope();
var dbContext = scope.ServiceProvider.GetRequiredService<DataContext>();

await host.RunAsync();
