using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HospitalConsoleApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Specializations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Capacity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specializations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    SpecializationId = table.Column<int>(type: "INTEGER", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patients_Specializations_SpecializationId",
                        column: x => x.SpecializationId,
                        principalTable: "Specializations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Specializations",
                columns: new[] { "Id", "Capacity", "Name" },
                values: new object[,]
                {
                    { 1, 5, "Children" },
                    { 2, 5, "Surgery" },
                    { 3, 5, "Internal Medicine" },
                    { 4, 5, "Cardiology" },
                    { 5, 5, "Neurology" },
                    { 6, 5, "Orthopedics" },
                    { 7, 5, "Ophthalmology" },
                    { 8, 5, "ENT" },
                    { 9, 5, "Dermatology" },
                    { 10, 5, "Dentistry" },
                    { 11, 5, "Urology" },
                    { 12, 5, "Gynecology" },
                    { 13, 5, "Psychiatry" },
                    { 14, 5, "Oncology" },
                    { 15, 5, "Radiology" },
                    { 16, 5, "Emergency" },
                    { 17, 5, "Pediatrics" },
                    { 18, 5, "Pulmonology" },
                    { 19, 5, "Nephrology" },
                    { 20, 5, "Gastroenterology" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Patients_SpecializationId_Status_Id",
                table: "Patients",
                columns: new[] { "SpecializationId", "Status", "Id" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Specializations");
        }
    }
}
