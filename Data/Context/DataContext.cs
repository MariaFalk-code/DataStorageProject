using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Context;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<AddressEntity> Addresses { get; set; }
    public DbSet<ContactInfoEntity> ContactInfo { get; set; }
    public DbSet<CustomerEntity> Customers { get; set; }
    public DbSet<CustomerAddressEntity> CustomerAddresses { get; set; }
    public DbSet<EmployeeEntity> Employees { get; set; }
    public DbSet<ProjectEntity> Projects { get; set; }
    public DbSet<ServiceEntity> Services { get; set; }
    public DbSet<ServiceUsageEntity> ServiceUsages { get; set; }
    public DbSet<StatusEntity> Statuses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Keys
        modelBuilder.Entity<ProjectEntity>()
            .HasKey(p => p.ProjectNumber);

        modelBuilder.Entity<EmployeeEntity>()
            .HasKey(e => e.EmployeeNumber);

        modelBuilder.Entity<CustomerAddressEntity>()
            //Composite key
            .HasKey(ca => new { ca.CustomerId, ca.AddressId });

        //Relations
        modelBuilder.Entity<ContactInfoEntity>()
            .HasOne(ci => ci.Customer)
            .WithOne(c => c.ContactInfo)
            .HasForeignKey<ContactInfoEntity>(ci => ci.CustomerId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<CustomerAddressEntity>()
            .HasOne(ca => ca.Customer)
            .WithMany(c => c.CustomerAddresses)
            .HasForeignKey(ca => ca.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<CustomerAddressEntity>()
            .HasOne(ca => ca.Address)
            .WithMany(a => a.CustomerAddresses)
            .HasForeignKey(ca => ca.AddressId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ServiceUsageEntity>()
            .HasOne(su => su.Service)
            .WithMany(se => se.ServiceUsages)
            .HasForeignKey(su => su.ServiceId);

        modelBuilder.Entity<ServiceUsageEntity>()
            .HasOne(su => su.Project)
            .WithMany(p => p.ServiceUsages)
            .HasForeignKey(su => su.ProjectNumber);

        modelBuilder.Entity<ProjectEntity>()
            .HasOne(p => p.Customer)
            .WithMany(c => c.Projects)
            .HasForeignKey(p => p.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ProjectEntity>()
            .HasOne(p => p.Status)
            .WithMany(st => st.Projects)
            .HasForeignKey(p => p.StatusId);

        modelBuilder.Entity<ProjectEntity>()
            .HasOne(p => p.Manager)
            .WithMany(e => e.ManagedProjects)
            .HasForeignKey(p => p.ManagerId)
            .HasPrincipalKey(e => e.EmployeeNumber)
            .OnDelete(DeleteBehavior.SetNull);
    
        //Seeding the database
        base.OnModelCreating(modelBuilder);

        // Seed Statuses
        modelBuilder.Entity<StatusEntity>().HasData(
            new StatusEntity { Id = 1, Name = "Not Started" },
            new StatusEntity { Id = 2, Name = "Ongoing" },
            new StatusEntity { Id = 3, Name = "Completed" }
        );

        // Seed Customers
        modelBuilder.Entity<CustomerEntity>().HasData(
            new CustomerEntity { Id = 1, OrganizationNumber = "123456-7890", Name = "Acme Corp" },
            new CustomerEntity { Id = 2, OrganizationNumber = "098765-4321", Name = "Globex Ltd" },
            new CustomerEntity { Id = 3, OrganizationNumber = "543210-1234", Name = "Södra länken AB" }
        );

        // Seed Employees
        modelBuilder.Entity<EmployeeEntity>().HasData(
            new EmployeeEntity { EmployeeNumber = 1, FirstName = "Alice", LastName = "Johnson" },
            new EmployeeEntity { EmployeeNumber = 2, FirstName = "Bob", LastName = "Smith" },
            new EmployeeEntity { EmployeeNumber = 3, FirstName = "Anna-Marie", LastName = "Jönsson" }
        );

        // Seed Projects
        modelBuilder.Entity<ProjectEntity>().HasData(
            new ProjectEntity
            {
                ProjectNumber = "P-1001",
                Name = "Website Development",
                Description = "Creating a modern web app.",
                StartDate = new DateTime(2025, 2, 12),
                EndDate = new DateTime(2025, 6, 12),
                CustomerId = 1,
                StatusId = 2,
                ManagerId = 1
            },
            new ProjectEntity
            {
                ProjectNumber = "P-1002",
                Name = "Security Education",
                Description = "",
                StartDate = new DateTime(2025, 1, 1),
                EndDate = new DateTime(2025, 2, 11),
                CustomerId = 1,
                StatusId = 3,
                ManagerId = 1
            },
            new ProjectEntity
            {
                ProjectNumber = "P-1003",
                Name = "Website Development 2",
                Description = "Creating a more modern web app.",
                StartDate = new DateTime(2025, 6, 13),
                EndDate = new DateTime(2025, 12, 12),
                CustomerId = 1,
                StatusId = 1,
                ManagerId = 3
            }
        );

        // Seed Services
        modelBuilder.Entity<ServiceEntity>().HasData(
            new ServiceEntity { Id = 1, Name = "Consulting", Price = 1000, Unit = "Hour" },
            new ServiceEntity { Id = 2, Name = "Development", Price = 2000, Unit = "Hour" },
            new ServiceEntity { Id = 3, Name = "Start Up", Price = 3000, Unit = "Flat fee" }
        );

        // Seed Service Usage
        modelBuilder.Entity<ServiceUsageEntity>().HasData(
            new ServiceUsageEntity { Id = 1, ServiceId = 1, ProjectNumber = "P-1001", Quantity = 10 },
            new ServiceUsageEntity { Id = 2, ServiceId = 2, ProjectNumber = "P-1001", Quantity = 20 },
            new ServiceUsageEntity { Id = 3, ServiceId = 3, ProjectNumber = "P-1002", Quantity = 2 },
            new ServiceUsageEntity { Id = 4, ServiceId = 3, ProjectNumber = "P-1003", Quantity = 1 },
            new ServiceUsageEntity { Id = 5, ServiceId = 2, ProjectNumber = "P-1003", Quantity = 50 }
        );
    }
}
