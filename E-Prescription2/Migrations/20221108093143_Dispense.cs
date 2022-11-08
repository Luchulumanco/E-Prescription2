using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Prescription2.Migrations
{
    public partial class Dispense : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                schema: "Identity",
                table: "DispenseDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Statuses",
                schema: "Identity",
                table: "DispenseDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                schema: "Identity",
                table: "DispenseDetails");

            migrationBuilder.DropColumn(
                name: "Statuses",
                schema: "Identity",
                table: "DispenseDetails");
        }
    }
}
