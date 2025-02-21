﻿// <auto-generated />
using System;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Data.Entities.AddressEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Country")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("StreetNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("Data.Entities.ContactInfoEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ContactPerson")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId")
                        .IsUnique();

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("ContactInfo");
                });

            modelBuilder.Entity("Data.Entities.CustomerAddressEntity", b =>
                {
                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CustomerId", "AddressId");

                    b.HasIndex("AddressId");

                    b.ToTable("CustomerAddresses");
                });

            modelBuilder.Entity("Data.Entities.CustomerEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("OrganizationNumber")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("varchar(13)");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationNumber")
                        .IsUnique();

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Acme Corp",
                            OrganizationNumber = "123456-7890"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Globex Ltd",
                            OrganizationNumber = "098765-4321"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Södra länken AB",
                            OrganizationNumber = "543210-1234"
                        });
                });

            modelBuilder.Entity("Data.Entities.EmployeeEntity", b =>
                {
                    b.Property<int>("EmployeeNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeNumber"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("EmployeeNumber");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            EmployeeNumber = 1,
                            FirstName = "Alice",
                            LastName = "Johnson"
                        },
                        new
                        {
                            EmployeeNumber = 2,
                            FirstName = "Bob",
                            LastName = "Smith"
                        },
                        new
                        {
                            EmployeeNumber = 3,
                            FirstName = "Anna-Marie",
                            LastName = "Jönsson"
                        });
                });

            modelBuilder.Entity("Data.Entities.ProjectEntity", b =>
                {
                    b.Property<string>("ProjectNumber")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar(4000)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("date");

                    b.Property<int?>("ManagerId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("date");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.HasKey("ProjectNumber");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ManagerId");

                    b.HasIndex("StatusId");

                    b.ToTable("Projects");

                    b.HasData(
                        new
                        {
                            ProjectNumber = "P-1001",
                            CustomerId = 1,
                            Description = "Creating a modern web app.",
                            EndDate = new DateTime(2025, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ManagerId = 1,
                            Name = "Website Development",
                            StartDate = new DateTime(2025, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StatusId = 2
                        },
                        new
                        {
                            ProjectNumber = "P-1002",
                            CustomerId = 1,
                            Description = "",
                            EndDate = new DateTime(2025, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ManagerId = 1,
                            Name = "Security Education",
                            StartDate = new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StatusId = 3
                        },
                        new
                        {
                            ProjectNumber = "P-1003",
                            CustomerId = 1,
                            Description = "Creating a more modern web app.",
                            EndDate = new DateTime(2025, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ManagerId = 3,
                            Name = "Website Development 2",
                            StartDate = new DateTime(2025, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StatusId = 1
                        });
                });

            modelBuilder.Entity("Data.Entities.ServiceEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(10,2)");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Services");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Consulting",
                            Price = 1000m,
                            Unit = "Hour"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Development",
                            Price = 2000m,
                            Unit = "Hour"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Start Up",
                            Price = 3000m,
                            Unit = "Flat fee"
                        });
                });

            modelBuilder.Entity("Data.Entities.ServiceUsageEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ProjectNumber")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<decimal>("Quantity")
                        .HasColumnType("decimal(10,2)");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProjectNumber");

                    b.HasIndex("ServiceId");

                    b.ToTable("ServiceUsages");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ProjectNumber = "P-1001",
                            Quantity = 10m,
                            ServiceId = 1
                        },
                        new
                        {
                            Id = 2,
                            ProjectNumber = "P-1001",
                            Quantity = 20m,
                            ServiceId = 2
                        },
                        new
                        {
                            Id = 3,
                            ProjectNumber = "P-1002",
                            Quantity = 2m,
                            ServiceId = 3
                        },
                        new
                        {
                            Id = 4,
                            ProjectNumber = "P-1003",
                            Quantity = 1m,
                            ServiceId = 3
                        },
                        new
                        {
                            Id = 5,
                            ProjectNumber = "P-1003",
                            Quantity = 50m,
                            ServiceId = 2
                        });
                });

            modelBuilder.Entity("Data.Entities.StatusEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Statuses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Not Started"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Ongoing"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Completed"
                        });
                });

            modelBuilder.Entity("Data.Entities.ContactInfoEntity", b =>
                {
                    b.HasOne("Data.Entities.CustomerEntity", "Customer")
                        .WithOne("ContactInfo")
                        .HasForeignKey("Data.Entities.ContactInfoEntity", "CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Data.Entities.CustomerAddressEntity", b =>
                {
                    b.HasOne("Data.Entities.AddressEntity", "Address")
                        .WithMany("CustomerAddresses")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Data.Entities.CustomerEntity", "Customer")
                        .WithMany("CustomerAddresses")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Data.Entities.ProjectEntity", b =>
                {
                    b.HasOne("Data.Entities.CustomerEntity", "Customer")
                        .WithMany("Projects")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Data.Entities.EmployeeEntity", "Manager")
                        .WithMany("ManagedProjects")
                        .HasForeignKey("ManagerId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Data.Entities.StatusEntity", "Status")
                        .WithMany("Projects")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Manager");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("Data.Entities.ServiceUsageEntity", b =>
                {
                    b.HasOne("Data.Entities.ProjectEntity", "Project")
                        .WithMany("ServiceUsages")
                        .HasForeignKey("ProjectNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Entities.ServiceEntity", "Service")
                        .WithMany("ServiceUsages")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("Data.Entities.AddressEntity", b =>
                {
                    b.Navigation("CustomerAddresses");
                });

            modelBuilder.Entity("Data.Entities.CustomerEntity", b =>
                {
                    b.Navigation("ContactInfo")
                        .IsRequired();

                    b.Navigation("CustomerAddresses");

                    b.Navigation("Projects");
                });

            modelBuilder.Entity("Data.Entities.EmployeeEntity", b =>
                {
                    b.Navigation("ManagedProjects");
                });

            modelBuilder.Entity("Data.Entities.ProjectEntity", b =>
                {
                    b.Navigation("ServiceUsages");
                });

            modelBuilder.Entity("Data.Entities.ServiceEntity", b =>
                {
                    b.Navigation("ServiceUsages");
                });

            modelBuilder.Entity("Data.Entities.StatusEntity", b =>
                {
                    b.Navigation("Projects");
                });
#pragma warning restore 612, 618
        }
    }
}
