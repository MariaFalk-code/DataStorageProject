using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Data.Context;

namespace Data.Contexts;

public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
{
    public DataContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
        optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=ProjectDB;Trusted_Connection=True;MultipleActiveResultSets=true");

        return new DataContext(optionsBuilder.Options);
    }
}
