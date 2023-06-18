using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Customer.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCustomerInformation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FavoriteTeam",
                schema: "Customer",
                table: "CustomerInformation",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                schema: "Customer",
                table: "CustomerInformation",
                columns: new[] { "Id", "BirthDate", "CreatedBy", "CreatedDate", "FavoriteTeam", "FirstName", "LastName", "MiddleName", "UpdateDate", "UpdatedBy" },
                values: new object[] { 1, new DateTime(1980, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "SeedBatch", new DateTime(2023, 6, 19, 0, 47, 47, 144, DateTimeKind.Local).AddTicks(2665), "Galatasaray", "Mehmet", "Yılmaz", "Onur", new DateTime(2023, 6, 19, 0, 47, 47, 144, DateTimeKind.Local).AddTicks(2681), "SeedBatch" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Customer",
                table: "CustomerInformation",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "FavoriteTeam",
                schema: "Customer",
                table: "CustomerInformation");
        }
    }
}
