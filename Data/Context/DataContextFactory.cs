//using Microsoft.EntityFrameworkCore.Design;
//using Microsoft.EntityFrameworkCore;
//using Data.Context;

//namespace Data.Contexts;

//public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
//{
//    public DataContext CreateDbContext(string[] args)
//    {
//        var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
//        optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=DATABASEGOESHERE;Trusted_Connection=True;");

//        return new DataContext(optionsBuilder.Options);
//    }
//}
