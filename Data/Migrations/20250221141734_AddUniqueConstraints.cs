using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class AddUniqueConstraints : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Customers_OrganizationNumber",
                table: "Customers",
                column: "OrganizationNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContactInfo_Email",
                table: "ContactInfo",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Customers_OrganizationNumber",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_ContactInfo_Email",
                table: "ContactInfo");
        }
    }
}
