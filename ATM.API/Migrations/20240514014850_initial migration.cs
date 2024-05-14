using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace atm.api.web.Migrations
{
    /// <inheritdoc />
    public partial class initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Card",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CardNumber = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PIN = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Balance = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Enabled = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Card", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "OperationTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationTypes", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CardId = table.Column<int>(type: "int", nullable: false),
                    LastAccessDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FailedAccessAttempts = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAccounts_Card_CardId",
                        column: x => x.CardId,
                        principalTable: "Card",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Operations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OperationTypeId = table.Column<int>(type: "int", nullable: false),
                    CardId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    OperationDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Operations_Card_CardId",
                        column: x => x.CardId,
                        principalTable: "Card",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Operations_OperationTypes_OperationTypeId",
                        column: x => x.OperationTypeId,
                        principalTable: "OperationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Card",
                columns: new[] { "Id", "Balance", "CardNumber", "Enabled", "PIN" },
                values: new object[,]
                {
                    { 1, 600.00m, "1234567890123456", true, "1234" },
                    { 2, 600.00m, "9876543210987654", true, "4321" },
                    { 3, 1000.00m, "1111222233334444", true, "5678" },
                    { 4, 150.00m, "5555666677778888", true, "8765" },
                    { 5, 650.00m, "9999000011112222", true, "9876" }
                });

            migrationBuilder.InsertData(
                table: "OperationTypes",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Operación de inicio de sesión de usuario", "Inicio de sesión" },
                    { 2, "Operación de retiro", "Retiro" },
                    { 3, "Operación de consulta de saldo", "Saldo" }
                });

            migrationBuilder.InsertData(
                table: "Operations",
                columns: new[] { "Id", "Amount", "CardId", "OperationDateTime", "OperationTypeId" },
                values: new object[,]
                {
                    { 1, 0m, 1, new DateTime(2024, 5, 13, 22, 48, 51, 510, DateTimeKind.Local).AddTicks(9204), 1 },
                    { 2, -100m, 1, new DateTime(2024, 5, 13, 22, 48, 52, 510, DateTimeKind.Local).AddTicks(9212), 2 },
                    { 3, 1400m, 1, new DateTime(2024, 5, 13, 22, 48, 53, 510, DateTimeKind.Local).AddTicks(9214), 3 },
                    { 4, -50m, 1, new DateTime(2024, 5, 13, 22, 48, 54, 510, DateTimeKind.Local).AddTicks(9215), 2 },
                    { 5, 0m, 1, new DateTime(2024, 5, 13, 22, 48, 55, 510, DateTimeKind.Local).AddTicks(9216), 1 },
                    { 6, 1350m, 1, new DateTime(2024, 5, 13, 22, 48, 56, 510, DateTimeKind.Local).AddTicks(9218), 3 },
                    { 7, -300m, 1, new DateTime(2024, 5, 13, 22, 48, 57, 510, DateTimeKind.Local).AddTicks(9220), 2 },
                    { 8, 0m, 1, new DateTime(2024, 5, 13, 22, 48, 58, 510, DateTimeKind.Local).AddTicks(9221), 1 },
                    { 9, -200m, 1, new DateTime(2024, 5, 13, 22, 48, 59, 510, DateTimeKind.Local).AddTicks(9222), 2 },
                    { 10, 850m, 1, new DateTime(2024, 5, 13, 22, 49, 0, 510, DateTimeKind.Local).AddTicks(9224), 3 },
                    { 11, -150m, 1, new DateTime(2024, 5, 13, 22, 49, 1, 510, DateTimeKind.Local).AddTicks(9225), 2 },
                    { 12, 0m, 1, new DateTime(2024, 5, 13, 22, 49, 2, 510, DateTimeKind.Local).AddTicks(9226), 1 },
                    { 13, 700m, 1, new DateTime(2024, 5, 13, 22, 49, 3, 510, DateTimeKind.Local).AddTicks(9228), 3 },
                    { 14, -100m, 1, new DateTime(2024, 5, 13, 22, 49, 4, 510, DateTimeKind.Local).AddTicks(9229), 2 },
                    { 15, 0m, 1, new DateTime(2024, 5, 13, 22, 49, 5, 510, DateTimeKind.Local).AddTicks(9230), 1 },
                    { 16, 0m, 2, new DateTime(2024, 5, 13, 22, 48, 51, 510, DateTimeKind.Local).AddTicks(9231), 1 },
                    { 17, -100m, 2, new DateTime(2024, 5, 13, 22, 48, 52, 510, DateTimeKind.Local).AddTicks(9233), 2 },
                    { 18, 1400m, 2, new DateTime(2024, 5, 13, 22, 48, 53, 510, DateTimeKind.Local).AddTicks(9235), 3 },
                    { 19, -50m, 2, new DateTime(2024, 5, 13, 22, 48, 54, 510, DateTimeKind.Local).AddTicks(9236), 2 },
                    { 20, 0m, 2, new DateTime(2024, 5, 13, 22, 48, 55, 510, DateTimeKind.Local).AddTicks(9237), 1 },
                    { 21, 1350m, 2, new DateTime(2024, 5, 13, 22, 48, 56, 510, DateTimeKind.Local).AddTicks(9238), 3 },
                    { 22, -300m, 2, new DateTime(2024, 5, 13, 22, 48, 57, 510, DateTimeKind.Local).AddTicks(9240), 2 },
                    { 23, 0m, 2, new DateTime(2024, 5, 13, 22, 48, 58, 510, DateTimeKind.Local).AddTicks(9241), 1 },
                    { 24, -200m, 2, new DateTime(2024, 5, 13, 22, 48, 59, 510, DateTimeKind.Local).AddTicks(9245), 2 },
                    { 25, 850m, 2, new DateTime(2024, 5, 13, 22, 49, 0, 510, DateTimeKind.Local).AddTicks(9248), 3 },
                    { 26, -150m, 2, new DateTime(2024, 5, 13, 22, 49, 1, 510, DateTimeKind.Local).AddTicks(9249), 2 },
                    { 27, 0m, 2, new DateTime(2024, 5, 13, 22, 49, 2, 510, DateTimeKind.Local).AddTicks(9250), 1 },
                    { 28, 700m, 2, new DateTime(2024, 5, 13, 22, 49, 3, 510, DateTimeKind.Local).AddTicks(9252), 3 },
                    { 29, -100m, 2, new DateTime(2024, 5, 13, 22, 49, 4, 510, DateTimeKind.Local).AddTicks(9253), 2 },
                    { 30, 0m, 2, new DateTime(2024, 5, 13, 22, 49, 5, 510, DateTimeKind.Local).AddTicks(9254), 1 },
                    { 31, 0m, 3, new DateTime(2024, 5, 13, 22, 48, 51, 510, DateTimeKind.Local).AddTicks(9255), 1 },
                    { 32, -100m, 3, new DateTime(2024, 5, 13, 22, 48, 52, 510, DateTimeKind.Local).AddTicks(9257), 2 },
                    { 33, 1550m, 3, new DateTime(2024, 5, 13, 22, 48, 53, 510, DateTimeKind.Local).AddTicks(9258), 3 },
                    { 34, -50m, 3, new DateTime(2024, 5, 13, 22, 48, 54, 510, DateTimeKind.Local).AddTicks(9259), 2 },
                    { 35, 0m, 3, new DateTime(2024, 5, 13, 22, 48, 55, 510, DateTimeKind.Local).AddTicks(9261), 1 },
                    { 36, 1500m, 3, new DateTime(2024, 5, 13, 22, 48, 56, 510, DateTimeKind.Local).AddTicks(9262), 3 },
                    { 37, -300m, 3, new DateTime(2024, 5, 13, 22, 48, 57, 510, DateTimeKind.Local).AddTicks(9264), 2 },
                    { 38, 0m, 3, new DateTime(2024, 5, 13, 22, 48, 58, 510, DateTimeKind.Local).AddTicks(9265), 1 },
                    { 39, -200m, 3, new DateTime(2024, 5, 13, 22, 48, 59, 510, DateTimeKind.Local).AddTicks(9267), 2 },
                    { 40, 1000m, 3, new DateTime(2024, 5, 13, 22, 49, 0, 510, DateTimeKind.Local).AddTicks(9268), 3 },
                    { 41, -150m, 4, new DateTime(2024, 5, 13, 22, 48, 51, 510, DateTimeKind.Local).AddTicks(9269), 2 },
                    { 42, 0m, 4, new DateTime(2024, 5, 13, 22, 48, 52, 510, DateTimeKind.Local).AddTicks(9270), 1 },
                    { 43, 350m, 4, new DateTime(2024, 5, 13, 22, 48, 53, 510, DateTimeKind.Local).AddTicks(9271), 3 },
                    { 44, -100m, 4, new DateTime(2024, 5, 13, 22, 48, 54, 510, DateTimeKind.Local).AddTicks(9272), 2 },
                    { 45, 0m, 4, new DateTime(2024, 5, 13, 22, 48, 55, 510, DateTimeKind.Local).AddTicks(9273), 1 },
                    { 46, 250m, 4, new DateTime(2024, 5, 13, 22, 48, 56, 510, DateTimeKind.Local).AddTicks(9275), 3 },
                    { 47, -50m, 4, new DateTime(2024, 5, 13, 22, 48, 57, 510, DateTimeKind.Local).AddTicks(9276), 2 },
                    { 48, 0m, 4, new DateTime(2024, 5, 13, 22, 48, 58, 510, DateTimeKind.Local).AddTicks(9277), 1 },
                    { 49, 200m, 4, new DateTime(2024, 5, 13, 22, 48, 59, 510, DateTimeKind.Local).AddTicks(9279), 3 },
                    { 50, -50m, 4, new DateTime(2024, 5, 13, 22, 49, 0, 510, DateTimeKind.Local).AddTicks(9281), 2 },
                    { 51, 0m, 5, new DateTime(2024, 5, 13, 22, 48, 51, 510, DateTimeKind.Local).AddTicks(9282), 1 },
                    { 52, -100m, 5, new DateTime(2024, 5, 13, 22, 48, 52, 510, DateTimeKind.Local).AddTicks(9283), 2 },
                    { 53, 1050m, 5, new DateTime(2024, 5, 13, 22, 48, 53, 510, DateTimeKind.Local).AddTicks(9284), 3 },
                    { 54, -50m, 5, new DateTime(2024, 5, 13, 22, 48, 54, 510, DateTimeKind.Local).AddTicks(9285), 2 },
                    { 55, 0m, 5, new DateTime(2024, 5, 13, 22, 48, 55, 510, DateTimeKind.Local).AddTicks(9286), 1 },
                    { 56, 1000m, 5, new DateTime(2024, 5, 13, 22, 48, 56, 510, DateTimeKind.Local).AddTicks(9288), 3 },
                    { 57, -300m, 5, new DateTime(2024, 5, 13, 22, 48, 57, 510, DateTimeKind.Local).AddTicks(9289), 2 },
                    { 58, 0m, 5, new DateTime(2024, 5, 13, 22, 48, 58, 510, DateTimeKind.Local).AddTicks(9290), 1 },
                    { 59, 700m, 5, new DateTime(2024, 5, 13, 22, 48, 59, 510, DateTimeKind.Local).AddTicks(9291), 3 },
                    { 60, -50m, 5, new DateTime(2024, 5, 13, 22, 49, 0, 510, DateTimeKind.Local).AddTicks(9292), 2 }
                });

            migrationBuilder.InsertData(
                table: "UserAccounts",
                columns: new[] { "Id", "CardId", "FailedAccessAttempts", "LastAccessDate", "Name" },
                values: new object[,]
                {
                    { 1, 1, 0, new DateTime(2024, 5, 13, 22, 48, 50, 510, DateTimeKind.Local).AddTicks(9104), "Juan Perez" },
                    { 2, 2, 0, new DateTime(2024, 5, 13, 22, 48, 50, 510, DateTimeKind.Local).AddTicks(9119), "Daniel Smith" },
                    { 3, 3, 0, new DateTime(2024, 5, 13, 22, 48, 50, 510, DateTimeKind.Local).AddTicks(9120), "Alicia Perez" },
                    { 4, 4, 0, new DateTime(2024, 5, 13, 22, 48, 50, 510, DateTimeKind.Local).AddTicks(9121), "Bob Esponja" },
                    { 5, 5, 0, new DateTime(2024, 5, 13, 22, 48, 50, 510, DateTimeKind.Local).AddTicks(9122), "Pepe Argento" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Operations_CardId",
                table: "Operations",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_Operations_OperationTypeId",
                table: "Operations",
                column: "OperationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAccounts_CardId",
                table: "UserAccounts",
                column: "CardId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Operations");

            migrationBuilder.DropTable(
                name: "UserAccounts");

            migrationBuilder.DropTable(
                name: "OperationTypes");

            migrationBuilder.DropTable(
                name: "Card");
        }
    }
}
