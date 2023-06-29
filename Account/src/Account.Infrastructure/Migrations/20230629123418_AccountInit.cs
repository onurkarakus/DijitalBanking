using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Account.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AccountInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Account");

            migrationBuilder.CreateTable(
                name: "AccountCurrency",
                schema: "Account",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountCurrency", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AccountType",
                schema: "Account",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AccountInformation",
                schema: "Account",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    BranchCode = table.Column<int>(type: "int", nullable: false),
                    AccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Suffix = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountTypeId = table.Column<int>(type: "int", nullable: false),
                    AccountCurrencyId = table.Column<int>(type: "int", nullable: false),
                    Balance = table.Column<int>(type: "int", nullable: false),
                    AccountActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountInformation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountInformation_AccountCurrency_AccountCurrencyId",
                        column: x => x.AccountCurrencyId,
                        principalSchema: "Account",
                        principalTable: "AccountCurrency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountInformation_AccountType_AccountTypeId",
                        column: x => x.AccountTypeId,
                        principalSchema: "Account",
                        principalTable: "AccountType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Account",
                table: "AccountCurrency",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Description", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "SeedBatch", new DateTime(2023, 6, 29, 15, 34, 18, 68, DateTimeKind.Local).AddTicks(6762), "Türk Lirası", "TRY", "SeedBatch", new DateTime(2023, 6, 29, 15, 34, 18, 68, DateTimeKind.Local).AddTicks(6763) },
                    { 2, "SeedBatch", new DateTime(2023, 6, 29, 15, 34, 18, 68, DateTimeKind.Local).AddTicks(6765), "Amerikan Doları", "USD", "SeedBatch", new DateTime(2023, 6, 29, 15, 34, 18, 68, DateTimeKind.Local).AddTicks(6766) },
                    { 3, "SeedBatch", new DateTime(2023, 6, 29, 15, 34, 18, 68, DateTimeKind.Local).AddTicks(6769), "Euro", "EUR", "SeedBatch", new DateTime(2023, 6, 29, 15, 34, 18, 68, DateTimeKind.Local).AddTicks(6770) }
                });

            migrationBuilder.InsertData(
                schema: "Account",
                table: "AccountType",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Description", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "SeedBatch", new DateTime(2023, 6, 29, 15, 34, 18, 68, DateTimeKind.Local).AddTicks(6306), "Vadeli Hesap", "Vadeli Hesap", "SeedBatch", new DateTime(2023, 6, 29, 15, 34, 18, 68, DateTimeKind.Local).AddTicks(6336) },
                    { 2, "SeedBatch", new DateTime(2023, 6, 29, 15, 34, 18, 68, DateTimeKind.Local).AddTicks(6344), "Vadesiz Hesap", "Vadesiz Hesap", "SeedBatch", new DateTime(2023, 6, 29, 15, 34, 18, 68, DateTimeKind.Local).AddTicks(6345) }
                });

            migrationBuilder.InsertData(
                schema: "Account",
                table: "AccountInformation",
                columns: new[] { "Id", "AccountActive", "AccountCurrencyId", "AccountNumber", "AccountTypeId", "Balance", "BranchCode", "CreatedBy", "CreatedDate", "CustomerId", "Suffix", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, true, 1, "456", 2, 1000, 1234, "SeedBatch", new DateTime(2023, 6, 29, 15, 34, 18, 68, DateTimeKind.Local).AddTicks(6808), 1, "02", "SeedBatch", new DateTime(2023, 6, 29, 15, 34, 18, 68, DateTimeKind.Local).AddTicks(6809) },
                    { 2, true, 1, "1234", 1, 1000, 1234, "SeedBatch", new DateTime(2023, 6, 29, 15, 34, 18, 68, DateTimeKind.Local).AddTicks(6813), 1, "01", "SeedBatch", new DateTime(2023, 6, 29, 15, 34, 18, 68, DateTimeKind.Local).AddTicks(6814) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountInformation_AccountCurrencyId",
                schema: "Account",
                table: "AccountInformation",
                column: "AccountCurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountInformation_AccountTypeId",
                schema: "Account",
                table: "AccountInformation",
                column: "AccountTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountInformation",
                schema: "Account");

            migrationBuilder.DropTable(
                name: "AccountCurrency",
                schema: "Account");

            migrationBuilder.DropTable(
                name: "AccountType",
                schema: "Account");
        }
    }
}
