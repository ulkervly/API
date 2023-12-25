using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBiz.Data.Migrations
{
    public partial class empstable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(90)", maxLength: 90, nullable: false),
                    Position = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Department = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    EmployeeImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
