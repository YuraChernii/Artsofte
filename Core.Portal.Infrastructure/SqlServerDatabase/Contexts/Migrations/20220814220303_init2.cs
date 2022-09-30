using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Portal.Infrastructure.SqlServerDatabase.Contexts.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Floor", "Name" },
                values: new object[] { new Guid("121e1d20-1138-4193-8477-cf65e6d238f7"), 0, "Department 2" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Floor", "Name" },
                values: new object[] { new Guid("24eefa8b-5b9d-42f7-999c-9a54363e7f7e"), 0, "Department 1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("121e1d20-1138-4193-8477-cf65e6d238f7"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("24eefa8b-5b9d-42f7-999c-9a54363e7f7e"));
        }
    }
}
