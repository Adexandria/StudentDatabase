using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentDatabase.Migrations
{
    public partial class studentwithdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Classes", "DateOfBirth", "FirstName", "Gender", "LastName", "MiddleName", "State" },
                values: new object[] { new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), 5, new DateTimeOffset(new DateTime(1999, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), "Adeola", 1, "Aderibigbe", "Wuraola", 23 });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Classes", "DateOfBirth", "FirstName", "Gender", "LastName", "MiddleName", "State" },
                values: new object[] { new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"), 5, new DateTimeOffset(new DateTime(1998, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), "Uriel", 0, "Aye", "Ayebanengimote", 5 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"));
        }
    }
}
