using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication7.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDegree : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Candidates",
                columns: table => new
                {
                    CandidateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CV = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidates", x => x.CandidateId);
                });

            migrationBuilder.CreateTable(
                name: "Degrees",
                columns: table => new
                {
                    DegreeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CandidateId = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Degrees", x => x.DegreeId);
                    table.ForeignKey(
                        name: "FK_Degrees_Candidates_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidates",
                        principalColumn: "CandidateId");
                });

            migrationBuilder.InsertData(
                table: "Candidates",
                columns: new[] { "CandidateId", "CV", "CreationTime", "Email", "FirstName", "LastName", "Mobile" },
                values: new object[,]
                {
                    { 1, "PDF", new DateTime(2024, 8, 28, 18, 50, 4, 738, DateTimeKind.Local).AddTicks(7442), "john.doe@example.com", "John", "Doe", "123-456-7890" },
                    { 2, "Word", new DateTime(2024, 8, 28, 18, 50, 4, 738, DateTimeKind.Local).AddTicks(7447), "jane.smith@example.com", "Jane", "Smith", "098-765-4321" }
                });

            migrationBuilder.InsertData(
                table: "Degrees",
                columns: new[] { "DegreeId", "CandidateId", "CreationTime", "Name" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 8, 28, 18, 50, 4, 738, DateTimeKind.Local).AddTicks(7586), "Bachelor of Science" },
                    { 2, 1, new DateTime(2024, 8, 28, 18, 50, 4, 738, DateTimeKind.Local).AddTicks(7591), "Master of Science" },
                    { 3, 2, new DateTime(2024, 8, 28, 18, 50, 4, 738, DateTimeKind.Local).AddTicks(7594), "Associate Degree in Arts" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Degrees_CandidateId",
                table: "Degrees",
                column: "CandidateId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Degrees");

            migrationBuilder.DropTable(
                name: "Candidates");
        }
    }
}
