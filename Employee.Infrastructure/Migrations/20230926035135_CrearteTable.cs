using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Employee.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CrearteTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Emp");

            migrationBuilder.CreateTable(
                name: "Country",
                schema: "Emp",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryName = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Courencies = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateName = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.Id);
                    table.ForeignKey(
                        name: "FK_States_Country_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "Emp",
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                schema: "Emp",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    StateId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employee_Country_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "Emp",
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employee_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                schema: "Emp",
                table: "Country",
                columns: new[] { "Id", "CountryName", "Courencies", "Created", "CreatedBy", "LastModified", "LastModifiedBy", "Status" },
                values: new object[,]
                {
                    { 1, "BanglaDesh", "Taka", new DateTimeOffset(new DateTime(2023, 9, 26, 9, 51, 35, 157, DateTimeKind.Unspecified).AddTicks(2409), new TimeSpan(0, 6, 0, 0, 0)), "1", null, null, 1 },
                    { 2, "India", "Rupi", new DateTimeOffset(new DateTime(2023, 9, 26, 9, 51, 35, 157, DateTimeKind.Unspecified).AddTicks(2456), new TimeSpan(0, 6, 0, 0, 0)), "1", null, null, 1 }
                });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "Id", "CountryId", "Created", "CreatedBy", "LastModified", "LastModifiedBy", "StateName", "Status" },
                values: new object[,]
                {
                    { 1, 1, new DateTimeOffset(new DateTime(2023, 9, 26, 9, 51, 35, 159, DateTimeKind.Unspecified).AddTicks(9470), new TimeSpan(0, 6, 0, 0, 0)), "1", null, null, "Dhaka", 1 },
                    { 2, 1, new DateTimeOffset(new DateTime(2023, 9, 26, 9, 51, 35, 159, DateTimeKind.Unspecified).AddTicks(9488), new TimeSpan(0, 6, 0, 0, 0)), "1", null, null, "Rajshahi", 1 },
                    { 3, 2, new DateTimeOffset(new DateTime(2023, 9, 26, 9, 51, 35, 159, DateTimeKind.Unspecified).AddTicks(9491), new TimeSpan(0, 6, 0, 0, 0)), "1", null, null, "Mumbai", 1 }
                });

            migrationBuilder.InsertData(
                schema: "Emp",
                table: "Employee",
                columns: new[] { "Id", "Address", "Age", "CountryId", "Created", "CreatedBy", "FirstName", "LastModified", "LastModifiedBy", "LastName", "PhoneNumber", "StateId", "Status" },
                values: new object[,]
                {
                    { 1, "Dhaka", 26, 1, new DateTimeOffset(new DateTime(2023, 9, 26, 9, 51, 35, 158, DateTimeKind.Unspecified).AddTicks(9874), new TimeSpan(0, 6, 0, 0, 0)), "1", "M.A. Monaem", null, null, "Khan", "01303271849", 1, 1 },
                    { 2, "Dhaka", 26, 2, new DateTimeOffset(new DateTime(2023, 9, 26, 9, 51, 35, 158, DateTimeKind.Unspecified).AddTicks(9895), new TimeSpan(0, 6, 0, 0, 0)), "1", "M.A.", null, null, "Khan", "013", 3, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Country_CountryName",
                schema: "Emp",
                table: "Country",
                column: "CountryName");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_CountryId",
                schema: "Emp",
                table: "Employee",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_FirstName",
                schema: "Emp",
                table: "Employee",
                column: "FirstName");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_StateId",
                schema: "Emp",
                table: "Employee",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_States_CountryId",
                table: "States",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_States_StateName",
                table: "States",
                column: "StateName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee",
                schema: "Emp");

            migrationBuilder.DropTable(
                name: "States");

            migrationBuilder.DropTable(
                name: "Country",
                schema: "Emp");
        }
    }
}
