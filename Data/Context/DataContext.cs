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
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<CustomerAddressEntity>()
            .HasOne(ca => ca.Address)
            .WithMany(a => a.CustomerAddresses)
            .HasForeignKey(ca => ca.AddressId)
            .OnDelete(DeleteBehavior.Cascade);

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
            .HasForeignKey(p => p.CustomerId);

        modelBuilder.Entity<ProjectEntity>()
            .HasOne(p => p.Status)
            .WithMany(st => st.Projects)
            .HasForeignKey(p => p.StatusId);

        modelBuilder.Entity<ProjectEntity>()
            .HasOne(p => p.Manager)
            .WithMany(e => e.ManagedProjects)
            .HasForeignKey(p => p.ManagerId)
            .HasPrincipalKey(e => e.EmployeeNumber);
    }
}
