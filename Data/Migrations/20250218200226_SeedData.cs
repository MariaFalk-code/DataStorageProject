using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Name", "OrganizationNumber" },
                values: new object[,]
                {
                    { 1, "Acme Corp", "123456-7890" },
                    { 2, "Globex Ltd", "098765-4321" },
                    { 3, "Södra länken AB", "543210-1234" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeNumber", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Alice", "Johnson" },
                    { 2, "Bob", "Smith" },
                    { 3, "Anna-Marie", "Jönsson" }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "Description", "Name", "Price", "Unit" },
                values: new object[,]
                {
                    { 1, null, "Consulting", 1000m, "Hour" },
                    { 2, null, "Development", 2000m, "Hour" },
                    { 3, null, "Start Up", 3000m, "Flat fee" }
                });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Not Started" },
                    { 2, "Ongoing" },
                    { 3, "Completed" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "ProjectNumber", "CustomerId", "Description", "EndDate", "ManagerId", "Name", "StartDate", "StatusId" },
                values: new object[,]
                {
                    { "P-1001", 1, "Creating a modern web app.", new DateTime(2025, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Website Development", new DateTime(2025, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "P-1002", 1, "", new DateTime(2025, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Security Education", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "P-1003", 1, "Creating a more modern web app.", new DateTime(2025, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Website Development 2", new DateTime(2025, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 }
                });

            migrationBuilder.InsertData(
                table: "ServiceUsages",
                columns: new[] { "Id", "ProjectNumber", "Quantity", "ServiceId" },
                values: new object[,]
                {
                    { 1, "P-1001", 10m, 1 },
                    { 2, "P-1001", 20m, 2 },
                    { 3, "P-1002", 2m, 3 },
                    { 4, "P-1003", 1m, 3 },
                    { 5, "P-1003", 50m, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeNumber",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ServiceUsages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ServiceUsages",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ServiceUsages",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ServiceUsages",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ServiceUsages",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ProjectNumber",
                keyValue: "P-1001");

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ProjectNumber",
                keyValue: "P-1002");

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ProjectNumber",
                keyValue: "P-1003");

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeNumber",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeNumber",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
