using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Customer.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Customer");

            migrationBuilder.CreateTable(
                name: "CustomerInformation",
                schema: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FavoriteFootballTeam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerInformation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerSecurity",
                schema: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordSalt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecurityQuestion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecurityAnswer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastLoginDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FailedLoginAttempts = table.Column<int>(type: "int", nullable: false),
                    LastPasswordChangedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerSecurity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerSecurity_CustomerInformation_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "Customer",
                        principalTable: "CustomerInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Customer",
                table: "CustomerInformation",
                columns: new[] { "Id", "Address", "BirthDate", "CreatedBy", "CreatedDate", "EmailAddress", "FavoriteFootballTeam", "FirstName", "LastName", "MiddleName", "MobileNumber", "UpdateDate", "UpdatedBy" },
                values: new object[] { 1, "Test Adres Bilgisi", new DateTime(1980, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "SeedBatch", new DateTime(2023, 6, 20, 0, 20, 41, 61, DateTimeKind.Local).AddTicks(6515), "test@test.com", "Galatasaray", "Mehmet", "Yılmaz", "Onur", "5555555555", new DateTime(2023, 6, 20, 0, 20, 41, 61, DateTimeKind.Local).AddTicks(6527), "SeedBatch" });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerSecurity_CustomerId",
                schema: "Customer",
                table: "CustomerSecurity",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerSecurity",
                schema: "Customer");

            migrationBuilder.DropTable(
                name: "CustomerInformation",
                schema: "Customer");
        }
    }
}
